using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Utils
{
    public static class WechatSignature
    {
        /// <summary>
        /// 创建签名
        /// </summary>
        /// <param name="data">签名数据</param>
        /// <param name="statKey">随机字符跟签名数据一起参与签名</param>
        /// <returns>签名数据</returns>
        public static string Create(IDictionary<string, string> data, string statKey = "")
        {
            if (data == null) throw new ArgumentNullException("data");
            var dataList = data.Where(e=>!string.IsNullOrEmpty(e.Value)).OrderBy(e => e.Key).Select(e => string.Concat(e.Key, "=", e.Value));
            string dataStr = string.Join("&", dataList);
            dataStr = string.Concat(dataStr, "&", statKey);
            var hashByteArray = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(dataStr));
            return BitConverter.ToString(hashByteArray).Replace("-", "").ToUpper();
        }

        /// <summary>
        /// 验证签名数据是否准确
        /// </summary>
        /// <param name="data">签名数据</param>
        /// <param name="statKey">随机字符跟签名数据一起参与签名</param>
        /// <param name="signature">签名</param>
        /// <returns>验证key</returns>
        public static bool Check(string signature, IDictionary<string, string> data, string statKey = "")
        {
            string sign = Create(data, statKey);
            return string.Equals(signature, sign, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
