using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class CourseProvider
	{
		ICourseRepository repository;
		internal CourseProvider(ICourseRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Course> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Course Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Course obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Course obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}