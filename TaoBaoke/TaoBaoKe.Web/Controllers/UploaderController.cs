using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoBaoKe.Common.Enum;
using TaoBaoKe.Common.Image;
using TaoBaoKe.Entity.Enum;
using TaoBaoKe.Model.BaiDuQuery;
using TaoBaoKe.Service.BaiDuQuery;
using static TaoBaoKe.Entity.Enum.BaiDuWordEnum;

namespace TaoBaoKe.Web.Controllers
{
    public class UploaderController : Controller
    {
        // GET: Uploader
        public ActionResult UploaderView()
        {
            ViewBag.CustomTemplate = EnumHelper.EnumToList<CustomTemplate>();
            return View();
        }


        // GET: Uploader
        public string GetSelect()
        {
            var selectStr = EnumHelper.EnumToList<CustomTemplate>();
            return JsonConvert.SerializeObject(selectStr);
        }

        public string UploaderFile(string type)
        {
            string result = "";
            Stream ms = null;//上传的图片流
            string strbaser64 = "";
            string templateType = EnumHelper.GetDescription((CustomTemplate)Enum.Parse(typeof(CustomTemplate), type));//识别的证件类型
            var fs = Request.Files;
            if (fs.Count > 0)
            {
                result = fs["file"].FileName;
                ms = fs["file"].InputStream;
                byte[] arr = new byte[ms.Length];

                strbaser64 = new ImageService().GetBase64FromImageStream(ms);
                //WordRecognitionRes wordRecognitionRes = new WordRecognitionRes();
                //wordRecognitionRes= new WordRecognition().BadDuWordRecognition(strbaser64);
                //if (wordRecognitionRes != null && wordRecognitionRes.words_result != null && wordRecognitionRes.words_result.Any())
                //{
                //    return JsonConvert.SerializeObject(wordRecognitionRes);
                //}
                CustomTemplateResult customTemplateRes = new CustomTemplateResult();
                customTemplateRes = new WordRecognition().BadDuWordCustomTemplate(strbaser64, templateType);
                if (customTemplateRes != null && customTemplateRes.data != null && customTemplateRes.data.ret.Any())
                {
                    return JsonConvert.SerializeObject(customTemplateRes.data);
                }
            }
            return "false";
        }
    }
}