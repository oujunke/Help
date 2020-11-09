using System;
using System.Collections.Generic;

namespace Help.Model
{
	// Token: 0x02000025 RID: 37
	public class CookDictionary : AutoDictionary<string, AutoDictionary<string, string>>
	{
		// Token: 0x1700002B RID: 43
		public override AutoDictionary<string, string> this[string key]
		{
			get
			{
				bool flag = base.ContainsKey(key);
				AutoDictionary<string, string> result;
				if (flag)
				{
					result = base[key];
				}
				else
				{
					AutoDictionary<string, string> autoDictionary = new AutoDictionary<string, string>();
					base.Add(key, autoDictionary);
					result = autoDictionary;
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

		// Token: 0x0600018C RID: 396 RVA: 0x00007038 File Offset: 0x00005238
		public string GetCookie(string name)
		{
			foreach (KeyValuePair<string, AutoDictionary<string, string>> keyValuePair in this)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in keyValuePair.Value)
				{
					bool flag = keyValuePair2.Key == name;
					if (flag)
					{
						return keyValuePair2.Value;
					}
				}
			}
			return null;
		}
	}
}
