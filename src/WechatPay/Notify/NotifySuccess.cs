using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Notify
{
    public class NotifyResult
    {
        public string ReturnCode { get; set; }

        public string ReturnMsg { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<xml>");
            builder.AppendFormat("<return_code><![CDATA[{0}]]></return_code>", ReturnCode);
            builder.AppendFormat("<return_msg><![CDATA[{0}]]></return_msg>", ReturnMsg);
            builder.Append("</xml>");
            return builder.ToString();
        }
    }
}
