using System;
using System.Runtime.Caching;

namespace Webmotors.Shared.Caching
{
    public sealed class CacheContainer
    {
        private static readonly Lazy<CacheContainer> Lazy =
            new Lazy<CacheContainer>(() => new CacheContainer());

        public static CacheContainer Instance => Lazy.Value;

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
