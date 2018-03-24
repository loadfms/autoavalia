using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Answer : Entity
    {
        [BsonRepresentation(BsonType.ObjectId)] 
		public string QuestionId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)] 
        public string QuestionnaireId { get; set; }
		public int PartId { get; set; }
        public string Photo { get; set; }
        public bool Value { get; set; }
    }
}