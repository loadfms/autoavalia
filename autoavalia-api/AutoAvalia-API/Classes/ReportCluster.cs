﻿using System.Collections.Generic;

namespace Webmotors.Api.Classes
{
    public class ReportCluster
    {
        public string Name { get; set; }
        public List<ReportAnswer> Answers { get; set; }
    }
}