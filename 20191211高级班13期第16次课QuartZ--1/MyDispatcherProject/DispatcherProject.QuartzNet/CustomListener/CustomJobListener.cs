using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet.CustomListener
{
    public class CustomJobListener : IJobListener
    {
        public string Name => "CustomJobListener";

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                //便于我们自己添加自己的业务逻辑
                Console.WriteLine($"{DateTime.Now} this is JobExecutionVetoed");
            });
        }
         
        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"{DateTime.Now} this is JobToBeExecuted");
            });
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"{DateTime.Now} this is JobWasExecuted");
            });
        }
    }
}
