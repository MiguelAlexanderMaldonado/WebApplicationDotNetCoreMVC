using System.Collections.Generic;

namespace WebApplication.Services
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Edit(T item);
    }
}
