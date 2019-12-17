using IOSerialize.IO;
using IOSerialize.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    /// <summary>
    /// 1 文件夹/文件 检查、新增、复制、移动、删除，递归编程技巧
    /// 2 文件读写，记录文本日志，读取配置文件
    /// 3 三种序列化器，xml和json
    /// 4 验证码、图片缩放
    /// 
    /// 
    /// 大家好！欢迎大家来到.Net高级班的Vip课程！
    /// 
    /// 能听到老师讲话，能看到老师屏幕的 刷个1
    /// 
    /// 准备学习的小伙伴，刷个1
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级班vip课程，今天我们来学习IO和序列化，我是Richard老师!");
                {
                    Console.WriteLine("**************IOShow*************");
                   MyIO.Show();
                    //MyIO.Log("1235677");
                     
                   //var directoryInfos = Recursion.GetAllDirectory(@"D:\软谋教育\Git_Work");
                }

                {
                    //生成验证码
                    ImageHelper.Drawing();
                }
                {
                    //序列化&反序列化
                    //Console.WriteLine("**************Serialize*************");
                    SerializeHelper.BinarySerialize();
                    SerializeHelper.SoapSerialize();
                    SerializeHelper.XmlSerialize();
                }
                SerializeHelper.Json();

                List<Programmer> list = DataFactory.BuildProgrammerList();
                {
                    Console.WriteLine("********************XmlHelper**********************");
                    string xmlResult = XmlHelper.ToXml<List<Programmer>>(list);
                    List<Programmer> list1 = XmlHelper.ToObject<List<Programmer>>(xmlResult);
                    //List<Programmer> list2 = XmlHelper.FileToObject<List<Programmer>>("");
                }



                {
                    string jResult = JsonHelper.ObjectToString<List<Programmer>>(list);
                    List<Programmer> list1 = JsonHelper.StringToObject<List<Programmer>>(jResult);
                }
                {
                    string jResult = JsonHelper.ToJson<List<Programmer>>(list);
                    List<Programmer> list1 = JsonHelper.ToObject<List<Programmer>>(jResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
