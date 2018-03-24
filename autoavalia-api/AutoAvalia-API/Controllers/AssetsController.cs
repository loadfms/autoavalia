using System.Web.Http;
using Amazon;
using Webmotors.Api.Classes;
using Webmotors.Shared.IO;

namespace Webmotors.Api.Controllers
{
    public class AssetsController : ApiController
    {
        private IFileUploadClient Client { get; }

        public AssetsController()
        {
            Client = new AmazonFileUploadClient("", "");
        }

        public AssetUploadResult UploadImage(string bucket, string name)
        {
            var stream = StreamHelper.Create("");

            using (stream)
            {
                var response = Client.Upload(stream, bucket, name);
                return new AssetUploadResult(response);
            }
        }
    }
}