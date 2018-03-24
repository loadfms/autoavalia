using System;
using System.Runtime.Caching;

namespace Webmotors.Shared.Caching
{
    public sealed class CacheContainer
    {
        private static readonly Lazy<CacheContainer> lazy =
            new Lazy<CacheContainer>(() => new CacheContainer());

        public static CacheContainer Instance => lazy.Value;

        public MemoryCache Cache { get; set; }

        private CacheContainer()
        {
            
        }

        public void Initialize()
        {
            Cache = new MemoryCache("sharedCacheContainer");
        }
    }
}
