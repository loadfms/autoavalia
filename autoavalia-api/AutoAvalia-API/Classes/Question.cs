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
		public int Order { get; set; }
		public string Avatar { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		[BsonRepresentation(BsonType.ObjectId)] 
		public string IdCluster { get; set; }
	}
}