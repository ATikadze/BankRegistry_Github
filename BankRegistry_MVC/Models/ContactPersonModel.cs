using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankRegistry_MVC.Models
{
    using Domain;
    public class ViewModelItem
    {
        public List<PositionModel> PositionModels { get; set; }
        public BankModel BankModel { get; set; }
        public ContactPersonModel ContactPersonModel { get; set; }
        public List<ContactPersonModel> ContactPersonModels { get; set; }
        public bool FromPost { get; set; } = false;
    }
    public class ContactPersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public PositionModel Position { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static explicit operator ContactPersonModel(ContactPerson cPerson)
        {
            return new ContactPersonModel()
            {
                ID = cPerson.ID,
                FirstName = cPerson.FirstName,
                LastName = cPerson.LastName,
                DateOfBirth = cPerson.DateOfBirth,
                PositionID = cPerson.PositionID,
                Position = (PositionModel)cPerson.Position
            };
        }

        public static explicit operator ContactPerson(ContactPersonModel cPersonModel)
        {
            return new ContactPerson()
            {
                ID = cPersonModel.ID,
                FirstName = cPersonModel.FirstName,
                LastName = cPersonModel.LastName,
                DateOfBirth = cPersonModel.DateOfBirth,
                PositionID = cPersonModel.PositionID
            };
        }
    }
}