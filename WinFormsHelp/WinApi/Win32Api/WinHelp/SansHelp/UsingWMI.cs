using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Collections.ObjectModel;

namespace mgen_processes
{
    class UsingWMI : IAction
    {
        public IEnumerable<ProcessItem> GetProcesses()
        {
            //使用WQL查询
            var mgrSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
            return mgrSearcher.Get().Cast<ManagementBaseObject>().Select(obj => GetProcessItem(obj));
        }

        static ProcessItem GetProcessItem(ManagementBaseObject mbo)
        {
            return new ProcessItem(Convert.ToInt32(mbo["processid"]), (string)mbo["name"]);
        }


        public bool Update { get { return true; } }
    }
}
