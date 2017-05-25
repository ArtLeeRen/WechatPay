using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtLee.WechatPay
{
    /// <summary>
    /// 返回信息基类
    /// </summary>
    public abstract class WechatPayResponse
    {
        #region 构造函数

        public WechatPayResponse()
        {
            Parameters = new Dictionary<string, string>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 返回状态码
        /// </summary>
        /// <remarks>
        /// SUCCESS/FAIL
        /// 此字段是通信标识，非交易标识，
        /// 交易是否成功需要查看result_code来判断
        ///</remarks>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// 签名失败
        /// 参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号ID
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述	
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 微信服务器返回的信息
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// 接受到的所有参数
        /// </summary>
        public Dictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// 返回状态码	
        /// </summary>
        public bool ReturnSuccess { get { return ReturnCode == "SUCCESS"; } }

        /// <summary>
        /// 业务结果	
        /// </summary>
        public bool ResultSuccess { get { return ReturnCode == "SUCCESS" && ResultCode == "SUCCESS"; } }

        #endregion
    }
}
