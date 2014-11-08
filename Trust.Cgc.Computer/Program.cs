using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;

namespace Trust.Cgc.Computer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CncServiceReference.CncSoapClient();

            var result = client.FetchJob("test");


            REngine engine = REngine.CreateInstance("");
            // REngine requires explicit initialization.
            // You can set some parameters.
            engine.Initialize();
        }
    }
}
