using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Questionnaire : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdvertiseId { get; set; }
    }
}