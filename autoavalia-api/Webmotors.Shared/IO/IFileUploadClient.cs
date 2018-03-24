using System;
using System.IO;

namespace Webmotors.Shared.IO
{
    public interface IFileUploadClient
    {
        Tuple<bool, string> Upload(Stream stream, string bucket, string name);
    }
}