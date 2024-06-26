using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire_Authorization_Demo.Controllers
{
    //[Route("api/[controller
    [Route("api/hangfireinterface")]
    [ApiController]
    public class HangfireInterfaceController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        public HangfireInterfaceController(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet]
        [Route("IFireAndForgetJob")]
        public string FireAndForgetJob()
        {
            //Fire - and - Forget Jobs
            //Fire - and - forget jobs are executed only once and almost immediately after creation.
            var jobId = _backgroundJobClient.Enqueue(() => Console.WriteLine("Welcome user in Fire and Forget Job Demo!"));

            return $"Job ID: {jobId}. Welcome user in Fire and Forget Job Demo!";
        }

        [HttpGet]
        [Route("IDelayedJob")]
        public string DelayedJob()
        {
            //Delayed Jobs
            //Delayed jobs are executed only once too, but not immediately, after a certain time interval.
            var jobId = _backgroundJobClient.Schedule(() => Console.WriteLine("Welcome user in Delayed Job Demo!"), TimeSpan.FromSeconds(60));

            return $"Job ID: {jobId}. Welcome user in Delayed Job Demo!";
        }

        [HttpGet]
        [Route("IContinuousJob")]
        public string ContinuousJob()
        {
            //Fire - and - Forget Jobs
            //Fire - and - forget jobs are executed only once and almost immediately after creation.
            var parentjobId = _backgroundJobClient.Enqueue(() => Console.WriteLine("Welcome user in Fire and Forget Job Demo!"));

            //Continuations
            //Continuations are executed when its parent job has been finished.
            BackgroundJob.ContinueJobWith(parentjobId, () => Console.WriteLine("Welcome user in Continuos Job Demo!"));

            return "Welcome user in Continuos Job Demo!";
        }

        [HttpGet]
        [Route("IRecurringJob")]
        public string RecurringJobs()
        {
            //Recurring Jobs
            //Recurring jobs fire many times on the specified CRON schedule.
            _recurringJobManager.AddOrUpdate("HangfireInterface", () => Console.WriteLine("Welcome user in Recurring Job Demo!"), Cron.MinuteInterval(2));

            return "Welcome user in Recurring Job Demo!";
        }
    }
}
