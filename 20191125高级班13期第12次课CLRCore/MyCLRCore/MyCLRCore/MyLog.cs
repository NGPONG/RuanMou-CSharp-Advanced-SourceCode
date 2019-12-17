using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
    public class MyLog
    {
        public static void Log(string msg)
        {
            StreamWriter sw = null;
            try
            {
                string fileName = "log.txt";
                string totalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                sw = File.AppendText(totalPath);
                sw.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
                sw.WriteLine("***************************************************");
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
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
