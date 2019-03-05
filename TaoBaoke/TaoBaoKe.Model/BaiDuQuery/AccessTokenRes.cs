using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.BaiDuQuery
{
    /// <summary>
    /// 
    /// </summary>
    public class AccessTokenRes
    {
        public AccessTokenRes()
        {
        }

        /// <summary>
        /// 要获取的Access Token
        /// </summary>
        public string access_token { get; set; }
        public string session_key { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        public string session_secret { get; set; }
        /// <summary>
        ///  Access Token的有效期(秒为单位，一般为1个月)；
        /// </summary>
        public int  expires_in { get; set; }

    }
}
