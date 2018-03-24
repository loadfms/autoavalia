using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Report : Entity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionnaireId { get; set; }

        public ReportState State { get; set; }
        public ReportHistory History { get; set; }
        public VehicleAdvert VehicleAdvert { get; set; }
        public List<ReportCluster> Clusters { get; set; }

        [BsonIgnore]
        public bool Error { get; set; }
        [BsonIgnore]
        public string Description { get; set; }
    }
}