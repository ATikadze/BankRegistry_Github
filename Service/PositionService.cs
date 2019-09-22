using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Domain.ServiceInterfaces;
    using Domain;
    public class PositionService : ServiceBase<Position>, IPositionService
    {
        public override void Remove(Position entity)
        {
            _unitOfWork.RepositoryPosition.Value.Remove(entity);
        }

        public override void Save(Position entity)
        {
            _unitOfWork.RepositoryPosition.Value.Save(entity);
        }

        public override IEnumerable<Position> Set()
        {
            return _unitOfWork.RepositoryPosition.Value.Set();
        }
    }
}
