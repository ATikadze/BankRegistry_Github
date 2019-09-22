using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Lazy<IBankRepository> RepositoryBank { get; }
        Lazy<IContactPersonRepository> RepositoryContactPerson { get; }
        Lazy<IPositionRepository> RepositoryPosition { get; }
        void Commit();
    }
}
