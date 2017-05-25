using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Request
{
    public class ShortUrlRequest : IWechatPayRequest<ShortUrlResponse>
    {
        #region 构造函数

        public ShortUrlRequest()
        {
        }

        #endregion

        #region 属性


        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/tools/shorturl"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// URL链接
        /// </summary>
        [XmlElement("long_url")]
        public string LongUrl { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameteers = new Dictionary<string, string>();
            parameteers.Add("long_url", LongUrl);
            return parameteers;
        }

        #endregion
    }
}
