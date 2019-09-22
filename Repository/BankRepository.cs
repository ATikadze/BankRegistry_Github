using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class BankRepository : RepositoryBase<Domain.Bank>, IBankRepository
    {
        public BankRepository(BankRegistryDbContext context) : base(context)
        {
        }
    }
}
