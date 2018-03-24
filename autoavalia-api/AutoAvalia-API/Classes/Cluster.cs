using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
	public class Cluster: IEntity<long>
	{
	    [BsonRepresentation(BsonType.Int64)]
	    public long Id { get; set; }
	    public string Name { get; set; }
	    public string Alias { get; set; }
	    public string Description { get; set; }


	    [BsonIgnore]
        public List<Question> QuestionList { get; set; }
	    [BsonIgnore]
        public List<Answer> AnswerList { get; set; }

        // Calculated Properties
	    [BsonIgnore]
        public int QuestionsAnswered => AnswerList?.Count ?? 0;
	    [BsonIgnore]
        public int Questions => QuestionList?.Count ?? 0;
	    [BsonIgnore]
        public int Completeness =>
	        Questions > 0 ? Convert.ToInt32((QuestionsAnswered/Questions)*100) : 0;
	}
}