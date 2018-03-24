using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Answer : Entity
    {
		public string QuestionId { get; set; }
        public long QuestionnaireId { get; set; }
		public int PartId { get; set; }
        public string Photo { get; set; }
    }
}