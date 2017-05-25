using ArtLee.WechatPay.Parser;
using ArtLee.WechatPay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay
{
    /// <summary>
    /// 微信支付接口调用
    /// 均为HTTPS POST
    /// </summary>
    public class DefaultWechatPayClient : IWechatPayClient
    {
        #region 字段

        private const string STR_APPID = "appid";
        private const string STR_MCHID = "mch_id";
        private const string STR_NONCE_STR = "nonce_str";
        private const string STR_SIGN = "sign";

        private WebUtils webUtils;

        #endregion

        #region 构造函数

        public DefaultWechatPayClient(string appId,
            string mchId,
            string mchKey,
            string certificatePath = "",
            string charset = "")
        {
            webUtils = new WebUtils();
            AppId = appId;
            MchId = mchId;
            MchKey = mchKey;
            CertificatePath = certificatePath;
            Charset = charset;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 公众号ID
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 商户IDc
        /// </summary>
        public string MchId { get; private set; }

        /// <summary>
        /// 商户Key
        /// </summary>
        public string MchKey { get; private set; }

        /// <summary>
        /// 证书地址
        /// </summary>
        public string CertificatePath { get; private set; }

        /// <summary>
        /// 字符集
        /// </summary>
        public string Charset { get; private set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int TimeOut
        {
            get { return webUtils.Timeout; }
            set { webUtils.Timeout = value; }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 调用微信支付请求通用接口
        /// </summary>
        public TResponse Excute<TResponse>(IWechatPayRequest<TResponse> request) where TResponse : WechatPayResponse
        {
            if (request == null)
                throw new ArgumentNullException("request");
            if (string.IsNullOrEmpty(this.Charset))
            {
                this.Charset = "utf-8";
            }

            //插入默认请求参数
            var parameters = request.GetParameters();
            parameters[STR_APPID] = AppId;
            parameters[STR_MCHID] = MchId;
            parameters[STR_NONCE_STR] = WechatExtensions.CreateNonceStr(16);
            parameters[STR_SIGN] = WechatSignature.Create(parameters, "key=" + MchKey);
            //证书
            X509Certificate2 cert = null;
            if (request.NeedCert)
            {
                cert = new X509Certificate2(CertificatePath, MchId);
            }
            var body = webUtils.DoPost(request.ApiUrl, parameters, cert, Charset);

            //XML解析返回内容
            IWechatParser<TResponse> rsp = new WechatXmlParser<TResponse>();
            TResponse response = rsp.Parse(body, Charset);
            var dicCheck = new Dictionary<string, string>(response.Parameters);
            dicCheck.Remove(STR_SIGN);

            //验证签名 有时如果缺少参数返回信息没有签名
            if (response.Parameters.ContainsKey(STR_SIGN))
            {
                bool check = WechatSignature.Check(response.Parameters[STR_SIGN], dicCheck, "key=" + MchKey);
                if (!check)
                    throw new Exception("签名验证失败");
            }
            return response;
        }

        #endregion
    }
}
