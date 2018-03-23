using Webmotors.Shared.Database;

namespace AutoAvalia_API.Classes
{
    public class Answer : Entity
    {
        public int User { get; set; }
        public bool Value { get; set; }
        public string Photo { get; set; }
    }
}