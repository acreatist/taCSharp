using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDb.Repositories
{
    public interface IRepository<T>
    {
        T Add(T item);
        void Update(int id, T item); 
        T Delete(int id);
        T Delete(T item);
        T Get(int id);
        IQueryable<T> All(); 
        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
