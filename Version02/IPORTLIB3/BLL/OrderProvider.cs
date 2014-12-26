using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class OrderProvider
	{
		IOrderRepository repository;
		internal OrderProvider(IOrderRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Order> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Order Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Order obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Order obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}