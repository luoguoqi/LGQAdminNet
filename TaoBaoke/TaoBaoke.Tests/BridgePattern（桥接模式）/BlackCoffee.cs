using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern
{
    /// <summary>
    /// 黑咖啡
    /// </summary>
    public class BlackCoffee : MakeCoffee
    {
        public override void Making()
        {
            Console.WriteLine("黑咖啡");
        }
    }
}
