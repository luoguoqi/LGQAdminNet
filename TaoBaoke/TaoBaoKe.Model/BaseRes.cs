using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model
{
    /// <summary>
    /// 接口返回参数积累
    /// </summary>
    public class BaseRes
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
    }
}
