using HiringAppAPI.Models.EntityFramework.Interfaces;
using HiringAppAPI.Models.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringAppAPI.Models.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPersonRepository<Person> Person { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Person = new PersonRepository<Person>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
