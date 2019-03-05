using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern_桥接模式_
{
    /// <summary>
    /// 微信软件类
    /// </summary>
    public class WeiChart : SoftWare
    {
        public override string Start()
        {
            return "【微信】";
        }
    }
}
