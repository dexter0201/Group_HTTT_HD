using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class PeriodProvider
	{
		IPeriodRepository repository;
		internal PeriodProvider(IPeriodRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Period> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Period Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Period obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Period obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}