using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class DepartmentProvider
	{
		IDepartmentRepository repository;
		internal DepartmentProvider(IDepartmentRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Department> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Department Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Department obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Department obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
        public List<ReportUsersDepartments> ReportUsersDepartments()
        {
            return repository.ReportUsersDepartments();
        }
	}
}