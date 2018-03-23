using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;

namespace Webmotors.Shared.Database
{
    [DataContract]
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity<string>
    {
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}
