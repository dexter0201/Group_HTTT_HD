using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class UnitProvider
	{
		IUnitRepository repository;
		internal UnitProvider(IUnitRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Unit> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Unit Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Unit obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Unit obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}