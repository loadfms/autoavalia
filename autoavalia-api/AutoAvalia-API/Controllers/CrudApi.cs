using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webmotors.Shared.Database;
using Webmotors.Shared.Database.NoSql;
using System.Web.Http.Cors;

namespace Webmotors.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class CrudApi<T> : CrudApi<T, string> where T : IEntity<string>
    {

    }
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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