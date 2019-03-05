using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Model.TBKQuery
{

    /// <summary>
    ///  淘宝客商品查询返回参数
    /// </summary>
    public class TBKCommodityGetRes
    {
        public TBKCommodityGetRes()
        {
            tbk_Item_Get_Response = new tbk_item_get_response();
        }
        public tbk_item_get_response tbk_Item_Get_Response { get; set; }
    }

    #region tbk_item_get_response
    /// <summary>
    /// 淘宝客商品查询返回参数
    /// </summary>
    public class tbk_item_get_response
    {
        public tbk_item_get_response()
        {
            results = new Results();
        }


        public Results results { get; set; }

        /// <summary>
        /// 搜索到符合条件的结果总数
        /// </summary>
        public int total_results { get; set; }

        public string request_id { get; set; }

    }
    #endregion

    #region Results
    /// <summary>
    /// 返回结果集
    /// </summary>
    public class Results
    {
        
        public Results()
        {
            n_tbk_item = new List<n_tbk_item>();
        }
        public List<n_tbk_item> n_tbk_item { get; set; }
    }
    #endregion

    #region n_tbk_item
    /// <summary>
    /// 商品信息实体
    /// </summary>
    public class n_tbk_item
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string num_iid { get; set; }


        /// <summary>
        /// 商品标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 商品主图
        /// </summary>
        public string pict_url { get; set; }

        /// <summary>
        /// 商品小图列表
        /// </summary>
        public List<Small_Images> small_images { get; set; }

        /// <summary>
        /// 商品一口价格
        /// </summary>
        public string reserve_price { get; set; }

        /// <summary>
        /// 商品折扣价格
        /// </summary>
        public string zk_final_price { get; set; }

        /// <summary>
        /// 卖家类型，0表示集市，1表示商城
        /// </summary>
        public int user_type { get; set; }

        /// <summary>
        /// 宝贝所在地
        /// </summary>
        public string provcity { get; set; }

        /// <summary>
        /// 商品地址
        /// </summary>
        public string item_url { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string nick { get; set; }

        /// <summary>
        /// 卖家id
        /// </summary>
        public long seller_id { get; set; }

        /// <summary>
        /// 30天销量
        /// </summary>
        public long volume { get; set; }
    } 
    #endregion

    public class Small_Images
    {
        public string str { get; set; }
    }
}
