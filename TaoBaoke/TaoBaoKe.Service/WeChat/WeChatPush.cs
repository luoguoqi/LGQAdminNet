using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoBaoKe.Common;
using TaoBaoKe.Common.Const;

namespace TaoBaoKe.Service.WeChat
{
    public class WeChatPush
    {
        public string PushMsg()
        {
            //模板ID                   0AI1R_RWcY-gxfU57El-r7iOr8-aQOgCyTgrOiOqWp0 开票提醒
            //开发者ID(AppID)          wx37f7ad5ea8d57ffa
            //开发者密码(AppSecret)    d3049416a70dcc631c0bd1f8f4ecfdba
            //我的 openID              oXhYxs6xEvWnJR0sqvhkUh9JUHoA
            //WeChatApiCommonService.GetWeChatAccessToken();
            //根据appId判断获取  
            //if (!AccessTokenContainer.CheckRegistered(ApiConfigConst.WeChatAppID))    //检查是否已经注册  
            //{
            //    AccessTokenContainer.Register(ApiConfigConst.WeChatAppID, ApiConfigConst.WeChatAppSecret);    //如果没有注册则进行注册  
            //}

            //string access_token = AccessTokenContainer.GetAccessTokenResult(ApiConfigConst.WeChatAppID).access_token; //AccessToken
            string access_token = "15_eJHYeCbl20cD0KLsgSHun0Z9vykSZmXpu8UdaIQ7LNd-ausM6guuGjg3ui12J6aKyCl8cvyaT1xVsIJpfQHd9hUCKMVRJbaolMsTrbfCZSMjM0OkBEMRz8Cv6kSNt9U1NBAlAjqqs2Sf5EmGVTAiAGANLS";
            string openId = "oXhYxs6xEvWnJR0sqvhkUh9JUHoA";   //用户openId
            string templateId = "0AI1R_RWcY-gxfU57El-r7iOr8-aQOgCyTgrOiOqWp0";   //模版id
            string linkUrl = "http://www.baidu.com";    //点击详情后跳转后的链接地址，为空则不跳转

            //您好，您的发票已经开具成功。
            //发票号码：NO9000001
            //开票日期：2017 - 06 - 18
            //开票金额：890.00
            //点击查看详情

            //为模版中的各属性赋值
            var templateData = new ProductTemplateData()
            {
                first = new TemplateDataItem("您好，您的发票\r\n已经开具成功。", "#000000"),
                keyword1 = new TemplateDataItem("NO9000001", "#000000"),
                keyword2 = new TemplateDataItem("2017 - 06 - 18", "#000000"),
                keyword3 = new TemplateDataItem("890.00", "#000000"),
                remark = new TemplateDataItem("感谢您的光临~", "#000000")
            };
            
            SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, templateId, linkUrl, templateData);

            //发送成功
            if (sendResult.errcode.ToString() == "请求成功")
            {
                //...
            }
            else
            {
                //Response.Write("出现错误：" + sendResult.errmsg);
            }

            
            return "";
        }
        /// <summary>
        /// 定义模版中的字段属性（需与微信模版中的一致）
        /// </summary>
        public class  ProductTemplateData
        {
            public TemplateDataItem first { get; set; }
            public TemplateDataItem keyword1 { get; set; }
            public TemplateDataItem keyword2{ get; set; }

            public TemplateDataItem keyword3 {get; set; }
            public TemplateDataItem remark { get; set; }
        }
    }
}
