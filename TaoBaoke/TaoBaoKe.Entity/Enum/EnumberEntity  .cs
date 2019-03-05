using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Entity.Enum
{
    /// <summary>
    /// 枚举公共类
    /// </summary>
   public class EnumberEntity
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Desction { set; get; }

        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string EnumName { set; get; }

        /// <summary>  
        /// 枚举对象的值  
        /// </summary>  
        public int EnumValue { set; get; }
    }
}
