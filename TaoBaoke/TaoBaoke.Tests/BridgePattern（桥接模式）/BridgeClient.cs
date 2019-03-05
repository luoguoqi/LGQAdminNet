using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoBaoke.Tests.BridgePattern_桥接模式_;

namespace TaoBaoke.Tests.BridgePattern
{
    public class BridgeClient
    {
        public static void Main()
        {
            //MakeCoffeeSingleton whiteCoffeeSingleton = new MakeCoffeeSingleton(new WhiteCoffee());

            //// 中杯白咖啡
            //MediumCup mediumWhiteCoffee = new MediumCup();
            //mediumWhiteCoffee.Make();

            //// 大杯白咖啡
            //LargeCup largeCupWhiteCoffee = new LargeCup();
            //largeCupWhiteCoffee.Make();

            //MakeCoffeeSingleton blackCoffeeSingleton = new MakeCoffeeSingleton(new BlackCoffee());
            //// 中杯黑咖啡
            //MediumCup mediumBlackCoffee = new MediumCup();
            //mediumBlackCoffee.Make();

            //// 大杯白咖啡
            //LargeCup largeCupBlackCoffee = new LargeCup();
            //largeCupBlackCoffee.Make();

            Phone phone;
            phone = new SanXingPhone();
            string s1 = phone.RunSoftWare(new WeiChart());
            string s2 = phone.RunSoftWare(new WangyiMusic());
            string s3 = phone.RunWeiChart();
            string s4 = phone.RunWangyiMusic();

        }
    }
}
