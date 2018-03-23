using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Webmotors.Shared.Database.NoSql
{
    public class MongoRepository<T, TKey> : IRepository<T, TKey>
        where T : IEntity<TKey>
    {
        protected internal MongoCollection<T> DbCollection;

        public MongoRepository()
            : this(MongoUtility<TKey>.GetDefaultConnectionString())
        {
        }

        public MongoRepository(string connectionString)
        {
            DbCollection = MongoUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        public MongoRepository(string connectionString, string collectionName)
        {
            DbCollection = MongoUtility<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
        }

        public MongoRepository(MongoUrl url)
        {
            DbCollection = MongoUtility<TKey>.GetCollectionFromUrl<T>(url);
        }

        public MongoRepository(MongoUrl url, string collectionName)
        {
            DbCollection = MongoUtility<TKey>.GetCollectionFromUrl<T>(url, collectionName);
        }

        public MongoCollection<T> Collection => DbCollection;

        public string CollectionName => DbCollection.Name;

        public virtual T GetById(TKey id)
        {
            return typeof(T).IsSubclassOf(typeof(Entity)) ? GetById(new ObjectId(id as string)) : DbCollection.FindOneByIdAs<T>(BsonValue.Create(id));
        }

        public virtual T GetById(ObjectId id)
        {
            return DbCollection.FindOneByIdAs<T>(id);
        }

        public virtual T Add(T entity)
        {
            DbCollection.Insert<T>(entity);

            return entity;
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            DbCollection.InsertBatch<T>(entities);
        }

        public virtual T Update(T entity)
        {
            DbCollection.Save<T>(entity);

            return entity;
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbCollection.Save<T>(entity);
            }
        }

        public virtual void Delete(TKey id)
        {
            DbCollection.Remove(typeof(T).IsSubclassOf(typeof(Entity))
                ? Query.EQ("_id", new ObjectId(id as string))
                : Query.EQ("_id", BsonValue.Create(id)));
        }

        public virtual void Delete(ObjectId id)
        {
            DbCollection.Remove(Query.EQ("_id", id));
        }

        public virtual void Delete(T entity)
        {
            Delete(entity.Id);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var entity in DbCollection.AsQueryable().Where(predicate))
            {
                Delete(entity.Id);
            }
        }

        public virtual void DeleteAll()
        {
            DbCollection.RemoveAll();
        }

        public virtual long Count()
        {
            return DbCollection.Count();
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return DbCollection.AsQueryable().Any(predicate);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return DbCollection.AsQueryable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return DbCollection.AsQueryable().GetEnumerator();
        }

        public virtual Type ElementType => DbCollection.AsQueryable().ElementType;

        public virtual Expression Expression => DbCollection.AsQueryable().Expression;

        public virtual IQueryProvider Provider => DbCollection.AsQueryable().Provider;
    }

    public class MongoRepository<T> : MongoRepository<T, string>, IRepository<T>
        where T : IEntity<string>
    {
        public MongoRepository()
        { }

        public MongoRepository(MongoUrl url)
            : base(url) { }

        public MongoRepository(MongoUrl url, string collectionName)
            : base(url, collectionName) { }

        public MongoRepository(string connectionString)
            : base(connectionString) { }

        public MongoRepository(string connectionString, string collectionName)
            : base(connectionString, collectionName) { }
    }
}
