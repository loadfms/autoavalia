using System;

namespace Webmotors.Api.Classes
{
    public class AssetUploadResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public AssetUploadResult()
        {
            
        }

        public AssetUploadResult(bool sucess, string message)
        {
            Success = sucess;
            Message = message;
        }

        public AssetUploadResult(Tuple<bool, string> tuple) : this(tuple.Item1, tuple.Item2)
        {
        }
    }
}