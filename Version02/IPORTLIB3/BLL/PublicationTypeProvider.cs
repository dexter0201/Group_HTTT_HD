using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PublicationTypeProvider
	{
		IPublicationTypeRepository repository;
		internal PublicationTypeProvider(IPublicationTypeRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<PublicationType> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public PublicationType Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(PublicationType obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(PublicationType obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}