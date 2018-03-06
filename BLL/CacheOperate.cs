using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Blog
{
    public class CacheOperate
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return HttpRuntime.Cache[key];          
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static void SetCache(string key,object value)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert(key, value);
        }
        public static void SetCache(string key, object obj, TimeSpan Timeout)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert(key, obj, null, DateTime.MaxValue, Timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }

        public static void SetCache(string key, object obj, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert(key, obj, null, absoluteExpiration, slidingExpiration);
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">键名</param>
        public static void RemoveCache(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}
