using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donald.BurgerClub.Settings
{
    public class AWSConfiguration
    {
        public string AwsAccessKeyId { get; set; }

        public string AwsSecretAccessKey { get; set;}

        public string AwsS3BucketName { get; set; }

        public string AwsS3RegionName { get; set; }
    }
}
