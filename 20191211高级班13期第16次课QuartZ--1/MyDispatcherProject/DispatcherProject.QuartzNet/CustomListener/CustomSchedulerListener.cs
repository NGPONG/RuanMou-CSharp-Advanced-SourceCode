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

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("this is JobScheduled");
            });
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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

        public Task SchedulingDataCleared(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
