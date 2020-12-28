using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
