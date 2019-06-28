using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mgen_processes
{
    public class ProcessItem
    {
        public int Pid { get; private set; }
        public string Name { get; private set; }

        public ProcessItem(int id, string name)
        {
            Pid = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((ProcessItem)obj).Pid == Pid;
        }

        public override int GetHashCode()
        {
            return Pid.GetHashCode();
        }
    }
}
