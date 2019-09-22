using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class PositionRepository : RepositoryBase<Domain.Position>, IPositionRepository
    {
        public PositionRepository(BankRegistryDbContext context) : base(context)
        {
        }
    }
}
