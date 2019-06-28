using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.DataHelp.SqlServerHelp
{
    public static class SqlTypeHelp
    {
        #region 把SQL SERVER类型的字符串转化成C#类型
        /// <summary>
        /// 把SQL SERVER类型的字符串转化成C#类型
        /// </summary>
        /// <param name="type">SQL SERVER类型的字符串</param>
        /// <returns>C#类型</returns>
        public static Type SqlTypeToType(string type)
        {
            switch (type)
            {
                case "int":
                    return typeof(Int32);
                case "bigint":
                    return typeof(Int64);
                case "smallint":
                    return typeof(Int16);
                case "real":
                    return typeof(System.Single);
                case "tinyint":
                    return typeof(System.Byte);
                case "uniqueidentifier":
                    return typeof(System.Guid);
                case "image":
                case "varbinary":
                case "binary":
                    return typeof(System.Byte[]);
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar":
                    return typeof(String);
                case "bit":
                    return typeof(Boolean);
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return typeof(System.DateTime);
                case "float":
                    return typeof(System.Double);
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    return typeof(System.Decimal);
                default:
                    return typeof(object);
            }
        }
        #endregion
        #region 把SQL SERVER类型的字符串转化成C#类型的字符串
        /// <summary>
        /// 把SQL SERVER类型的字符串转化成C#类型的字符串
        /// </summary>
        /// <param name="type">SQL SERVER类型的字符串</param>
        /// <returns>C#类型的字符串</returns>
        public static String SqlTypeStringToTypeString(string type)
        {
            switch (type)
            {
                case "int":
                    return "Int32";
                case "bigint":
                    return "Int64";
                case "smallint":
                    return "Int16";
                case "real":
                    return "System.Single";
                case "tinyint":
                    return "System.Byte";
                case "uniqueidentifier":
                    return "System.Guid";
                case "image":
                case "varbinary":
                case "binary":
                    return "System.Byte[]";
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar":
                    return "String";
                case "bit":
                    return "Boolean";
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return "System.DateTime";
                case "float":
                    return "System.Double";
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    return "System.Decimal";
                default:
                    return "object";
            }
        }
        #endregion
    }
}
