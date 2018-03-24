using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Webmotors.Shared.Caching
{
    public static class Cached
    {
        public static T Load<T>(string key, Func<string, T> action, int seconds = 100)
        {
            var memoryCache = CacheContainer.Instance.Cache;
            var already = memoryCache.Contains(key);

            if (already)
            {
                var cached = memoryCache.Get(key)?.ToString();
                var serialized = JsonConvert.DeserializeObject<T>(cached);
                return serialized;
            }

            return Store(key, action(key), seconds);
        }


        public static T Store<T>(string key, T value, int cacheTime)
        {
            var memoryCache = CacheContainer.Instance.Cache;
            var serialized = JsonConvert.SerializeObject(value);
            var expiration = DateTimeOffset.UtcNow.AddSeconds(cacheTime);
            memoryCache.Set(key, serialized, expiration);
            return value;
        }
    }
}
