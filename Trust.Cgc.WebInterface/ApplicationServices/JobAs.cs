using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trust.Cgc.Core;

namespace Trust.Cgc.WebInterface.ApplicationServices
{
    public class JobAs
    {
        private static Lazy<JobAs> _instance = new Lazy<JobAs>();

        public static JobAs Instance { get { return _instance.Value; } }


        List<JobContainer> jobs = new List<JobContainer>();

        public JobViewModel GetJob(string computerId)
        {
            var jobContainer = jobs.FirstOrDefault(jc => jc.Executions.Count == 0);

            var newExecution = new JobExecution()
            {
                ExecutionTime = DateTime.Now,
                ComputerId = computerId
            };


            jobContainer.Executions.Add(newExecution);

            return jobContainer.Job;
        }


        public void CompleteJob(string results, string console, long id, string computerId)
        {
            var jobContainer = jobs.FirstOrDefault(jc => jc.Job.Id==id);

            var jobExecution = jobContainer.Executions.FirstOrDefault(je => je.ComputerId == computerId);

            jobExecution.Console = console;
            jobExecution.Output = results;
            jobExecution.Completed = true;
        }
    }
}