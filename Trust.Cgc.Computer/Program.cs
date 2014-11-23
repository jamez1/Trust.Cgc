using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RDotNet;

namespace Trust.Cgc.Computer
{
    class Program
    {
        static void Main(string[] args)
        {
            var cncClient = new CncClient();
            var amazonUtils = new AmazonUtils();
            var r = new RFramework();

            var id = amazonUtils.GetId();

            while (true)
            {
                var job = cncClient.FetchJob(id);

                if (job != null)
                {
                    string console;

                    foreach (var library in job.Libraries)
                        r.LoadLibrary(library);

                    foreach (var param in job.Params)
                        r.SetVar(param.Name, param.Value);
                    
                    r.Execute(job.Script,out console);

                    var result = r.GetVarAsCSV("output");

                    cncClient.SendResults(result, console, job.Id);
                }

                Thread.Sleep(10000);
            }

            Console.ReadKey();
        }
    }
}
