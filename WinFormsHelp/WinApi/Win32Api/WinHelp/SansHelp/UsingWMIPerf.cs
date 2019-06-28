using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Collections.ObjectModel;

namespace mgen_processes
{
    class UsingWMIPerf : IAction
    {
        public IEnumerable<ProcessItem> GetProcesses()
        {
            var mgrSearcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfProc_Process");
            return mgrSearcher.Get().Cast<ManagementBaseObject>().Select(mobj => new ProcessItem(Convert.ToInt32(mobj["IDProcess"]), TrimString((string)mobj["Name"])));
        }

        static ProcessItem GetProcessItem(ManagementBaseObject mbo)
        {
            return new ProcessItem(Convert.ToInt32(mbo["processid"]), (string)mbo["name"]);
        }

        //尝试去掉进程名称中的#字符
        static string TrimString(string name)
        {
            var pos = name.IndexOf('#');
            if (pos != -1)
                return name.Substring(0, pos);
            return name;
        }

        public bool Update { get { return true; } }


    }
}
