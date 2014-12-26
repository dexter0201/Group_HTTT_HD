using DTO;
using System.Collections.Generic;
namespace IDAL
{
	public interface IUserEnrollRepository : IRepository<UserEnroll>
	{
        bool Insert(IEnumerable<UserEnroll> objs);
	}
}
