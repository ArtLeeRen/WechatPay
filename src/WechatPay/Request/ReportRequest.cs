using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    /// <summary>
    /// 测速上报
    /// </summary>
    public class ReportRequest : IWechatPayRequest<ReportResponse>
    {
        #region 构造函数

        public ReportRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/payitil/report"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// 接口URL
        /// </summary>
        public string InterfaceUrl { get; set; }

        /// <summary>
        /// 接口耗时情况，单位为毫秒
        /// </summary>
        public int ExecuteTime { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 访问接口IP
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 商户上报时间
        /// </summary>
        public DateTime? Time { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("interface_url", InterfaceUrl);
            parameters.Add("execute_time", ExecuteTime.ToString());
            parameters.Add("return_code", ReturnCode);
            parameters.Add("return_msg", ReturnMsg);
            parameters.Add("result_code", ResultCode);
            parameters.Add("err_code", ErrCode);
            parameters.Add("err_code_des", ErrCodeDes);
            if (!string.IsNullOrEmpty("out_trade_no"))
                parameters.Add("out_trade_no", OutTradeNo);
            parameters.Add("user_ip", UserIp);
            if (Time.HasValue)
                parameters.Add("time", Time.Value.ToString("yyyyMMddHHmmss"));
            return parameters;
        }

        #endregion
    }
}
