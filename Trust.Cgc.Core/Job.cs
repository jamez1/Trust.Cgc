using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trust.Cgc.Core
{
    public class JobViewModel
    {
        public string Script { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Id { get; set; }

        public List<ParamViewModel> Params { get; set; }
        public List<string> Libraries { get; set; }

        public class ParamViewModel
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
