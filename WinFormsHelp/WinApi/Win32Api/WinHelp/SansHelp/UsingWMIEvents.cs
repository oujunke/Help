using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Collections.ObjectModel;

namespace mgen_processes
{
    class UsingWMIEvents : IAction
    {
        SafeObservable<ProcessItem> processes = new SafeObservable<ProcessItem>();

        public IEnumerable<ProcessItem> GetProcesses()
        {
            var mgrSearcher = new ManagementObjectSearcher("select * from Win32_Process");
            foreach (var mobj in mgrSearcher.Get())
                    processes.Add(GetProcessItem(mobj));

            //创建WQL事件查询，用于实例创建
            var qCreate = new WqlEventQuery("__InstanceCreationEvent",
                TimeSpan.FromSeconds(1),  //WHTHIN = 1
                "TargetInstance ISA 'Win32_Process'");
            //创建WQL事件查询，用于实例删除
            var qDelete = new WqlEventQuery("__InstanceDeletionEvent",
                TimeSpan.FromSeconds(1),  //WHTHIN = 1
                "TargetInstance ISA 'Win32_Process'");

            //创建事件查询的侦听器（ManagementEventWatcher）
            var wCreate = new ManagementEventWatcher(qCreate);
            var wDelete = new ManagementEventWatcher(qDelete);

            //事件注册代码
            wCreate.EventArrived += (sender, e) =>
            {
                processes.Add(GetProcessItemFromWQLEvent(e));
            };
            wDelete.EventArrived += (sender, e) =>
            {
                processes.Remove(GetProcessItemFromWQLEvent(e));
            };

            //异步开始侦听
            wCreate.Start();
            wDelete.Start();

            return processes;
        }

        static ProcessItem GetProcessItem(ManagementBaseObject mbo)
        {
            return new ProcessItem(Convert.ToInt32(mbo["processid"]), (string)mbo["name"]);
        }
        static ProcessItem GetProcessItemFromWQLEvent(EventArrivedEventArgs e)
        {
            return GetProcessItem((ManagementBaseObject)e.NewEvent["TargetInstance"]);
        }


        public bool Update { get { return false; } }



    }
}
