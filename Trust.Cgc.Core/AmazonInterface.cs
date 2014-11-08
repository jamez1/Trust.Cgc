using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Trust.Cgc.Core
{
    public class Ec2Instance
    {

        public Ec2Instance(Instance instance)
        {
            PublicIpAddress = instance.PublicIpAddress;
            InstanceId = instance.InstanceId;
        }

        public string InstanceId { get; set; }
        public string PublicIpAddress { get; set; }
    }

    public class AmazonInterface
    {
        private readonly AmazonEC2Client ec2;

        public AmazonInterface()
        {
            ec2 = new AmazonEC2Client(Amazon.RegionEndpoint.APSoutheast2);
        }

        public void CreateInstance()
        {
            RequestSpotInstancesRequest requestRequest = new RequestSpotInstancesRequest();

            requestRequest.SpotPrice = "0.08";
            requestRequest.InstanceCount = 1;

            LaunchSpecification launchSpecification = new LaunchSpecification();
            launchSpecification.ImageId = "ami-e95c31d3";   // latest Windows AMI as of this writing
            launchSpecification.InstanceType = "t1.micro";

            requestRequest.LaunchSpecification = launchSpecification;

            RequestSpotInstancesResponse requestResult = ec2.RequestSpotInstances(requestRequest);
        }

        public IEnumerable<Ec2Instance> GetInstances()
        {

            DescribeInstancesRequest request = new DescribeInstancesRequest();
            DescribeInstancesResponse res = ec2.DescribeInstances(request);

            return res.Reservations
                .SelectMany(r=>r.Instances
                        .Select(i=>new Ec2Instance(i))
                    );
        }
    }
}
