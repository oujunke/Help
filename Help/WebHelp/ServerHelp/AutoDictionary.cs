using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Help.WebHelp.ServerHelp
{
    public class AutoDictionary<T1, T2> : Dictionary<T1, T2>
    {
        public new T2 this[T1 key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return base[key];
                }
                else
                {
                    return default(T2);
                }
            }
            set
            {
                if (ContainsKey(key))
                {
                    base[key] = value;
                }
                else
                {
                    base.Add(key, value);
                }
            }
        }
    }
}
