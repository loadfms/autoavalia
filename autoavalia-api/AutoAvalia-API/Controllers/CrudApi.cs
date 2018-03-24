using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webmotors.Shared.Database;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
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
            new QuickRepository<T, TKey>().Add(value);
        }

        public void Put(TKey id, [FromBody]T value)
        {
            new QuickRepository<T, TKey>().Update(value);
        }

        public void Delete(TKey id)
        {
            new QuickRepository<T, TKey>().Delete(id);
        }
    }
}