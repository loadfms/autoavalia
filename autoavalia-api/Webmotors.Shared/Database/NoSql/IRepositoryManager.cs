using System.Collections.Generic;
using MongoDB.Driver;
using System;

namespace Webmotors.Shared.Database.NoSql
{
    public interface IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        bool Exists { get; }
        string Name { get; }
        void Drop();
        ValidateCollectionResult Validate();
    }

    public interface IRepositoryManager<T> : IRepositoryManager<T, string>
        where T : IEntity<string>
    { }
}
