using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model
{
    public class TaoBaoKeBaseReq
    {
        public TaoBaoKeBaseReq()
        {
            app_key = "24703799";
            sign_method = "md5";
            format = "json";
            timestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            v = "2.0";
        }

        /// <summary>
        /// API接口名称
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// TOP分配给应用的AppKey
        /// </summary>
        public string app_key { get; set; }

        /// <summary>
        /// 被调用的目标AppKey，仅当被调用的API为第三方ISV提供时有效
        /// </summary>
        public string target_app_key { get; set; }

        /// <summary>
        /// 签名的摘要算法，可选值为：hmac，md5
        /// </summary>
        public string sign_method { get; set; }

        /// <summary>
        /// API输入参数签名结果，签名算法介绍请
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 用户登录授权成功后，TOP颁发给应用的授权信息
        /// </summary>
        public string session { get; set; }

        /// <summary>
        /// 时间戳，格式为yyyy-MM-dd HH:mm:ss，时区为GMT+8
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 响应格式。默认为xml格式，可选值：xml，json
        /// </summary>
        public string format { get; set; }

        /// <summary>
        /// API协议版本，可选值：2.0
        /// </summary>
        public string v { get; set; }


        /// <summary>
        /// 合作伙伴身份标识
        /// </summary>
        public string partner_id { get; set; }


        /// <summary>
        /// 是否采用精简JSON返回格式，仅当format=json时有效，默认值为：false
        /// </summary>
        public bool simplify { get; set; }

    }
}
