using HiringAppAPI.Models.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringAppAPI.Models.EntityFramework.Repositories
{
    public class PersonRepository<T> : IPersonRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return query.SingleOrDefault(expression);
        }

        public IEnumerable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(expression).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
