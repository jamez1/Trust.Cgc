using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Trust.Cgc.Core;

namespace Trust.Cgc.WebInterface
{
    /// <summary>
    /// Summary description for Cnc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Cnc : System.Web.Services.WebService
    {

        [WebMethod]
        public JobViewModel FetchJob(string identifier)
        {
            return null;

            var output = new JobViewModel();

            output.Params = new List<JobViewModel.ParamViewModel>();
            output.Params.Add(
                new JobViewModel.ParamViewModel(){
                    Name="test", 
                    Value= "testVal"
                });

            return output;
        }


        [WebMethod]
        public bool JobComplete(string results, string console, long id, string computerId)
        {
            

            return true;
        }
    }
}
