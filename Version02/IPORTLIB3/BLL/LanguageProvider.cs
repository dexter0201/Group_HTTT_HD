using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class LanguageProvider
	{
		ILanguageRepository repository;
		internal LanguageProvider(ILanguageRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Language> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Language Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Language obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Language obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}