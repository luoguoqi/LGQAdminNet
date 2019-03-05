using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern_桥接模式_
{
    /// <summary>
    /// 软件接口类
    /// </summary>
    public abstract class SoftWare
    {
       /// <summary>
       /// 软件启动
       /// </summary>
        public abstract string Start();
    }
}
