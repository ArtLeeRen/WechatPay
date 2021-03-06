﻿using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    /// <summary>
    /// 刷卡支付
    /// </summary>
    public class MicroPayRequest : IWechatPayRequest<MicroPayResponse>
    {
        #region 构造函数

        public MicroPayRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/pay/micropay"; }
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
        /// 商品标记
        /// </summary>
        public string GoodsTag { get; set; }

        /// <summary>
        /// 指定支付
        /// </summary>
        public string LimitPay { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string AuthCode { get; set; }

        #endregion

        #region 公共方法

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
            if (!string.IsNullOrEmpty(GoodsTag))
                parameteers.Add("goods_tag", GoodsTag);
            if (!string.IsNullOrEmpty(LimitPay))
                parameteers.Add("limit_pay", LimitPay);
            parameteers.Add("auth_code", AuthCode);
            return parameteers;
        }

        #endregion
    }
}
