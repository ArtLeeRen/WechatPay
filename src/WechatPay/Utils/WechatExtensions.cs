using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArtLee.WechatPay.Utils
{
    public static  class WechatExtensions
    {
        internal static object TryTo<T>(this object Object)
        {
            return Object.TryTo(typeof(T));
        }

        /// <summary>
        /// 尝试将对象实例转换成目标类型
        /// </summary>
        /// <typeparam name="T">对象实例类型</typeparam>
        /// <typeparam name="R">目标类型</typeparam>
        /// <param name="Object">对象实例</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns>转换后类型</returns>
        internal static object TryTo(this object Object, Type destinationType)
        {
            try
            {
                if (Object == null || Convert.IsDBNull(Object))
                    return GetDefault(destinationType);
                if ((Object as string) != null)
                {
                    string ObjectValue = Object as string;
                    if (destinationType.IsEnum)
                        return System.Enum.Parse(destinationType, ObjectValue, true);
                    if (string.IsNullOrEmpty(ObjectValue))
                        return GetDefault(destinationType);
                }
                if ((Object as IConvertible) != null)
                {
                    Type destination =
                       destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                           Nullable.GetUnderlyingType(destinationType) : destinationType;
                    return Convert.ChangeType(Object, destination);
                }
                if (destinationType.IsAssignableFrom(Object.GetType()))
                    return Object;
                TypeConverter Converter = TypeDescriptor.GetConverter(Object.GetType());
                if (Converter.CanConvertTo(destinationType))
                    return Converter.ConvertTo(Object, destinationType);
            }
            catch { }
            return GetDefault(destinationType);
        }

        private static object GetDefault(Type type)
        {
            var defaultExpr = Expression.Default(type);
            return Expression.Lambda<Func<object>>(defaultExpr).Compile()();
        }

        public static Dictionary<string, string> GetJsAPIParms(this IWechatPayClient client,string prePayId)
        {
            if (client == null) throw new ArgumentNullException("client");
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", client.AppId);
            parameters.Add("timeStamp", DateTime.Now.GetTimestamp().ToString());
            parameters.Add("nonceStr", CreateNonceStr(16));
            parameters.Add("package", "prepay_id="+ prePayId);
            parameters.Add("signType", "MD5");
            parameters.Add("paySign", WechatSignature.Create(parameters, "key=" + client.MchKey));
            return parameters;
        }

        public static string CreateNonceStr(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff).Replace("=", "").Replace("+", "").Replace("/", "");
        }
    }
}
