using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TaoBaoKe.Common;
using TaoBaoKe.Common.Http;
using TaoBaoKe.Common.Image;
using TaoBaoKe.Model.BaiDuQuery;

namespace TaoBaoKe.Service.BaiDuQuery
{
    /// <summary>
    /// 文字识别
    /// </summary>
    public class WordRecognition
    {
        #region 通用文字识别
        /// <summary>
        /// 通用文字识别
        /// </summary>
        /// <param name="strbaser64"></param>
        /// <returns></returns>
        public WordRecognitionRes BadDuWordRecognition(string strbaser64 = "", string url = "")
        {
            WordRecognitionRes wordRecognitionRes = new WordRecognitionRes();
            if (string.IsNullOrEmpty(strbaser64) && string.IsNullOrEmpty(url))
            {
                wordRecognitionRes.error_code = "001";
                wordRecognitionRes.error_message = "请求参数strbaser64和url不能同时为空";
            }
            string token = BaiduApiCommonService.GetBaiduAccessToken();
            // strbaser64 = new ImageService().GetBase64FromImage("D:\\代码\\LgqTest\\TaoBaoke\\TaoBaoke\\Image\\居住证正面.jpg"); // 图片的base64编码
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general?access_token=" + token;
            string date = "image=" + HttpUtility.UrlEncode(strbaser64);
            string result = HttpHelperMethod.Post(host, date);
            wordRecognitionRes = JsonConvert.DeserializeObject<WordRecognitionRes>(result);
            BadDuWordCustomTemplate(strbaser64, "e8aed3ff033e475be36ce2bf673d8186");
            return wordRecognitionRes;
        }
        #endregion


        #region 自定义模板识别
        /// <summary>
        /// 自定义模板识别
        /// </summary>
        /// <param name="strbaser64">字节流</param>
        /// <param name="templateType">模板类型</param>
        public CustomTemplateResult BadDuWordCustomTemplate(string strbaser64, string templateType)
        {
            //templateType = "e8aed3ff033e475be36ce2bf673d8186";//身份证
            string token = BaiduApiCommonService.GetBaiduAccessToken();
            string host = "https://aip.baidubce.com/rest/2.0/solution/v1/iocr/recognise?access_token=" + token;
            string date = "image=" + HttpUtility.UrlEncode(strbaser64);
            date += "&templateSign=" + HttpUtility.UrlEncode(templateType);
            CustomTemplateResult customTemplateRes = new CustomTemplateResult();
            string s = HttpHelperMethod.Post(host, date);
            customTemplateRes = JsonConvert.DeserializeObject<CustomTemplateResult>(s);
            if (customTemplateRes != null && customTemplateRes.data != null && customTemplateRes.data.ret.Any())
            {
                for (int i=0; i< customTemplateRes.data.ret.Count; i++)
                {
                    customTemplateRes.data.ret[i].charset = null;
                }
            }
            return customTemplateRes;
        }
        #endregion
    }
}
