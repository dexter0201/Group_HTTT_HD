using System.Collections.Generic;
namespace IDAL
{
    public interface IRepository<T>
    {
        bool Insert(T obj);
        bool Delete(object id);
        bool Update(T obj);
        T Get(object id);
        IEnumerable<T> Gets(object obj = null);
        int Page(int pageSize, object obj);
        int Page(object obj);
        int Count(object obj);
    }
}
