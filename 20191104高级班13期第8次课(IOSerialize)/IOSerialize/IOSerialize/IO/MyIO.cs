using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize.IO
{
    /// <summary>
    /// 文件夹  文件管理 
    /// 
    /// 配置文件：AdO.Net 数据库查询；
    /// IOC配置文件
    /// 
    /// </summary>
    public class MyIO
    {
        /// <summary>
        /// 配置绝对路径
        /// </summary>
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        private static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        /// <summary>
        /// 获取当前程序路径
        /// </summary>
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 读取文件夹  文件信息
        /// </summary>
        public static void Show()
        {
            {//check
                if (!Directory.Exists(LogPath))//检测文件夹是否存在
                {

                }
                DirectoryInfo directory = new DirectoryInfo(LogPath);//不存在不报错  注意exists属性
                Console.WriteLine(string.Format("{0} {1} {2}", directory.FullName, directory.CreationTime, directory.LastWriteTime));

                if (!File.Exists(Path.Combine(LogPath, "info.txt")))
                {
                }

                FileInfo fileInfo = new FileInfo(Path.Combine(LogPath, "info.txt"));

                Console.WriteLine(string.Format("{0} {1} {2}", fileInfo.FullName, fileInfo.CreationTime, fileInfo.LastWriteTime));
            }
            {//Directory
                if (!Directory.Exists(LogPath))
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);//一次性创建全部的子路径
                    Directory.Move(LogPath, LogMovePath);//移动  原文件夹就不在了
                    Directory.Delete(LogMovePath);//删除
                }
            }
            {//File
                string fileName = Path.Combine(LogPath, "log.txt");
                string fileNameCopy = Path.Combine(LogPath, "logCopy.txt");
                string fileNameMove = Path.Combine(LogPath, "logMove.txt");
                bool isExists = File.Exists(fileName);
                if (!isExists)
                {
                    Directory.CreateDirectory(LogPath);//创建了文件夹之后，才能创建里面的文件
                    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
                    {
                        string name = "12345567778890";
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        fileStream.Write(bytes, 0, bytes.Length);
                        fileStream.Flush();
                    }

                    // 如果文件不存在就创建，如果存在就新建一个覆盖掉
                    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
                    {
                        StreamWriter sw = new StreamWriter(fileStream);
                        sw.WriteLine("1234567890");
                        sw.Flush();
                    }

                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        string msg = "今天是Course6IOSerialize，今天上课的人有55个人";
                        sw.WriteLine(msg);
                        sw.Flush();
                    }
                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        string name = "0987654321";
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        sw.BaseStream.Write(bytes, 0, bytes.Length);
                        sw.Flush();
                    }



                    foreach (string result in File.ReadAllLines(fileName))
                    {
                        Console.WriteLine(result);
                    }
                    string sResult = File.ReadAllText(fileName);
                    Byte[] byteContent = File.ReadAllBytes(fileName);
                    string sResultByte = System.Text.Encoding.UTF8.GetString(byteContent);


                    //文件太大，用工具去打开的时候，计算机直接卡死了
                    using (FileStream stream = File.OpenRead(fileName))//分批读取
                    {
                        int length = 5;
                        int result = 0;

                        do
                        {
                            byte[] bytes = new byte[length];
                            result = stream.Read(bytes, 0, 5);
                            for (int i = 0; i < result; i++)
                            {
                                Console.WriteLine(bytes[i].ToString());
                            }
                        }
                        while (length == result);
                    }

                    File.Copy(fileName, fileNameCopy);
                    File.Move(fileName, fileNameMove);
                    File.Delete(fileNameCopy);
                    File.Delete(fileNameMove);//尽量不要delete
                }
            }

            {//DriveInfo
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                        Console.WriteLine("类型：{0} 卷标：{1} 名称：{2} 总空间：{3} 剩余空间：{4}", drive.DriveType, drive.VolumeLabel, drive.Name, drive.TotalSize, drive.TotalFreeSpace);
                    else
                        Console.WriteLine("类型：{0}  is not ready", drive.DriveType);
                }

            }

            {
                Console.WriteLine(Path.GetDirectoryName(LogPath));  //返回目录名，需要注意路径末尾是否有反斜杠对结果是有影响的
                Console.WriteLine(Path.GetDirectoryName(@"d:\\abc")); //将返回 d:\
                Console.WriteLine(Path.GetDirectoryName(@"d:\\abc\"));// 将返回 d:\abc
                Console.WriteLine(Path.GetRandomFileName());//将返回随机的文件名
                Console.WriteLine(Path.GetFileNameWithoutExtension("d:\\abc.txt"));// 将返回abc
                Console.WriteLine(Path.GetInvalidPathChars());// 将返回禁止在路径中使用的字符
                Console.WriteLine(Path.GetInvalidFileNameChars());//将返回禁止在文件名中使用的字符
                Console.WriteLine(Path.Combine(LogPath, "log.txt"));//合并两个路径
            }
        }

        /// <summary>
        /// 关于异常处理：(链接：http://pan.baidu.com/s/1kVNorpd 密码：pyhv)
        /// 1  try catch旨在上端使用，保证对用户的展示
        /// 2  下端不要吞掉异常，隐藏错误是没有意义的,抓住再throw也没意义
        /// 3  除非这个异常对流程没有影响或者你要单独处理这个异常
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            StreamWriter sw = null;
            try
            {
                string fileName = "log.txt";
                string totalPath = Path.Combine(LogPath, fileName);

                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                sw = File.AppendText(totalPath); // 如果文件不存在，就新建一个文件，然后写入内容
                sw.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
                sw.WriteLine("***************************************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//log //建议大家在写日志的时候，把异常吞掉；
                //throw ex;
                //throw new exception("这里异常");
            }
            finally//无论是否发生异常  全都都会执行
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

    }
}
