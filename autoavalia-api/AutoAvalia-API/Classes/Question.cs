using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAvalia_API.Classes
{
    public class Question
    {
        public string Description { get; set; }
        public Answer Answer { get; set; }
    }
}