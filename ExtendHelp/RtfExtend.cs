using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExtendHelp
{
	public static class RtfExtend
	{
		public static Rtf AddRtf(this Rtf rtf, string str, params Color[] rtfColors)
		{
			int i = 0;
			var color = rtfColors.ToDictionary(c => i++);
			var ss = str.Split("@",true);
			i = 0;
			ss.ForEachT(s =>
			{
				var v = s.RegexGetString(@"@(\d*)");
				if (int.TryParse(v, out int key) && color.ContainsKey(key))
				{
					rtf.AddColorText(s.Substring(("@" + key).Length), color[key]);
				}
				else
				{
					rtf.AddColorText(s, Color.Black);
				}
			});
			return rtf;
		}
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="rtf"></param>
		/// <param name="str"></param>
		/// <param name="ss"></param>
		/// <param name="rcs"></param>
		/// <returns></returns>
		public static Rtf AddRtf(this Rtf rtf, string str, string[] ss, Color[] rcs)
		{
			var sss = str.Split("@");
			sss.ForEachT(s =>
			{
				var v = s.RegexGetString(@"@(\d*)");
				if (int.TryParse(v, out int key))
				{
					string v1 = s;
					Color c = Color.Black;
					if (key >= 0)
					{
						if (ss.Length > key)
						{
							v1 = s.Replace("@" + key, ss[key]);
						}
						if (rcs.Length > key)
						{
							c = rcs[key];
						}
					}
					rtf.AddColorText(v1, c);
				}
				else
				{
					rtf.AddColorText(s, Color.Black);
				}
			});
			return rtf;
		}
		/// <summary>
		/// 添加加红信息
		/// </summary>
		/// <param name="rtf"></param>
		/// <param name="str"></param>
		/// <param name="ss"></param>
		/// <returns></returns>
		public static Rtf AddRtf(this Rtf rtf, string str, params object[] ss)
		{
			var sss = str.Split("@");
			sss.ForEachT(s =>
			{
				var v = s.RegexGetString(@"@(\d*)");
				if (int.TryParse(v, out int key))
				{
					string v1 = s;
					if (key >= 0)
					{
						if (ss.Length > key)
						{
							switch (ss[key])
							{
								case Rtf r:
									rtf.AddRtf(r);
									break;
								default:
									rtf.AddColorText(ss[key].ToString(), Color.Red,18);
									break;
							}
							v1 = s.Substring(("@" + key).Length);
						}
					}
					rtf.AddColorText(v1, Color.Black);
				}
				else
				{
					rtf.AddColorText(s, Color.Black);
				}
			});
			return rtf;
		}
	}
}
