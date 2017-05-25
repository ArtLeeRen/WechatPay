using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Response
{
    /// <summary>
    /// 撤单
    /// </summary>
    public class ReverseResponse : WechatPayResponse
    {
        #region 构造函数

        public ReverseResponse()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 是否重调
        /// </summary>
        [XmlElement("recall")]
        public string ReCall { get; set; }

        #endregion
    }
}
