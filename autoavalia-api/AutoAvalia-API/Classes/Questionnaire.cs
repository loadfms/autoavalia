using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Questionnaire : IEntity<long>
    {
        [BsonRepresentation(BsonType.Int64)]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int AdvertiseId { get; set; }
        [BsonIgnore]
        public List<Cluster> clusterList { get; set; }
        
    }
}