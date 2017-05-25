using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Xml;
using System.Reflection;
using ArtLee.WechatPay.Utils;
using System.Xml.Serialization;

namespace ArtLee.WechatPay.Parser
{
    public class WechatXmlParser<T> : IWechatParser<T> where T : WechatPayResponse
    {
        #region 字段

        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> m_DicProperties
            = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        #endregion

        #region 构造函数

        public WechatXmlParser()
        {
        }

        #endregion

        #region 公共方法

        public T Parse(string body, string charset)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(charset))
                charset = "utf-8";

            if (!m_DicProperties.ContainsKey(typeof(T)))
                m_DicProperties[typeof(T)] = GetPropertiesMap(typeof(T));
            var propertiesMap = m_DicProperties[typeof(T)];

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(body);

            T result = (T)System.Activator.CreateInstance(typeof(T));

            result.ResponseContent = body;

            var parameters = (result as WechatPayResponse).Parameters;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                parameters.Add(node.Name, node.InnerText);
                if(propertiesMap.ContainsKey(node.Name))
                    propertiesMap[node.Name].SetValue(result, node.InnerText.TryTo(propertiesMap[node.Name].PropertyType));
            }

            return result;
        }

        #endregion

        #region 私有方法

        private Dictionary<string, PropertyInfo> GetPropertiesMap(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            var propertiesMap = new Dictionary<string, PropertyInfo>();
            var query = from e in typeof(T).GetProperties()
                        where e.CanWrite && e.GetCustomAttributes(typeof(XmlElementAttribute), true).Any()
                        select new { Property = e, Element = e.GetCustomAttributes(typeof(XmlElementAttribute), true).OfType<XmlElementAttribute>().First() };
            foreach (var item in query)
                propertiesMap.Add(item.Element.ElementName, item.Property);

            return propertiesMap;
        }

        #endregion
    }
}
