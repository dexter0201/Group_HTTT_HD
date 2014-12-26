using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class UserEnrollProvider
	{
		IUserEnrollRepository repository;
		internal UserEnrollProvider(IUserEnrollRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<UserEnroll> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public UserEnroll Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(UserEnroll obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(UserEnroll obj)
		{
			return repository.Insert(obj);
		}
        public bool Insert(IEnumerable<UserEnroll> objs)
        {
            return repository.Insert(objs);
        }
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}