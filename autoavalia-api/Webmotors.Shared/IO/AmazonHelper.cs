using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace Webmotors.Shared.IO
{
    public static class AmazonHelper
    {
        public static void UploadFromDisk(string apiKey, string apiSecret, string path, string bucketName)
        {
            var utility = new TransferUtility(new AmazonS3Client(apiKey, apiSecret));
            utility.Upload(path, bucketName);
        }

        public static void UploadFromStream(string apiKey, string apiSecret, Stream stream, string bucket, string name)
        {
            var utility = new TransferUtility(new AmazonS3Client(apiKey, apiSecret, RegionEndpoint.USEast1));
            using (stream)
            {
                utility.Upload(stream, bucket, name);
            }
        }
    }
}
