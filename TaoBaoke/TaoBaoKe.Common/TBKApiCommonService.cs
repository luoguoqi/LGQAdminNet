using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoBaoKe.Common.Const;
using TaoBaoKe.Common.Encrypt;
using TaoBaoKe.Common.Http;
using TaoBaoKe.Model;

namespace TaoBaoKe.Common
{
    /// <summary>
    /// 公共参数赋值
    /// </summary>
    public class TBKApiCommonService
    {
        #region 组装请求参数队列

        /// <summary>
        /// 组装请求参数队列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public Tuple<Dictionary<string, string>, string> GetProperties<T>(T t)
        {
            string tStr = string.Empty;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Tuple<Dictionary<string, string>, string> tuple = new Tuple<Dictionary<string, string>, string>(dictionary, "");

            if (t == null)
            {
                return tuple;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tuple;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (value == null || value.ToString() == "0" || value.ToString() == "False")
                {
                    continue;
                }
                //if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                //{

                //}
                //else
                //{
                //    GetProperties(value);
                //}
                dictionary.Add(name, value.ToString());
                tStr += string.Format("{0}={1}&", name, value);
            }
            return new Tuple<Dictionary<string, string>, string>(dictionary, tStr);
        }
        #endregion


        #region 拼装请求URL和接口验证Sign签名
        /// <summary>
        /// 拼装请求URL和接口验证Sign签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public Tuple<string, string> GetReqUrlAndSign<T>(T t)
        {
            Tuple<string, string> reqUrlAndSign = new Tuple<string, string>("", "");
            string sign = "";
            string reqUrl = "";
            Tuple<Dictionary<string, string>, string> tuple = new Tuple<Dictionary<string, string>, string>(new Dictionary<string, string>(), "");
            tuple = new TBKApiCommonService().GetProperties(t);
            //获取Sign的值
            sign = Sign.SignTopRequest(tuple.Item1);
            reqUrl = ApiConfigConst.ApiUrlConfigPro + "?" + tuple.Item2 + "sign=" + sign;
            reqUrlAndSign = new Tuple<string, string>(reqUrl, sign);
            return reqUrlAndSign;
        }
        #endregion


        #region 用Get方式请求接口，返回字符串
        /// <summary>
        ///  用Get方式请求接口，返回字符串
        /// </summary>
        /// <param name="reqUrl"></param>
        /// <returns></returns>
        public string ReqApiByGet(string reqUrl)
        {
            string result = string.Empty;
            result = HttpHelperMethod.Get(reqUrl);
            return result;
        }
        #endregion
    }
}
