using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        private BankRegistryDbContext _context;
        public RepositoryBase(BankRegistryDbContext context)
        {
            _context = context;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Set()
        {
            return _context.Set<TEntity>();
        }
    }
}
