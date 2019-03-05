using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.BridgePattern
{
    public abstract class Coffee
    {
        private MakeCoffee _makeCoffee;

        public Coffee()
        {
            _makeCoffee = MakeCoffeeSingleton.Instance();
        }

        public MakeCoffee MakeCoffee()
        {
            return this._makeCoffee;
        }

        public abstract void Make();
    }
}
