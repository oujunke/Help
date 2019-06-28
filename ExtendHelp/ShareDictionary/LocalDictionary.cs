using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ExtendHelp.ShareDictionary
{
    public class LocalDictionary
    {
        private static Dictionary<string, string> dictionary;
        static LocalDictionary()
        {
            
            GCHandle h = GCHandle.Alloc(dictionary, GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
        }
    }
}
