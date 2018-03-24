using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace Webmotors.Api.Classes
{
    public class ReportCluster
    {
        public string Name { get; set; }
        public List<ReportAnswer> Answers { get; set; }
        public int Warnings => Answers?.Count ?? 0;

        [BsonIgnore]
        public string Alias { get; set; }


        [BsonIgnore]
        public string Description { get; set; }
    }
}