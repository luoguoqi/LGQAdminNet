using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern_桥接模式_
{
    public class ApplePhone : Phone
    {
        public override string RunSoftWare(SoftWare soft)
        {
            string msg = "苹果手机开始运行";
            return msg + soft.Start();
        }

        public override string RunWeiChart()
        {
            return "微信已运行！";
        }

        public override string RunWangyiMusic()
        {
            return "网易云音乐已运行！";
        }
    }
}
