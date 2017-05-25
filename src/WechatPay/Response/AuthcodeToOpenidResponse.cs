using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Response
{
    /// <summary>
    /// 授权码查询OPENID接口
    /// </summary>
    public class AuthcodeToOpenidResponse : WechatPayResponse
    {
        #region 构造函数

        public AuthcodeToOpenidResponse()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        #endregion
    }
}
