using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Domain.ServiceInterfaces;
    using Domain;
    public class ContactPersonService : ServiceBase<ContactPerson>, IContactPersonService
    {
        public override void Remove(ContactPerson entity)
        {
            _unitOfWork.RepositoryContactPerson.Value.Remove(entity);
        }

        public override void Save(ContactPerson entity)
        {
            _unitOfWork.RepositoryContactPerson.Value.Save(entity);
        }

        public override IEnumerable<ContactPerson> Set()
        {
            return _unitOfWork.RepositoryContactPerson.Value.Set();
        }
    }
}
