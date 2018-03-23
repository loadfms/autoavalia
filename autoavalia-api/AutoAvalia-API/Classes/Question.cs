using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAvalia_API.Classes
{
    public class Question
    {
        public string Description { get; set; }
        public int Part { get; set; }
        public List<Answer> Answer { get; set; }
    }
}