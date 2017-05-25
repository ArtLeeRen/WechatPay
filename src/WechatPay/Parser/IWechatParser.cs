using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Parser
{
    /// <summary>
    /// 微信支付结果解析
    /// </summary>
    public interface IWechatParser<T> where T : WechatPayResponse
    {
        T Parse(string body, string charset);
    }
}
