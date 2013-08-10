namespace MusicCollection.Repositories
{
    using System;
    using System.Linq;

    public interface IRepository<T>
    {
        T Add(T item, int parentId = 0);
        T Update(int id, T item);
        void Delete(int id);
        void Delete(T item);
        T Get(int id);
        IQueryable<T> All();
        //IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
