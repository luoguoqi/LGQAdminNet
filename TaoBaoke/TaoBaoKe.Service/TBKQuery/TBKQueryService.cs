using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoBaoKe.Common;
using TaoBaoKe.Common.Const;
using TaoBaoKe.Common.Encrypt;
using TaoBaoKe.Common.Http;
using TaoBaoKe.Model.TBKQuery;

namespace TaoBaoKe.Service.TBKQuery
{
    /// <summary>
    /// 淘宝客商品查询服务
    /// </summary>
    public class TBKQueryService
    {
        #region taobao.tbk.item.get (淘宝客商品查询)
        /// <summary>
        /// 淘宝客商品查询
        /// </summary>
        /// <returns></returns>
        public TBKCommodityGetRes TBKCommodityGet()
        {
            TBKCommodityGetReq req = new TBKCommodityGetReq();
            TBKCommodityGetRes tBKCommodityGetRes = new TBKCommodityGetRes();
            Tuple<string, string> tuple = new Tuple<string, string>("", "");
            req.method = "taobao.tbk.item.get";
            req.fields = "num_iid,title,pict_url,reserve_price,zk_final_price,user_type,provcity,item_url,seller_id,volume,nick,tk_rate";
            req.q = "女装";
            req.cat = "16,18";
            req.itemloc = "杭州";
            req.sort = "tk_rate_des";
            //req.is_tmall = false;
            //req.is_overseas = false;
            //req.start_price = 10;
            //req.end_price = 10;
            //req.start_tk_rate = 123;
            //req.end_tk_rate = 123;
            //req.platform = 1;
            //req.page_no = 1;
            //req.page_size = 20;
            tuple = new TBKApiCommonService().GetReqUrlAndSign(req);
            req.sign = tuple.Item2;
            string result = "";
            result = new TBKApiCommonService().ReqApiByGet(tuple.Item1);
            if (!string.IsNullOrWhiteSpace(result))
            {
                string json = JsonConvert.SerializeObject(tBKCommodityGetRes);
                tBKCommodityGetRes = JsonConvert.DeserializeObject<TBKCommodityGetRes>(result);
            }
            return tBKCommodityGetRes;
        }
        #endregion

        #region taobao.tbk.rebate.order.get (淘宝客返利订单查询)

        /// <summary>
        /// taobao.tbk.rebate.order.get (淘宝客返利订单查询)
        /// </summary>
        /// <returns></returns>
        public TBKRebateOrderGetRes TBKRebateOrderGet()
        {
            TBKRebateOrderGetReq tBKRebateOrderGetReq = new TBKRebateOrderGetReq();
            TBKRebateOrderGetRes tBKRebateOrderGetRes = new TBKRebateOrderGetRes();
            Tuple<string, string> tuple = new Tuple<string, string>("", "");
            Dictionary<string, string> tbkRebateOrderGetReqDic = new Dictionary<string, string>();
            tBKRebateOrderGetReq.method = "taobao.tbk.rebate.order.get";
            tBKRebateOrderGetReq.fields = "tb_trade_parent_id,tb_trade_id,num_iid,item_title,item_num,price,pay_price,seller_nick,seller_shop_title,commission,commission_rate,unid,create_time,earning_time";
            tBKRebateOrderGetReq.start_time = DateTime.Now.AddMonths(-1);
            tBKRebateOrderGetReq.span = 600;
            tBKRebateOrderGetReq.page_no = 1;
            tBKRebateOrderGetReq.page_size = 20;
            tuple = new TBKApiCommonService().GetReqUrlAndSign(tBKRebateOrderGetReq);

            tBKRebateOrderGetReq.sign = tuple.Item2;
            string result = string.Empty;
            result = new TBKApiCommonService().ReqApiByGet(tuple.Item1);
            tBKRebateOrderGetRes = JsonConvert.DeserializeObject<TBKRebateOrderGetRes>(result);
            return tBKRebateOrderGetRes;

        }
        #endregion

    }
}
