using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class BookProvider
	{
		IBookRepository repository;
		internal BookProvider(IBookRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Book> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Book Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Book obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Book obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}