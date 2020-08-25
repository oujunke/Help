using System;
using System.Collections.Generic;

namespace Help.Model
{
	// Token: 0x0200002B RID: 43
	public class AutoDictionary<T1, T2> : Dictionary<T1, T2>
	{
		// Token: 0x1700002D RID: 45
		public new virtual T2 this[T1 key]
		{
			get
			{
				bool flag = base.ContainsKey(key);
				T2 result;
				if (flag)
				{
					result = base[key];
				}
				else
				{
					result = default(T2);
				}
				return result;
			}
			set
			{
				bool flag = base.ContainsKey(key);
				if (flag)
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
