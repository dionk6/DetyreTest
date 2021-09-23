using DetyreTest.Interface;
using DetyreTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DetyreTest.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DetyreTestDbContext _context;

        public Repository(DetyreTestDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);

        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicte, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(predicte);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T FindOne(Expression<Func<T, bool>> predicte)
        {
            return _context.Set<T>().FirstOrDefault(predicte);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T GetByStringId(string id)
        {
            return _context.Set<T>().Find(id);
        }


        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            try
            {
                _context.Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
