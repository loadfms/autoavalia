using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Questionnaire : Entity
    {
        public int UserId { get; set; }
        public int AdvertiseId { get; set; }
        public bool Finished { get; set; }

        [BsonIgnore]
        public List<Cluster> ClusterList { get; set; }
    }
}