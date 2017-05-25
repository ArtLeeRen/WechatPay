using ArtLee.WechatPay.Parser;
using ArtLee.WechatPay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Notify
{
    public static class NotifyUtils
    {
        private static readonly NotifyResult m_NotifySuccess = new NotifyResult() { ReturnCode = "SUCCESS", ReturnMsg = "OK" };
        private static readonly NotifyResult m_NotifyFail = new NotifyResult() { ReturnCode = "FAIL", ReturnMsg = "错误" };


        public static NotifyResult NotifySuccess { get { return m_NotifySuccess; } }


        public static NotifyResult NotifyFail { get { return m_NotifyFail; } }

        /// <summary>
        /// 解析支付消息通知文本并验证消息
        /// </summary>
        /// <param name="content">微信支付消息内容</param>
        /// <param name="mchKey">商户密钥</param>
        /// <returns>微信支付消息</returns>
        public static WechatPayNotifyResult ParserNotifyAndCheck(string content, string mchKey)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");
            var Parser = new WechatXmlParser<WechatPayNotifyResult>();
            var result = Parser.Parse(content, "utf-8");

            var dicCheck = new Dictionary<string, string>(result.Parameters);
            dicCheck.Remove("sign");

            //验证签名 有时如果缺少参数返回信息没有签名
            if (result.Parameters.ContainsKey("sign"))
            {
                bool check = WechatSignature.Check(result.Parameters["sign"], dicCheck, "key=" + mchKey);
                if (!check)
                    throw new Exception("签名验证失败");
            }
            return result;
        }
    }
}
