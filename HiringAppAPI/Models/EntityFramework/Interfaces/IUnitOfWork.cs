using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringAppAPI.Models.EntityFramework.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository<Person> Person { get; }

        int Complete();
    }
}
