using ArtLee.WechatPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Request
{
    [Obsolete("破坏代码结果，暂时不支持", true)]
    public class DownloadBillRequest : IWechatPayRequest<DownloadBillResponse>
    {
        #region 构造函数

        public DownloadBillRequest()
        {
        }

        #endregion

        #region 属性

        public string ApiUrl
        {
            get { return "https://api.mch.weixin.qq.com/pay/downloadbill"; }
        }

        public bool NeedCert
        {
            get { return false; }
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 对账单日期
        /// </summary>
        public DateTime BillDate { get; set; }

        /// <summary>
        /// 账单类型
        /// </summary>
        public string BillType { get; set; }

        #endregion

        #region 公共方法

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("bill_date", BillDate.ToString("yyyyMMdd"));
            parameters.Add("bill_type", BillType ?? "ALL");
            return parameters;
        }

        #endregion
    }
}
