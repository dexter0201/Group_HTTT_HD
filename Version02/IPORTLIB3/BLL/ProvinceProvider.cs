using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class ProvinceProvider : AbstractProvider
	{
		IProvinceRepository repository;
		internal ProvinceProvider(IProvinceRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Province> Gets(object obj = null)
		{
            IEnumerable<Province> provinces = null;
            string key = "privince_Gets";
            if (Cache[key] != null)
            {
                provinces = (IEnumerable<Province>)Cache[key];
            }
            else
            {
                provinces = repository.Gets(obj);
                CacheData(key, provinces);
            }
            return provinces;
		}
		public Province Get(object id)
		{
            Province province = null;
            string key = "province_Get_" + id;
            if (Cache[key] != null)
            {
                province = (Province)Cache[key];
            }
            else
            {
                province = repository.Get(id);
            }
            return province;
		}
		public bool Update(Province obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Province obj)
		{
            string key = "privince";
            PurgeCache(key);
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
            string key = "privince";
            PurgeCache(key);
			return repository.Delete(id);
		}
	}
}