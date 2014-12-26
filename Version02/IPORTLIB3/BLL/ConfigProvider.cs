using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class ConfigProvider
	{
		IConfigRepository repository;
		internal ConfigProvider(IConfigRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Config> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Config Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Config obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Config obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}