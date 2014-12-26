using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class OrderDetailProvider
	{
		IOrderDetailRepository repository;
		internal OrderDetailProvider(IOrderDetailRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<OrderDetail> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public OrderDetail Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(OrderDetail obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(OrderDetail obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}