using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.TBKQuery
{
    /// <summary>
    /// 淘宝客返利订单查询请求k
    /// </summary>
    public class TBKRebateOrderGetReq:TaoBaoKeBaseReq
    {
        /// <summary>
        /// 需返回的字段列表
        /// </summary>
        public string fields { get; set; }

        /// <summary>
        /// 订单结算开始时间
        /// </summary>
        public DateTime start_time { get; set; }

        /// <summary>
        /// 订单查询时间范围,单位:秒,最小60,最大600,默认60
        /// </summary>
        public int span { get; set; }

        /// <summary>
        /// 第几页，默认1，1~100
        /// </summary>
        public int page_no { get; set; }

        /// <summary>
        /// 页大小，默认20，1~100
        /// </summary>
        public int page_size { get; set; }

    }
}
