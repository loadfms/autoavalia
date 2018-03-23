using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Webmotors.Shared.Database.NoSql
{
    public class MongoRepositoryManager<T, TKey> : IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        private readonly MongoCollection<T> _collection;

        public MongoRepositoryManager()
            : this(MongoUtility<TKey>.GetDefaultConnectionString())
        {
        }

        public MongoRepositoryManager(string connectionString)
        {
            _collection = MongoUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        public MongoRepositoryManager(string connectionString, string collectionName)
        {
            _collection = MongoUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
        }

        public virtual bool Exists => _collection.Exists();

        public virtual string Name => _collection.Name;

        public virtual void Drop()
        {
            _collection.Drop();
        }

        public virtual ValidateCollectionResult Validate()
        {
            return _collection.Validate();
        }
    }

    public class MongoRepositoryManager<T> : MongoRepositoryManager<T, string>, IRepositoryManager<T>
        where T : IEntity<string>
    {
        public MongoRepositoryManager()
        { }

        public MongoRepositoryManager(string connectionString)
            : base(connectionString) { }

        public MongoRepositoryManager(string connectionString, string collectionName)
            : base(connectionString, collectionName) { }
    }
}
