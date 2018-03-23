using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmotors.Shared.Database;

namespace AutoAvalia_API.Classes
{
    public class Question : Entity
    {
		public int Order { get; set; }
		public string Avatar { get; set; }
		public string Description { get; set; }
        //public List<Answer> Answer { get; set; }
    }
}