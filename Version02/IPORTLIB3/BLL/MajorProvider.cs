using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class MajorProvider
	{
		IMajorRepository repository;
		internal MajorProvider(IMajorRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Major> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Major Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Major obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Major obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}