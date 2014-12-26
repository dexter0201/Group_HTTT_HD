using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class SupplierProvider
	{
		ISupplierRepository repository;
		internal SupplierProvider(ISupplierRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Supplier> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Supplier Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Supplier obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Supplier obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}