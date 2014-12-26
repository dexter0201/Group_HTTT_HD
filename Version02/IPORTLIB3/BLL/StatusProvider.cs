using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class StatusProvider
	{
		IStatusRepository repository;
		internal StatusProvider(IStatusRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Status> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Status Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Status obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Status obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}