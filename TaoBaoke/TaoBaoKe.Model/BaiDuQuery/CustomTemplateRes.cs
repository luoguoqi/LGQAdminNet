using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.BaiDuQuery
{
    #region 自定义类

    ///// <summary>
    /////百度自定义模板返回类
    ///// </summary>
    //public class CustomTemplateRes : BaseRes
    //{
    //    public CustomTemplateResult date { get; set; } = new CustomTemplateResult();

    //    public string error_code { get; set; }

    //    public string error_msg { get; set; }
    //}

    //public class CustomTemplateResult
    //{
    //    public List<Result> ret { get; set; } = new List<Result>();
    //    public string isStructured { get; set; }

    //    public string logId { get; set; }
    //}

    ///// <summary>
    ///// 返回结果皆
    ///// </summary>
    //public class Result
    //{
    //    public List<CharsetResult> charset { get; set; } = new List<CharsetResult>();

    //    public string word_name { get; set; }

    //    public string word { get; set; }

    //}

    //public class CharsetResult
    //{
    //    /// <summary>
    //    /// 字符串在图片的位置
    //    /// </summary>
    //    public Location rect { get; set; } = new Location();
    //    /// <summary>
    //    /// 结果字符串
    //    /// </summary>
    //    public string word { get; set; }
    //} 
    #endregion
    public class Rect
    {
        /// <summary>
        /// 
        /// </summary>
        public int top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
    }

    public class CharsetItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Rect rect { get; set; }
        /// <summary>
        /// 淮
        /// </summary>
        public string word { get; set; }
    }

    public class RetItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<CharsetItem> charset { get; set; }
        /// <summary>
        /// 签发机关
        /// </summary>
        public string word_name { get; set; }
        /// <summary>
        /// 淮南市公安局田家庵分局
        /// </summary>
        public string word { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<RetItem> ret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isStructured { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string logId { get; set; }
    }

    public class CustomTemplateResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int error_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error_msg { get; set; }
    }


}



