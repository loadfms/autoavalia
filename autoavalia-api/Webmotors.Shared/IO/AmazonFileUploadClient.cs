using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;

namespace Webmotors.Shared.IO
{
    public class AmazonFileUploadClient : IFileUploadClient
    {
        private string ApiKey { get; }
        private string ApiSecret { get; }

        public AmazonFileUploadClient(string apiKey, string apiSecret)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }


        public Tuple<bool, string> Upload(Stream stream, string bucket, string name)
        {
            try
            {
                using (stream)
                {
                    AmazonHelper.UploadFromStream(ApiKey, ApiSecret, stream, bucket, name);
                    return new Tuple<bool, string>(true, "Imagem enviada com sucesso");
                }
            }
            catch (AmazonS3Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
            catch (Exception)
            {
                return new Tuple<bool, string>(false, "Não foi possível enviar a imagem para o servidor");
            }
        }
    }
}
