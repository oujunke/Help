using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace mgen_processes
{
    public interface IAction
    {
        IEnumerable<ProcessItem> GetProcesses();

        bool Update { get; }
    }

}
