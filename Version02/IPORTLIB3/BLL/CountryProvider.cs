using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class CountryProvider
	{
		ICountryRepository repository;
		internal CountryProvider(ICountryRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Country> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Country Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Country obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Country obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}