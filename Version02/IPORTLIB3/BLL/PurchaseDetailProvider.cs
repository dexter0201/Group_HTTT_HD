using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PurchaseDetailProvider
	{
		IPurchaseDetailRepository repository;
		internal PurchaseDetailProvider(IPurchaseDetailRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<PurchaseDetail> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public PurchaseDetail Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(PurchaseDetail obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(PurchaseDetail obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}