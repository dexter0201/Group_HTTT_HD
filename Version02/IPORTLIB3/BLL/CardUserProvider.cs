using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class CardUserProvider
	{
		ICardUserRepository repository;
		internal CardUserProvider(ICardUserRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<CardUser> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public CardUser Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(CardUser obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(CardUser obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}