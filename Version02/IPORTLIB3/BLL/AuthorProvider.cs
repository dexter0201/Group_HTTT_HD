using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class AuthorProvider
	{
		IAuthorRepository repository;
		internal AuthorProvider(IAuthorRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Author> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Author Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Author obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Author obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
        public int Page()
        {
            return repository.Page(null);
        }
	}
}