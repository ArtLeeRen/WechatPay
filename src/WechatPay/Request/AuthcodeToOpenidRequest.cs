using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Request
{
    public class AuthcodeToOpenidRequest : IWechatPayRequest<AuthcodeToOpenidResponse>
    {
        #region 构造函数

        public AuthcodeToOpenidRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/tools/authcodetoopenid"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// 授权码
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            parameteers.Add("auth_code", AuthCode);
            return parameteers;
        }

        #endregion
    }
}
