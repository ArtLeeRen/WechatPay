using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Utils
{
    /// <summary>
    /// 时间类型扩展方法 必须为标准北京时间，根据微信文档
    /// </summary>
    public static class DateTimeExtensions
    {
        private readonly static DateTime lowDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private readonly static IFormatProvider formatProvider = new CultureInfo("zh-CN", true);

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public static int GetTimestamp(this DateTime date)
        {
            TimeSpan ts = date - lowDateTime;
            return Convert.ToInt32(ts.TotalSeconds);
        }

        /// <summary>
        /// 根据微信传过来的CreateTime获取当前时间
        /// </summary>
        /// <param name="createTime">秒</param>
        /// <returns>当前时间</returns>
        public static DateTime GetDateTimeFromTimestamp(this int createTime)
        {
            DateTime utcDt = lowDateTime.AddSeconds(createTime);
            return utcDt.ToLocalTime();
        }

        public static DateTime? ParseWechatTime(string time)
        {
            DateTime Result;
            if (DateTime.TryParseExact(time, "yyyyMMddHHmmss", formatProvider, DateTimeStyles.None, out Result))
            {
                return Result;
            }
            return null;
        }
    }
}
