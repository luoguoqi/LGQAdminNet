using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern_桥接模式_
{
    public abstract class Phone
    {
        public abstract string RunSoftWare(SoftWare soft);
        interface IRunSoftWare
        {
            string RunSoftWare(SoftWare soft);
        }
        public abstract string RunWeiChart();

        public abstract string RunWangyiMusic();
    }
}
