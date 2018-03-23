using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Question : Entity
    {
		public int Order { get; set; }
		public string Avatar { get; set; }
		public string Description { get; set; }
        //public List<Answer> Answer { get; set; }
    }
}