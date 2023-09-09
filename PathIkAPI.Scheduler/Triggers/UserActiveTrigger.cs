using PathIkAPI.Scheduler.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathIkAPI.Scheduler.Triggers
{
    public class UserActiveTrigger
    {
        private async Task<IScheduler> StartAsync()
        {

            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = await schedFact.GetScheduler();
            if (!sched.IsStarted)
                await sched.Start();

            return sched;
        }

        public async Task TriggerActiveUserAsync(string name)
        {
            IScheduler sched = await StartAsync();

            IJobDetail jobDetail = JobBuilder
                .Create<UserActiveJob>()
                .WithIdentity("UserActiveJob")
                .UsingJobData("ad", name)
                .Build();


            ISimpleTrigger TriggerDersGorev = (ISimpleTrigger)TriggerBuilder
                .Create()
                .WithIdentity("UserActiveJob")
                .StartAt(DateTime.UtcNow.AddMilliseconds(3000))
                .WithSimpleSchedule(x => 
                    x.WithIntervalInSeconds(5)
                    .WithRepeatCount(1)
                 )
                .Build();

            await sched.ScheduleJob(jobDetail, TriggerDersGorev);
        }
        /*
         * var jobKey = JobKey.Create(nameof(UserActiveJob));
         * 
         */
    }
}
