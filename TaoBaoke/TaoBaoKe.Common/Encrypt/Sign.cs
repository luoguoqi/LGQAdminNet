using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Common.Encrypt
{
    public class Sign
    {

        public static string SignTopRequest(IDictionary<string, string> parameters ,string secret = "cbefeb58021ec20867ec4caa763a9c4f")
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();


            query.Append(secret);
            //if (Constants.SIGN_METHOD_MD5.Equals(signMethod))
            //{
            //    query.Append(secret);
            //}
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }

            // 第三步：使用MD5/HMAC加密
            byte[] bytes;
            //if (Constants.SIGN_METHOD_HMAC.Equals(signMethod))
            //{
            //    HMACMD5 hmac = new HMACMD5(Encoding.UTF8.GetBytes(secret));
            //    bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            //}
            //else
            //{
            //    query.Append(secret);
            //    MD5 md5 = MD5.Create();
            //    bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            //}

            query.Append(secret);
            MD5 md5 = MD5.Create();
            bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));

            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}
