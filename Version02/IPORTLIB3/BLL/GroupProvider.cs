using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class GroupProvider
	{
		IGroupRepository repository;
		internal GroupProvider(IGroupRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Group> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Group Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Group obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Group obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}