using MongoDB.Driver;

namespace Webmotors.Shared.Database.NoSql
{
    public class QuickRepositoryManager<T, TKey> : IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        private readonly MongoCollection<T> _collection;

        public QuickRepositoryManager()
            : this(QuickUtility<TKey>.GetDefaultConnectionString())
        {
        }

        public QuickRepositoryManager(string connectionString)
        {
            _collection = QuickUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        public QuickRepositoryManager(string connectionString, string collectionName)
        {
            _collection = QuickUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
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

    public class QuickRepositoryManager<T> : QuickRepositoryManager<T, string>, IRepositoryManager<T>
        where T : IEntity<string>
    {
        public QuickRepositoryManager()
        { }

        public QuickRepositoryManager(string connectionString)
            : base(connectionString) { }

        public QuickRepositoryManager(string connectionString, string collectionName)
            : base(connectionString, collectionName) { }
    }
}
