using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class CurrencyProvider
	{
		ICurrencyRepository repository;
		internal CurrencyProvider(ICurrencyRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Currency> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Currency Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Currency obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Currency obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}