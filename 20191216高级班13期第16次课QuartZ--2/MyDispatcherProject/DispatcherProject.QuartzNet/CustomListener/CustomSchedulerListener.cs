using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet.CustomListener
{
    public class CustomSchedulerListener : ISchedulerListener
    {
        public async Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"{jobDetail.Description} 被加入到Scheduler");
            });
        }

        public async Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"{jobKey} 被删除 ");
            });
        }

        public async Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobInterrupted");
            });
        }

        public async Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobPaused");
            });
        }

        public async Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobResumed");
            });
        }

        public async Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("this is JobScheduled");
            });
        }

        public async Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobsPaused");
            });
        }

        public async Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobsResumed");
            });
        }

        public async Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is JobUnscheduled");
            });
        }

        public async Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerError");
            });
        }

        public async Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerInStandbyMode");
            });
        }

        public async Task SchedulerShutdown(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerShutdown");
            });
        }

        public async Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerShuttingdown");
            });
        }

        public async Task SchedulerStarted(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerStarted");
            });
        }

        public async Task SchedulerStarting(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulerStarting");
            });
        }

        public async Task SchedulingDataCleared(CancellationToken cancellationToken = default)
        { 
            await Task.Run(() =>
            {
                Console.WriteLine($"this is SchedulingDataCleared");
            });

        }

        public async Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is TriggerFinalized");
            });
        }

        public async Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is TriggerPaused");
            });
        }

        public async Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"this is TriggerResumed");
            });
        }

        public async Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("this is TriggersPaused");
            });
        }

        public async Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("this is TriggersResumed");
            });
        }
    }
}
