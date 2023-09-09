using Microsoft.Extensions.Logging;
using Quartz;

namespace PathIkAPI.Scheduler.Jobs
{
    public class UserActiveJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap data = context.JobDetail.JobDataMap;
            Console.WriteLine($"{data.GetString("ad")} icin kod calisti task tamamlandi");

            return Task.CompletedTask;
        }
    }
}
