using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DetyreTest.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        T GetByStringId(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicte, params Expression<Func<T, object>>[] includes);
        T FindOne(Expression<Func<T, bool>> predicte);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<int> Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<int> SaveChanges();
    }
}
