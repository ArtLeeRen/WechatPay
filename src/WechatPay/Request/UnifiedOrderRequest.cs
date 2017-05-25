using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class UnifiedOrderRequest : IWechatPayRequest<UnifiedOrderResponse>
    {
        #region 字段

        private const string API_URL = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        #endregion

        #region 构造函数

        public UnifiedOrderRequest()
        {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取微信下单调用接口地址
        /// </summary>
        public string ApiUrl { get { return API_URL; } }

        /// <summary>
        /// 是否需要证书
        /// </summary>
        public bool NeedCert { get { return false; } }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 商品详情	
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 附加数据	
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// 交易起始时间
        /// </summary>
        public DateTime? TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public DateTime? TimeExpire { get; set; }

        /// <summary>
        /// 商品标记
        /// </summary>
        public string GoodsTag { get; set; }

        /// <summary>
        /// 通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public TradeType TradeType { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 指定支付
        /// </summary>
        public string LimitPay { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(DeviceInfo))
                parameteers.Add("device_info", DeviceInfo);
            parameteers.Add("body", Body);
            if (!string.IsNullOrEmpty(Detail))
                parameteers.Add("detail", Detail);
            if (!string.IsNullOrEmpty(Attach))
                parameteers.Add("attach", Attach);
            parameteers.Add("out_trade_no", OutTradeNo);
            if (!string.IsNullOrEmpty(FeeType))
                parameteers.Add("fee_type", FeeType);
            parameteers.Add("total_fee", TotalFee.ToString());
            parameteers.Add("spbill_create_ip", SpbillCreateIp);
            if (TimeStart.HasValue)
                parameteers.Add("time_start", TimeStart.Value.ToString("yyyyMMddHHmmss"));
            if (TimeExpire.HasValue)
                parameteers.Add("time_expire", TimeExpire.Value.ToString("yyyyMMddHHmmss"));
            if (!string.IsNullOrEmpty(GoodsTag))
                parameteers.Add("goods_tag", GoodsTag);
            parameteers.Add("notify_url", NotifyUrl);
            parameteers.Add("trade_type", TradeType.ToString());
            if (!string.IsNullOrEmpty(ProductId))
                parameteers.Add("product_id", ProductId);
            if (!string.IsNullOrEmpty(LimitPay))
                parameteers.Add("limit_pay", LimitPay);
            parameteers.Add("openid", OpenId);
            return parameteers;
        }

        #endregion
    }
}
