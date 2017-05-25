using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    /// <summary>
    /// 撤销订单
    /// 支付交易返回失败或支付系统超时，调用该接口撤销交易。
    /// 如果此订单用户支付失败，微信支付系统会将此订单关闭；
    /// 如果用户支付成功，微信支付系统会将此订单资金退还给用户。
    /// 注意：7天以内的交易单可调用撤销，其他正常支付的单如需实现相同功能请调用申请退款API。
    /// 提交支付交易后调用【查询订单API】，没有明确的支付结果再调用【撤销订单API】。
    /// </summary>
    public class ReverseRequest : IWechatPayRequest<ReverseResponse>
    {
        #region 构造函数

        public ReverseRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/secapi/pay/reverse"; }
        }

        public bool NeedCert
        {
            get { return true; }
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            parameteers.Add("out_trade_no", OutTradeNo);
            return parameteers;
        }

        #endregion
    }
}
