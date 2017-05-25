using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Response
{
    /// <summary>
    /// 刷卡支付
    /// </summary>
    public class MicroPayResponse : WechatPayResponse
    {
        #region 构造函数

        public MicroPayResponse()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 设备号
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 用户标识	
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 交易类型	
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 微信支付订单号	
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 附加数据	
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间	
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEnd { get; set; }

        #endregion
    }
}
