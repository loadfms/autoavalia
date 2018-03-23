using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Webmotors.Shared.Database;
using Webmotors.Shared.Database.NoSql;

namespace AutoAvalia_API.Controllers
{
    public abstract class CrudApi<T, TKey> : ApiController where T : IEntity<TKey>
    {
        public List<T> Get()
        {
            return new QuickRepository<T, TKey>().ToList();
        }

        public T Get(TKey id)
        {
            return new QuickRepository<T, TKey>().GetById(id);
        }

        public void Post([FromBody]T value)
        {
        }

        public void Put(TKey id, [FromBody]T value)
        {
        }

        public void Delete(TKey id)
        {
        }
    }
}