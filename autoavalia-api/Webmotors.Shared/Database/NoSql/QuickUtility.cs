using MongoDB.Driver;
using System;
using System.Configuration;

namespace Webmotors.Shared.Database.NoSql
{
    internal static class QuickUtility<TU>
    {
        private const string DefaultConnectionstringName = "MongoDbConnectionString";

        public static string GetDefaultConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[DefaultConnectionstringName].ConnectionString;
        }

        private static MongoDatabase GetDatabaseFromUrl(MongoUrl url)
        {
            var client = new MongoClient(url);
            var server = client.GetServer();
            return server.GetDatabase(url.DatabaseName);
        }

             public static MongoCollection<T> GetCollectionFromConnectionString<T>(string connectionString)
            where T : IEntity<TU>
        {
            return GetCollectionFromConnectionString<T>(connectionString, GetCollectionName<T>());
        }

            public static MongoCollection<T> GetCollectionFromConnectionString<T>(string connectionString, string collectionName)
            where T : IEntity<TU>
        {
            return GetDatabaseFromUrl(new MongoUrl(connectionString))
                .GetCollection<T>(collectionName);
        }

        public static MongoCollection<T> GetCollectionFromUrl<T>(MongoUrl url)
            where T : IEntity<TU>
        {
            return GetCollectionFromUrl<T>(url, GetCollectionName<T>());
        }

        public static MongoCollection<T> GetCollectionFromUrl<T>(MongoUrl url, string collectionName)
            where T : IEntity<TU>
        {
            return GetDatabaseFromUrl(url)
                .GetCollection<T>(collectionName);
        }

        private static string GetCollectionName<T>() where T : IEntity<TU>
        {
            var collectionName = typeof(T).BaseType == typeof(object) ? GetCollectioNameFromInterface<T>() : GetCollectionNameFromType(typeof(T));

            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentException("Collection name cannot be empty for this entity");

            return collectionName;
        }

        private static string GetCollectioNameFromInterface<T>()
        {
            var att = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionName));
            var collectionname = att != null ? ((CollectionName)att).Name : typeof(T).Name;
            return collectionname;
        }

        private static string GetCollectionNameFromType(Type entitytype)
        {
            string collectionname;

            var att = Attribute.GetCustomAttribute(entitytype, typeof(CollectionName));
            if (att != null)
            {
                collectionname = ((CollectionName)att).Name;
            }
            else
            {
                if (typeof(Entity).IsAssignableFrom(entitytype))
                {
                    while (entitytype?.BaseType != typeof(Entity))
                    {
                        entitytype = entitytype?.BaseType;
                    }
                }
                collectionname = entitytype.Name;
            }

            return collectionname;
        }
    }
}
