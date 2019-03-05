using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.BaiDuQuery
{
    /// <summary>
    /// 文字识别返回结果
    /// </summary>
    public class WordRecognitionRes:BaseRes
    {
        public string log_id { get; set; }
        public string words_result_num { get; set; }
        /// <summary>
        /// 识别结果集
        /// </summary>
        public List<WordsResult> words_result { get; set; } = new List<WordsResult>();
    }

    public class WordsResult
    {
        /// <summary>
        /// 字符串在图片的位置
        /// </summary>
        public Location location { get; set; } = new Location();
        /// <summary>
        /// 结果字符串
        /// </summary>
        public string words { get; set; }
    }

    public class Location
    {

        public string width { get; set; }
        public string top { get; set; }
        public string height { get; set; }
        public string left { get; set; }
    }
}
