using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmotors.Shared.Database;

namespace AutoAvalia_API.Classes
{
    public class Question : Entity
    {
        public string Description { get; set; }
        public Answer Answer { get; set; }
    }
}