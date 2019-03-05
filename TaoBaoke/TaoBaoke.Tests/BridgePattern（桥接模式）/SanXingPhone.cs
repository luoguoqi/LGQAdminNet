using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern_桥接模式_
{
    public class SanXingPhone : Phone
    {
        public override string RunSoftWare(SoftWare soft)
        {

            string msg = "三星手机开始运行";
            return msg + soft.Start();
        }

        public override string RunWeiChart()
        {
            return "三星手机开始运行【微信】";
        }

        public override string RunWangyiMusic()
        {
            return "三星手机开始运行【网易云音乐】";
        }
    }

}
