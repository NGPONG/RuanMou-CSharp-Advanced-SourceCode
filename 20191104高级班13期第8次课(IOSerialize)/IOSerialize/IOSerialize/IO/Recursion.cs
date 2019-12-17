using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOSerialize.IO
{
    /// <summary>
    ///
    /// </summary>
    public class Recursion
    {
        /// <summary>
        /// 找出全部的子文件夹
        /// 递归：可以理解为类型，或者说是一种编程方式
        /// 
        /// 获取“D:\软谋教育\Git_Work”路径下的所有文件夹
        /// 
        /// 1、在递归的时候，计算机是在高强度的计算；
        /// 2、一定要有跳出循环的判断，避免死循环；
        /// 3、在使用递归的时候，尽量避免多线程；
        /// </summary>
        /// <param name="rootPath">根目录</param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetAllDirectory(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                return new List<DirectoryInfo>();

            //一个存储路径信息的容器
            List<DirectoryInfo> directoryList = new List<DirectoryInfo>();//容器

            DirectoryInfo directory = new DirectoryInfo(rootPath);//root文件夹
            directoryList.Add(directory);

            var directioryList = GetChilds(directoryList, directory);

            return directioryList;

            //var chaildArray = directory.GetDirectories();
            //if (chaildArray != null && chaildArray.Length > 0)
            //{
            //    foreach (var child in chaildArray)
            //    {
            //        directoryList.Add(child);

            //        var childChild = child.GetDirectories();

            //        if (childChild != null && childChild.Length > 0)
            //        {
            //            directoryList.Add(child); 
            //        }

            //    }
            //}



        }

        private static List<DirectoryInfo> GetChilds(List<DirectoryInfo> directoryList, DirectoryInfo directory)
        {
            var chaildArray = directory.GetDirectories();
            if (chaildArray != null && chaildArray.Length > 0)
            {
                foreach (var child in chaildArray)
                {
                    directoryList.Add(child);
                    GetChilds(directoryList, child);
                }
            }
            return directoryList;
        }


        /// <summary>
        /// 计算机的计算能力是超强，会死机
        /// </summary>
        private void Wait()
        {
            if (DateTime.Now.Millisecond < 999)
            {
                //启动个多线程？？  会疯狂的启动多个子线程
                Wait();
                //Thread.Sleep(5);//最多可能浪费4ms
            }
            else
                return;

        }
    }
}
