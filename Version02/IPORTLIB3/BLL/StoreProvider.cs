using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class StoreProvider
	{
		IStoreRepository repository;
		internal StoreProvider(IStoreRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Store> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Store Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Store obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Store obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}