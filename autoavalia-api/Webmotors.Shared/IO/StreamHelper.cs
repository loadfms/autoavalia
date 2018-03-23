using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Webmotors.Shared.IO
{
    public static class StreamHelper
    {
        public static Stream Create(string source)
        {
            var bytes = Convert.FromBase64String(source);
            var stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
