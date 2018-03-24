using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Answer : IEntity<long>
    {
        [BsonRepresentation(BsonType.Int64)]
        public long Id { get; set; }
		public long QuestionId { get; set; }
        public long QuestionnaireId { get; set; }
		public int PartId { get; set; }
        public string Photo { get; set; }
    }
}