using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Answer : IEntity<long>
    {
		public long QuestionId { get; set; }
        public long QuestionnaireId { get; set; }
		public int PartId { get; set; }
        public string Photo { get; set; }
        public long Id { get; set; }
    }
}