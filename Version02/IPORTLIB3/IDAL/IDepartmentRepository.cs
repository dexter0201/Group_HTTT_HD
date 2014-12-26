using DTO;
using System.Collections.Generic;
namespace IDAL
{
	public interface IDepartmentRepository : IRepository<Department>
	{
        List<ReportUsersDepartments> ReportUsersDepartments();
	}
}
