using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trust.Cgc.Computer
{
    public class AmazonUtils
    {
        private string instanceIdUrl = "http://169.254.169.254/latest/meta-data/instance-id";

        public string GetId()
        {
            return "test";


            string InstanceId;
            try
            {
                InstanceId = new StreamReader(HttpWebRequest.Create
                                        (instanceIdUrl)
                                        .GetResponse().GetResponseStream())
                                        .ReadToEnd();
            }
            catch (WebException)
            {
                return "Error";
            }
            return InstanceId;
        }
    }
}
