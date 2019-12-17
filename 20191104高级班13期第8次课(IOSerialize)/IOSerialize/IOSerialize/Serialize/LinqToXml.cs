using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IOSerialize.Serialize
{
    /// <summary>
    /// Linq to xml示例
    /// </summary>
    public class LinqToXml
    {
        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="xmlPath"></param>
        private static void CreateXmlFile(string xmlPath)
        {
            try
            {
                //定义一个XDocument结构
                XDocument myXDoc = new XDocument(
                   new XElement("Users",
                       new XElement("User", new XAttribute("ID", "111111"),
                           new XElement("name", "EricSun"),
                           new XElement("password", "123456"),
                           new XElement("description", "Hello I'm from Dalian")),
                       new XElement("User", new XAttribute("ID", "222222"),
                           new XElement("name", "Ray"),
                           new XElement("password", "654321"),
                           new XElement("description", "Hello I'm from Jilin"))));
                //保存此结构（即：我们预期的xml文件）
                myXDoc.Save(xmlPath);

                string aa = myXDoc.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// 遍历xml信息
        /// </summary>
        /// <param name="xmlPath"></param>
        private static void GetXmlNodeInformation(string xmlPath)
        {
            try
            {
                //定义并从xml文件中加载节点（根节点）
                XElement rootNode = XElement.Load(xmlPath);
                //XElement rootNode2 = XElement.Parse(xmlPath);

                //查询语句: 获得根节点下name子节点（此时的子节点可以跨层次：孙节点、重孙节点......）
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("name")
                                                    select target;
                foreach (XElement node in targetNodes)
                {
                    Console.WriteLine("name = {0}", node.Value);
                }

                //查询语句: 获取ID属性值等于"111111"并且函数子节点的所有User节点（并列条件用"&&"符号连接）
                IEnumerable<XElement> myTargetNodes = from myTarget in rootNode.Descendants("User")
                                                      where myTarget.Attribute("ID").Value.Equals("111111")
                                                            && myTarget.HasElements
                                                      select myTarget;
                foreach (XElement node in myTargetNodes)
                {
                    Console.WriteLine("name = {0}", node.Element("name").Value);
                    Console.WriteLine("password = {0}", node.Element("password").Value);
                    Console.WriteLine("description = {0}", node.Element("description").Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void ModifyXmlNodeInformation(string xmlPath)
        {
            try
            {
                //定义并从xml文件中加载节点（根节点）
                XElement rootNode = XElement.Load(xmlPath);
                //查询语句: 获取ID属性值等于"222222"或者等于"777777"的所有User节点（或条件用"||"符号连接）
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("User")
                                                    where target.Attribute("ID").Value == "222222"
                                                          || target.Attribute("ID").Value.Equals("777777")
                                                    select target;
                //遍历所获得的目标节点（集合）
                foreach (XElement node in targetNodes)
                {
                    //将description节点的InnerText设置为"Hello, I'm from USA."
                    node.Element("description").SetValue("Hello, I'm from USA.");
                }
                //保存对xml的更改操作
                rootNode.Save(xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void AddXmlNodeInformation(string xmlPath)
        {
            try
            {
                //定义并从xml文件中加载节点（根节点）
                XElement rootNode = XElement.Load(xmlPath);
                //定义一个新节点
                XElement newNode = new XElement("User", new XAttribute("ID", "999999"),
                                                            new XElement("name", "Rose"),
                                                            new XElement("password", "456123"),
                                                            new XElement("description", "Hello, I'm from UK."));
                //将此新节点添加到根节点下
                rootNode.Add(newNode);
                //Add 在 XContainer 的子内容的末尾添加内容。
                //AddFirst 在 XContainer 的子内容的开头添加内容。
                //AddAfterSelf 在 XNode 后面添加内容。
                //AddBeforeSelf 在 XNode 前面添加内容。
                //保存对xml的更改操作
                rootNode.Save(xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void DeleteXmlNodeInformation(string xmlPath)
        {
            try
            {
                //定义并从xml文件中加载节点（根节点）
                XElement rootNode = XElement.Load(xmlPath);
                //查询语句: 获取ID属性值等于"999999"的所有User节点
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("User")
                                                    where target.Attribute("ID").Value.Equals("999999")
                                                    select target;

                //将获得的节点集合中的每一个节点依次从它相应的父节点中删除
                targetNodes.Remove();
                //保存对xml的更改操作
                rootNode.Save(xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
