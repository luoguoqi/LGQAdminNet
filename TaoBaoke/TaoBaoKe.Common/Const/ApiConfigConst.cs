using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Common.Const
{
    public class ApiConfigConst
    {
        #region 淘宝客相关配置
        /// <summary>
        /// 正式环境地址
        /// </summary>
        public const string ApiUrlConfigPro = "http://gw.api.taobao.com/router/rest";

        /// <summary>
        /// 沙箱环境地址
        /// </summary>
        public const string ApiUrlConfigStage = "http://gw.api.tbsandbox.com/router/rest";

        /// <summary>
        /// AppKey
        /// </summary>
        public const string AppKey = "24703799";

        /// <summary>
        /// AppSecret
        /// </summary>
        public const string AppSecret = "cbefeb58021ec20867ec4caa763a9c4f";
        #endregion

        #region 百度文字识别配置

        /// <summary>
        /// 正式环境地址
        /// </summary>
        public const string BaiduWordApiUrlConfigPro = "http://gw.api.taobao.com/router/rest";

        /// <summary>
        /// AppKey
        /// </summary>
        public const string BaiduWordAppKey = "iSG1FqNP3W0GGcdzsKrBpCiC";

        /// <summary>
        /// AppSecret
        /// </summary>
        public const string BaiduWordAppSecret = "8rIkLubo3E6n87QehkEo62EvUkxGdL5D";
        #endregion

        #region 百度公共配置

        /// <summary>
        /// 授权服务地址
        /// </summary>
        public const string AuthorizedAddress = "https://aip.baidubce.com/oauth/2.0/token";
        #endregion

        #region 微信公众号相关配置


        /// <summary>
        /// AppKey
        /// </summary>
        public const string WeChatAppID = "wxd0a5d6b18cd86592";

        /// <summary>
        /// AppSecret
        /// </summary>
        public const string WeChatAppSecret = "a514225db3fd2fa3472aaabb6fa1e4a3";
        #endregion
    }
}
