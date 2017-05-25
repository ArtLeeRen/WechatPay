using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    public class RefundQueryRequest : IWechatPayRequest<RefundQueryResponse>
    {
        #region 构造函数

        public RefundQueryRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/pay/refundquery"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 微信订单号	
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(DeviceInfo))
                parameteers.Add("device_info", DeviceInfo);
            if (!string.IsNullOrEmpty(TransactionId))
                parameteers.Add("transaction_id", TransactionId);
            if (!string.IsNullOrEmpty(OutTradeNo))
                parameteers.Add("out_trade_no", OutTradeNo);
            if (!string.IsNullOrEmpty("out_refund_no"))
                parameteers.Add("out_refund_no", OutRefundNo);
            if (!string.IsNullOrEmpty(RefundId))
                parameteers.Add("refund_id", RefundId);
            return parameteers;
        }

        #endregion
    }
}
