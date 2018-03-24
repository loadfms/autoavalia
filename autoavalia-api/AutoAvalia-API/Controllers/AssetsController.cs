using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Webmotors.Api.Classes;
using Webmotors.Shared.IO;

namespace Webmotors.Api.Controllers
{
    public class AssetsController : ApiController
    {
        private const string AmazonS3ApiKeyConnectionString = "AmazonS3ApiKey";
        private const string AmazonS3ApiSecretConnectionString = "AmazonS3ApiSecret";
        private IFileUploadClient Client { get; }

        public AssetsController()
        {
            Client = new AmazonFileUploadClient(
                ConfigurationManager
                    .ConnectionStrings[AmazonS3ApiKeyConnectionString]
                    .ConnectionString,
                ConfigurationManager
                    .ConnectionStrings[AmazonS3ApiSecretConnectionString]
                    .ConnectionString
            );
        }

		[Route("api/assets/upload")]
		[HttpPost]
        public AssetUploadResult UploadImage()
        {
			string bucket = "autoavalia";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    using (var stream = httpPostedFile.InputStream)
                    {
                        var blobName = $"{Guid.NewGuid().ToString().Substring(0,8)}-{httpPostedFile.FileName}";
                        var response = Client.Upload(stream, bucket, blobName);
                        return new AssetUploadResult(response.Item1, response.Item2, blobName);
                    }
                }
            }
            return new AssetUploadResult(false, "Não foram encontradas imagens na requisição", string.Empty);
        }
    }
}