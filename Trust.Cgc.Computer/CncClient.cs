using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trust.Cgc.Computer.CncServiceReference;

namespace Trust.Cgc.Computer
{
    public class CncClient
    {
        CncSoapClient client;

        public CncClient()
        {
            client = new CncServiceReference.CncSoapClient();
        }

        public JobViewModel FetchJob(string p)
        {
            return client.FetchJob(p);
        }

        internal void SendResults(string result, string console, long p)
        {
            client.JobComplete(result, console, p);
            //client.
        }
    }
}
