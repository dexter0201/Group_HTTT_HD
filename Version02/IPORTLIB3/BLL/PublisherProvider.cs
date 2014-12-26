using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PublisherProvider
	{
		IPublisherRepository repository;
		internal PublisherProvider(IPublisherRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Publisher> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Publisher Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Publisher obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Publisher obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}