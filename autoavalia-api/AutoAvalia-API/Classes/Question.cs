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
    public class Question : IEntity<long>
    {
		[JsonProperty]
		[BsonRepresentation(BsonType.ObjectId)]
		public long Id { get; set; }
		[JsonProperty]
		public int Order { get; set; }
		[JsonProperty]
		public string Avatar { get; set; }
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string Description { get; set; }
		[JsonProperty]
		public long IdCluster { get; set; }
	}
}