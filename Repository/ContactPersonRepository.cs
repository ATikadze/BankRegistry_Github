using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class ContactPersonRepository : RepositoryBase<Domain.ContactPerson>, IContactPersonRepository
    {
        public ContactPersonRepository(BankRegistryDbContext context) : base(context)
        {
        }
    }
}
