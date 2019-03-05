using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaoBaoKe.Service.TBKQuery;
using TaoBaoKe.Model.TBKQuery;
using TaoBaoKe.Common;
using TaoBaoKe.Service.BaiDuQuery;
using TaoBaoKe.Service.Design;
using TaoBaoke.Tests.BridgePattern;
using TaoBaoke.Tests.test1;
using TaoBaoKe.Service.WeChat;

namespace TaoBaoke.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int type = 2;

            new WeChatPush().PushMsg();
            #region 设计模式

            #region 工厂模式
            //string customer1 = Customer.GetFood("西红柿炒蛋");
            //string customer2 = Customer.Main("土豆丝");
            //string customer3 = Customer.Main3("西红柿炒蛋");
            #endregion

            #region 桥接模式
            //Phone phone;
            //phone = new ApplePhone();
            //string s1 = phone.Run(new RunQQ());
            #endregion
            #endregion


            #region 秘密

            #region 文档识别
            // BaiduApiCommonService.GetBaiduAccessToken();
            //new WordRecognition().BadDuWordRecognition(); 
            #endregion
            switch (type)
            {
                case 1:
                    //商品查询
                    TBKCommodityGetRes result = new TBKQueryService().TBKCommodityGet();
                    break;

                case 2:
                    ///淘宝客返利订单查询
                    TBKRebateOrderGetRes result1 = new TBKQueryService().TBKRebateOrderGet();
                    break;

                default:
                    break;
            }
            #endregion




        }



    }

}
