using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Domain.ServiceInterfaces;
    using Repository;
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class
    {
        protected UnitOfWork _unitOfWork;
        public ServiceBase()
        {
            _unitOfWork = UnitOfWork.Instance;
        }

        public abstract void Remove(TEntity entity);
        public abstract void Save(TEntity entity);
        public abstract IEnumerable<TEntity> Set();

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
