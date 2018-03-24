using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class ReportHistory
    {
        public int OnwerQuantity { get; set; }
        public bool Accidents { get; set; }
        public int Roberry { get; set; }
        public bool Auction { get; set; }
        public bool Recall { get; set; }
    }
}