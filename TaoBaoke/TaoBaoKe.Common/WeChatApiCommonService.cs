using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoBaoKe.Common.Cache;
using TaoBaoKe.Common.Const;

namespace TaoBaoKe.Common
{
    /// <summary>
    /// 微信接口相关公共类
    /// </summary>
    public static class WeChatApiCommonService
    {
        #region 获取WXAccessToken
        public static string GetWeChatAccessToken()
        {
            
           string access_token = "";
            var wechatAccessToken = CacheHelper.GetCache("WeChatAccessToken");
            if (wechatAccessToken != null && !string.IsNullOrEmpty(wechatAccessToken.ToString()))
            {
                access_token = wechatAccessToken.ToString();
                return access_token;
            }
            else
            {
                access_token = AccessTokenContainer.TryGetAccessToken(ApiConfigConst.WeChatAppID, ApiConfigConst.WeChatAppSecret);
                if (!string.IsNullOrEmpty(access_token))
                {
                    //设置30天过期
                    CacheHelper.SetCache("WeChatAccessToken", access_token, 30 * 24 * 60);
                }
            }
            return access_token;
        }
        #endregion
    }
}
