using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HiringAppAPI.Models.EntityFramework.Interfaces
{
    public interface IPersonRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Find(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null);
    }
}
