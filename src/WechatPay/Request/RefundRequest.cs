using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    public class RefundRequest : IWechatPayRequest<RefundResponse>
    {
        #region 构造函数

        public RefundRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/secapi/pay/refund"; }
        }

        public bool NeedCert
        {
            get { return true; }
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
        /// 总金额	
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int RefundFee { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string OpUserId { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(TransactionId))
                parameteers.Add("transaction_id", TransactionId);
            if (!string.IsNullOrEmpty(OutTradeNo))
                parameteers.Add("out_trade_no", OutTradeNo);
            parameteers.Add("out_refund_no", OutRefundNo);
            parameteers.Add("total_fee", TotalFee.ToString());
            parameteers.Add("refund_fee", RefundFee.ToString());
            if (!string.IsNullOrEmpty(RefundFeeType))
                parameteers.Add("refund_fee_type", RefundFeeType);
            parameteers.Add("op_user_id", OpUserId);
            return parameteers;
        }

        #endregion
    }
}
