using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet.QuartzNet.CustomLog
{
    public class CustomConsoleLogProvider : ILogProvider
    {
        public Logger GetLogger(string name) ///可以获取到框架内部的日志信息
        {
            return new Logger((level, func, exception, parameters) =>
            {
                if (level >= LogLevel.Info && func != null)
                {
                    Console.WriteLine($"[{ DateTime.Now.ToLongTimeString()}] [{ level}] { func()} {string.Join(";", parameters.Select(p => p == null ? " " : p.ToString()))}  自定义日志{name}");
                }
                return true;
            });
        }
        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
