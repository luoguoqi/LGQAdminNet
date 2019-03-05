using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern
{
    /// <summary>
    /// 大杯
    /// </summary>
    public class LargeCup : Coffee
    {
        public override void Make()
        {
            MakeCoffee makeCoffee = this.MakeCoffee();
            Console.Write("大杯");
            makeCoffee.Making();
        }
    }
}
