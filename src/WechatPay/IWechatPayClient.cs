using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay
{
    public interface IWechatPayClient
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// 商户IDc
        /// </summary>
        string MchId { get; }

        /// <summary>
        /// 商户Key
        /// </summary>
        string MchKey { get; }

        /// <summary>
        /// 超时时间
        /// </summary>
        int TimeOut { get; set; }

        /// <summary>
        /// 调用微信支付接口
        /// </summary>
        TResponse Excute<TResponse>(IWechatPayRequest<TResponse> request) where TResponse : WechatPayResponse;
    }
}
