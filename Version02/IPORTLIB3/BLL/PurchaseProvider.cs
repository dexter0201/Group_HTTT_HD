using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PurchaseProvider
	{
		IPurchaseRepository repository;
		internal PurchaseProvider(IPurchaseRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Purchase> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Purchase Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Purchase obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Purchase obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}