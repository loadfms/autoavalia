using MongoDB.Bson.Serialization.Attributes;

namespace Webmotors.Shared.Database
{
    public interface IEntity<TKey>
    {
        [BsonId]
        TKey Id { get; set; }
    }

    public interface IEntity : IEntity<string>
    {
    }
}
