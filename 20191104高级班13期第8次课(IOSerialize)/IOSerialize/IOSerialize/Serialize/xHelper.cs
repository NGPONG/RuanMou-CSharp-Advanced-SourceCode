
using System;
using System.Linq;
using System.Xml;
using System.Reflection;
using System.Data;
using System.Collections.Generic;

namespace IOSerialize.Serialize
{
    public static class xHelper
    {
        /// <summary>   
        /// 实体转化为XML   
        /// </summary>   
        public static string ParseToXml<T>(this T model, string fatherNodeName)
        {
            var xmldoc = new XmlDocument();
            var modelNode = xmldoc.CreateElement(fatherNodeName);
            xmldoc.AppendChild(modelNode);

            if (model != null)
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                {
                    var attribute = xmldoc.CreateElement(property.Name);
                    if (property.GetValue(model, null) != null)
                        attribute.InnerText = property.GetValue(model, null).ToString();
                    //else
                    //    attribute.InnerText = "[Null]";
                    modelNode.AppendChild(attribute);
                }
            }
            return xmldoc.OuterXml;
        }

        /// <summary>
        /// XML转换为实体,默认 fatherNodeName="body"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="fatherNodeName"></param>
        /// <returns></returns>
        public static T ParseToModel<T>(this string xml, string fatherNodeName = "body") where T : class ,new()
        {
            if (string.IsNullOrEmpty(xml))
                return default(T);
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            T model = new T();
            var attributes = xmldoc.SelectSingleNode(fatherNodeName).ChildNodes;
            foreach (XmlNode node in attributes)
            {
                foreach (var property in model.GetType().GetProperties().Where(property => node.Name == property.Name))
                {
                    if (!string.IsNullOrEmpty(node.InnerText))
                    {
                        property.SetValue(model,
                                          property.PropertyType == typeof(Guid)
                                              ? new Guid(node.InnerText)
                                              : Convert.ChangeType(node.InnerText, property.PropertyType));
                    }
                    else
                    {
                        property.SetValue(model, null);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// XML转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="headtag"></param>
        /// <returns></returns>
        public static List<T> XmlToObjList<T>(this string xml, string headtag)
            where T : new()
        {

            var list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            XmlNodeList nodelist = doc.SelectNodes(headtag);
            foreach (XmlNode node in nodelist)
            {
                T entity = new T();
                if (propinfos == null)
                {
                    Type objtype = entity.GetType();
                    propinfos = objtype.GetProperties();
                }
                foreach (PropertyInfo propinfo in propinfos)
                {
                    //实体类字段首字母变成小写的  
                    string name = propinfo.Name.Substring(0, 1) + propinfo.Name.Substring(1, propinfo.Name.Length - 1);
                    XmlNode cnode = node.SelectSingleNode(name);
                    string v = cnode.InnerText;
                    if (v != null)
                        propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                }
                list.Add(entity);

            }
            return list;
        }
    }
}
