using System;

namespace TaoBaoKe.Service.Design
{
    /// <summary>
    /// 自己做饭的情况【顾客】
    /// 没有简单工厂之前，客户想吃什么菜只能自己炒的
    /// </summary>
    public class Customer
    {
        #region 点菜1（无工厂）【自己跟自己点菜】
        /// <summary>
        /// 点菜1（无工厂）【自己跟自己点菜】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFood(string type)
        {
            //西红柿炒鸡蛋
            //土豆肉丝
            //点菜【type菜名】
            string food = Cook(type);
            return food;
        }
        #endregion

        #region 点菜2（简单工厂）【自己跟餐馆点菜】
        /// <summary>
        /// 点菜2（简单工厂）【自己跟餐馆点菜】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Main(string type)
        {
            // 客户想点一个西红柿炒蛋        
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
            food1.Print();

            // 客户想点一个土豆肉丝
            Food food2 = FoodSimpleFactory.CreateFood("土豆丝");
            food2.Print();

            return food2.Print();
        }
        #endregion

        #region 点菜3（工厂方法）【自己跟餐馆点菜】
        /// <summary>
        /// 点菜3（工厂方法）【自己跟餐馆点菜】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Main3(string type)
        {
            // 初始化做菜的两个工厂（土豆丝和西红柿炒蛋）
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoddFactory();
            tomatoScrambleEggs.Print();

            //开始做土豆肉丝
            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoddFactory();
            shreddedPorkWithPotatoes.Print();

            return shreddedPorkWithPotatoes.Print(); ;
        }
        #endregion

        #region 炒菜【客人自己烧菜方法】

        /// <summary>
        /// 客人自己烧菜方法
        /// </summary>
        /// <returns></returns>
        public static string Cook(string type)
        {
            
            ///Food food = null;
            string food = "";
            if (type.Equals("西红柿炒蛋"))
            {

                food = "西红柿"+ "鸡蛋";
            }
            else if (type.Equals("土豆丝"))
            {
                food = "削土豆"+"切丝"+"放油"+ "下锅炒";
            }
            return food;
        }
        #endregion
    }

    #region 餐馆，负责 炒菜

    /// <summary>
    /// 简单工厂类, 负责 炒菜
    /// </summary>
    public class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type.Equals("土豆丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }
            else if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (type.Equals("肉末茄子"))
            {
                food = new MincedMeatEggplant();
            }
            return food;
        }
    }
    #endregion

    #region 菜、汤（抽象产品类）
    /// <summary>
    /// 菜抽象类
    /// </summary>
    public abstract class Food
    {
        // 输出点了什么菜
        public abstract string Print();
    }

    /// <summary>
    /// 汤抽象类
    /// </summary>
    public abstract class Soup
    {
        // 输出点了什么汤
        public abstract string Print();
    }
    #endregion

    #region 菜（具体的产品类）

    /// <summary>
    /// 西红柿炒鸡蛋
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override string Print()
        {
            return "西红柿炒蛋";
        }
    }

    /// <summary>
    /// 西红柿炒鸡蛋
    /// </summary>
    public class TomatoScrambledEggsSoup : Soup
    {
        public override string Print()
        {
            return "西红柿蛋汤";
        }
    }


    /// <summary>
    /// 土豆丝
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override string Print()
        {
            return "土豆丝";
        }
    }

    /// <summary>
    /// 肉末茄子
    /// </summary>
    public class MincedMeatEggplant : Food

    {
        public override string Print()
        {
            return "肉末茄子";
        }
    }
    #endregion




    #region 工厂（抽象工厂类）
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        // 工厂方法
        public abstract Food CreateFoddFactory();

        // 工厂方法
      //  public abstract Soup CreateSoupFactory();
    }
    #endregion

    #region 菜（具体的工厂类）
    /// <summary>
    /// 西红柿炒蛋工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }

        ///// <summary>
        ///// 负责创建西红柿炒蛋这道菜
        ///// </summary>
        ///// <returns></returns>
        //public override Soup CreateSoupFactory()
        //{
        //    return new TomatoScrambledEggsSoup();
       // }
    }

    /// <summary>
    /// 土豆肉丝工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }

    /// <summary>
    /// 肉末茄子工厂类
    /// </summary>
    public class MincedMeatEggplantFactory : Creator
    {
        /// <summary>
        /// 负责创建肉末茄子这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new MincedMeatEggplant();
        }
    } 
    #endregion





}
