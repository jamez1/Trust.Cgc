using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trust.Cgc.Core
{
    public class JobContainer
    {
        public JobViewModel Job { get; set; }
        public List<JobExecution> Executions { get; set; }
    }
}
