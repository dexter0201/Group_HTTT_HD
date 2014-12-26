using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Collections;
using System;

namespace BLL
{
    public abstract class AbstractProvider
    {
        protected static Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }
        protected static void PurgeCache(string prefix)
        {
            prefix = prefix.ToLower();
            List<string> items = new List<string>();
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
                    items.Add(enumerator.Key.ToString());
            }
            foreach (string itemToRemove in items)
                Cache.Remove(itemToRemove);
        }
        protected static void CacheData(string key, object data)
        {
            if (IDAL.Setting.EnableCaching && data != null)
            {
                Cache.Insert(key, data, null, DateTime.Now.AddSeconds(IDAL.Setting.CacheDuration), TimeSpan.Zero);
            }
        }
    }
}
