using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace mgen_processes
{
    class UsingPerfmon : IAction
    {
        public bool Update { get { return true; } }

        //Process性能计数器类型
        PerformanceCounterCategory category =
            new PerformanceCounterCategory("Process");

        public IEnumerable<ProcessItem> GetProcesses()
        {
            return category.GetInstanceNames().Select(name =>
            {
                //ID Process性能计数器
                var counter = new PerformanceCounter("Process", "ID Process", name);
                //查询PID
                var id = counter.NextValue();
                return new ProcessItem((int)id, TrimString(name));
            });
        }

        //尝试去掉进程名称中的#字符
        static string TrimString(string name)
        {
            var pos = name.IndexOf('#');
            if (pos != -1)
                return name.Substring(0, pos);
            return name;
        }
    }
}
