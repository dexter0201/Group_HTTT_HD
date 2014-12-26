using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class TopicProvider
	{
		ITopicRepository repository;
		internal TopicProvider(ITopicRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Topic> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Topic Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Topic obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Topic obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}