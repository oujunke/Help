using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace mgen_processes
{
    class UsingProcess : IAction
    {
        public IEnumerable<ProcessItem> GetProcesses()
        {
            return Process.GetProcesses().Select(p => new ProcessItem(p.Id, p.ProcessName));
        }

        public bool Update { get { return true; } }
    }
}
