using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    /// <summary>
    /// 查询订单请求
    /// </summary>
    public class OrderQueryRequest : IWechatPayRequest<OrderQueryResponse>
    {
        #region 构造函数

        public OrderQueryRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/pay/orderquery"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// 微信订单号	
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string OutTradeNo { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(TransactionId))
                parameteers.Add("transaction_id", TransactionId);
            if (!string.IsNullOrEmpty(OutTradeNo))
                parameteers.Add("out_trade_no", OutTradeNo);
            return parameteers;
        }

        #endregion
    }
}
