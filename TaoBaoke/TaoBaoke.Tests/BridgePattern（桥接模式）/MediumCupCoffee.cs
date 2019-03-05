using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern
{

    /// <summary>
    /// 中杯
    /// </summary>
    public class MediumCup : Coffee
    {
        public override void Make()
        {
            MakeCoffee makeCoffee = this.MakeCoffee();
            Console.Write("中杯");
            makeCoffee.Making();
        }
    }
}
