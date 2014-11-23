using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trust.Cgc.Core
{
    public class JobExecution
    {
        public DateTime ExecutionTime { get; set; }
        public bool Completed {get;set;}
        public string Console { get; set; }
        public string Output { get; set; }
        public string ComputerId { get; set; }
    }
}
