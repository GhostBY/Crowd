using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowd.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Find(int id);
        void Add(T item);
        void Update(T item);
        void Remove(int Id);
    }
}
