using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaoBaoKe.Common.Cache;
using TaoBaoKe.Common.Const;
using TaoBaoKe.Model.BaiDuQuery;

namespace TaoBaoKe.Common
{
    /// <summary>
    /// 百度API公共方法
    /// </summary>
    public class BaiduApiCommonService
    {
        #region 获取百度AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetBaiduAccessToken()
        {
            string access_token = "";
            var baiduAccessToken = CacheHelper.GetCache("BaiduAccessToken");
            if (baiduAccessToken != null && !string.IsNullOrEmpty(baiduAccessToken.ToString()))
            {
                access_token = baiduAccessToken.ToString();
                return access_token;
            }
            else
            {
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", ApiConfigConst.BaiduWordAppKey));
                paraList.Add(new KeyValuePair<string, string>("client_secret", ApiConfigConst.BaiduWordAppSecret));

                HttpResponseMessage response = client.PostAsync(ApiConfigConst.AuthorizedAddress, new FormUrlEncodedContent(paraList)).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                AccessTokenRes accessTokenRes = new AccessTokenRes();
                accessTokenRes = JsonConvert.DeserializeObject<AccessTokenRes>(result);
                access_token = accessTokenRes.access_token;
                if (!string.IsNullOrEmpty(access_token))
                {
                    //设置30天过期
                    CacheHelper.SetCache("BaiduAccessToken", access_token, 30 * 24 * 60);
                }
                return access_token;
            }
        }
        #endregion
    }
}

