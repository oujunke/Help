using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class ResultInfo<T>: ResultInfo
    {
        public T Data { set; get; }
    }
    public class ResultInfo
    {
        public bool? Status { set; get; }
        public string Message { set; get; }
    }
}
