using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.TBKQuery
{
    /// <summary>
    /// 淘宝客商品查询请求参数
    /// </summary>
    public class TBKCommodityGetReq:TaoBaoKeBaseReq
    {
        /// <summary>
        /// 需返回的字段列表
        /// </summary>
        public string fields { get; set; }

        /// <summary>
        /// 查询词
        /// </summary>
        public string q { get; set; }

        /// <summary>
        /// 后台类目ID，用,分割，最大10个，该ID可以通过taobao.itemcats.get接口获取到
        /// </summary>
        public string cat { get; set; }

        /// <summary>
        /// 所在地 
        /// </summary>
        public string itemloc { get; set; }

        /// <summary>
        /// 排序_des（降序），排序_asc（升序），销量（total_sales），淘客佣金比率（tk_rate）， 累计推广量（tk_total_sales），总支出佣金（tk_total_commi）
        /// </summary>
        public string sort { get; set; }

        /// <summary>
        /// 是否商城商品，设置为true表示该商品是属于淘宝商城商品，设置为false或不设置表示不判断这个属性
        /// </summary>
        public bool is_tmall { get; set; }

        /// <summary>
        /// 是否海外商品，设置为true表示该商品是属于海外商品，设置为false或不设置表示不判断这个属性
        /// </summary>
        public bool is_overseas { get; set; }


        /// <summary>
        /// 折扣价范围下限，单位：元
        /// </summary>
        public int start_price { get; set; }

        /// <summary>
        /// 折扣价范围上限，单位：元
        /// </summary>
        public int end_price { get; set; }

        /// <summary>
        /// 淘客佣金比率上限，如：1234表示12.34%
        /// </summary>
        public int start_tk_rate { get; set; }


        /// <summary>
        /// 淘客佣金比率下限，如：1234表示12.34%
        /// </summary>
        public int end_tk_rate { get; set; }

        /// <summary>
        /// 链接形式：1：PC，2：无线，默认：１
        /// </summary>
        public int platform { get; set; }

        /// <summary>
        /// 第几页，默认：１
        /// </summary>
        public int page_no { get; set; }

        /// <summary>
        /// 页大小，默认20，1~100
        /// </summary>
        public int page_size { get; set; }
    }
}
