using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Response
{
    public class ShortUrlResponse : WechatPayResponse
    {
        #region 构造函数

        public ShortUrlResponse()
        {
        }

        #endregion

        #region 属性

        [XmlElement("short_url")]
        public string ShortUrl { get; set; }

        #endregion
    }
}
