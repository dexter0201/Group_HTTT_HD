using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PublicationProvider
	{
		IPublicationRepository repository;
		internal PublicationProvider(IPublicationRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Publication> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Publication Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Publication obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Publication obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}