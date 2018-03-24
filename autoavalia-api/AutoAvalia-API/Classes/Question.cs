using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Question : Entity
    {
		[JsonProperty]
		public int Order { get; set; }
		[JsonProperty]
		public string Avatar { get; set; }
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string Description { get; set; }
		[JsonProperty]
		public string IdCluster { get; set; }
	}
}