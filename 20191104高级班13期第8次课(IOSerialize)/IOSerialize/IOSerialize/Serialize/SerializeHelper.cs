using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IOSerialize.Serialize
{
    public class SerializeHelper
    {
        /// <summary>
        /// 二进制序列化器
        /// </summary>
        public static void BinarySerialize()
        {
            //使用二进制序列化对象
            string fileName = Path.Combine(Constant.SerializeDataPath, @"BinarySerialize.txt");//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {//需要一个stream，这里是直接写入文件了
                List<Programmer> pList = DataFactory.BuildProgrammerList();
                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                binFormat.Serialize(fStream, pList);
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {//需要一个stream，这里是来源于文件
                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                //使用二进制反序列化对象
                fStream.Position = 0;//重置流位置
                List<Programmer> pList = (List<Programmer>)binFormat.Deserialize(fStream);//反序列化对象
            }
        }


        /// <summary>
        /// soap序列化器
        /// </summary>
        public static void SoapSerialize()
        {
            //使用Soap序列化对象
            string fileName = Path.Combine(Constant.SerializeDataPath, @"SoapSerialize.txt");//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.BuildProgrammerList();
                SoapFormatter soapFormat = new SoapFormatter();//创建二进制序列化器
                //soapFormat.Serialize(fStream, list);//SOAP不能序列化泛型对象
                soapFormat.Serialize(fStream, pList.ToArray());
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                SoapFormatter soapFormat = new SoapFormatter();//创建二进制序列化器
                //使用二进制反序列化对象
                fStream.Position = 0;//重置流位置
                List<Programmer> pList = ((Programmer[])soapFormat.Deserialize(fStream)).ToList();//反序列化对象
            }
        }

        //BinaryFormatter序列化自定义类的对象时，序列化之后的流中带有空字符，以致于无法反序列化，反序列化时总是报错“在分析完成之前就遇到流结尾”（已经调用了stream.Seek(0, SeekOrigin.Begin);）。
        //改用XmlFormatter序列化之后，可见流中没有空字符，从而解决上述问题，但是要求类必须有无参数构造函数，而且各属性必须既能读又能写，即必须同时定义getter和setter，若只定义getter，则反序列化后的得到的各个属性的值都为null。

        /// <summary>
        /// XML序列化器
        /// </summary>
        public static void XmlSerialize()
        {
            //使用XML序列化对象
            string fileName = Path.Combine(Constant.SerializeDataPath, @"Student.xml");//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.BuildProgrammerList();
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));//创建XML序列化器，需要指定对象的类型
                xmlFormat.Serialize(fStream, pList);
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));//创建XML序列化器，需要指定对象的类型
                //使用XML反序列化对象
                fStream.Position = 0;//重置流位置
                List<Programmer> pList = pList = (List<Programmer>)xmlFormat.Deserialize(fStream);
            }
        }


        /// <summary>
        /// json也可以的
        /// </summary>
        public static void Json()
        {
            List<Programmer> pList = DataFactory.BuildProgrammerList();
            string result = JsonHelper.ObjectToString<List<Programmer>>(pList);
            List<Programmer> pList1 = JsonHelper.StringToObject<List<Programmer>>(result);
        }
    }
}
