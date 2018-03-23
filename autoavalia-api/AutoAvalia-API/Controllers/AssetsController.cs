using System.Web.Http;
using Amazon;
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

        public void UploadImage()
        {

        }
    }
}