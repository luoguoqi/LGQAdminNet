using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Service
{
    public class Single
    {
        // 定义一个静态变量来保存类的实例
        private static Single uniqueTest;

        // 定义私有构造函数，使外界不能创建该类实例
        private Single()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Single GetSingle()
        {

            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueTest == null)
            {
                uniqueTest = new Single();
            }
            return uniqueTest;
        }





    }
}
