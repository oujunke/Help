using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;


namespace Help.WebHelp.HtmlHelp
{
    public static class FromHelp
    {
        #region 生成表单的提交按钮
        /// <summary>
        /// 生成表单的提交按钮,name为按钮的名字，Vaule为值，即为按钮的显示值
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <param name="vaule"></param>
        /// <returns></returns>
        public static string Submit(this HtmlHelper html, string name = "submit", string vaule = "提交")
        {
            return Submit(null, name, vaule);
        }
        /// <summary>
        /// 生成表单的提交按钮,htmlAttribut为附加参数（比如Id等等）name为按钮的名字，Vaule为值，即为按钮的显示值
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttribut"></param>
        /// <param name="name"></param>
        /// <param name="vaule"></param>
        /// <returns></returns>
        public static string Submit(this HtmlHelper html, object htmlAttribut,string name = "submit", string vaule = "提交")
        {
            return Submit(htmlAttribut,name,vaule);
        }
        /// <summary>
        /// 生成表单的提交按钮,htmlAttribut为附加参数（比如Id等等）name为按钮的名字，Vaule为值，即为按钮的显示值
        /// </summary>
        /// <param name="htmlAttribut"></param>
        /// <param name="name"></param>
        /// <param name="vaule"></param>
        /// <returns></returns>
        public static string Submit(object htmlAttribut, string name = "submit", string vaule = "提交")
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("vaule", vaule);
            builder.MergeAttribute("name", name);
            if (htmlAttribut != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttribut));
            }
            return builder.ToString();
        }
        #endregion
    }
}
