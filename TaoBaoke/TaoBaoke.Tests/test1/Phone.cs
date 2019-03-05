
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoke.Tests.test1
{
    public abstract class Phone
    {
        public abstract string Run(Ruanjian ruanjian);

        public static implicit operator Phone(ApplePhone v)
        {
            throw new NotImplementedException();
        }
    }
    interface IRun
    {
          string Run(Ruanjian ruanjian);
    }
}
