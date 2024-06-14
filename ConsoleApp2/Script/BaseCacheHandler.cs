using DBModel.Model;
using System.Collections.Concurrent;

namespace Script
{
    public abstract class BaseCacheHandler<T>
    {
        public ConcurrentDictionary<string, T> Cache;

        public BaseCacheHandler()
        {
            Cache = new ConcurrentDictionary<string, T>();
            InitData();
        }
        public abstract void InitData();

        public bool AddToCache(string key, T cacheItem)
        {
            return Cache.TryAdd(key, cacheItem);

        }

        public void ClearCache()
        {
            Cache?.Clear();
        }

        public T GetCacheItemByKey(string cacheKey)
        {
            if (Cache.TryGetValue(cacheKey, out T cacheItem))
            {
                return cacheItem;
            }

            return default(T);
        }


        public void AddOrUpdateCache(string cacheKey, T cacheItem)
        {
            Cache.AddOrUpdate(cacheKey, cacheItem, (key, oldValue) => cacheItem);

        }


        public int GetCacheCount()
        {
            return Cache.Count;
        }


        public List<string> GetCacheAllKeys()
        {
            return Cache.Keys.ToList();
        }

        public bool RemoveByKey(string key)
        {
            return Cache.TryRemove(key, out T cacheItem);
        }
    }
}
