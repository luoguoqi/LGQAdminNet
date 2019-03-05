using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern
{
    /// <summary>
    /// 白咖啡
    /// </summary>
    public class WhiteCoffee : MakeCoffee
    {
        public override void Making()
        {
            Console.WriteLine("白咖啡");
        }
    }
}
