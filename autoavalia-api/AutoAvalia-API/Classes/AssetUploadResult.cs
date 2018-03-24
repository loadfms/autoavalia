namespace Webmotors.Api.Classes
{
    public class AssetUploadResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string BlobName { get; set; }

        public AssetUploadResult()
        {
            
        }

        public AssetUploadResult(bool sucess, string message, string blobName)
        {
            Success = sucess;
            Message = message;
            BlobName = blobName;
        }
    }
}