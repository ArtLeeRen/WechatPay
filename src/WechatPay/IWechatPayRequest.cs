using ArtLee.WechatPay.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay
{
    /// <summary>
    /// 微信支付请求基类
    /// </summary>
    public interface IWechatPayRequest<T> where T : WechatPayResponse
    {
        /// <summary>
        /// 获取微信API地址
        /// </summary>
        string ApiUrl { get; }

        /// <summary>
        /// 是否需要证书
        /// </summary>
        bool NeedCert { get; }

        /// <summary>
        /// 获取请求参数
        /// </summary>
        IDictionary<string, string> GetParameters();
    }
}
