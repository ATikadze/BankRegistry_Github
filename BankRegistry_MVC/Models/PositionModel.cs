using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankRegistry_MVC.Models
{
    using Domain;
    public class PositionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static explicit operator Position(PositionModel positionModel)
        {
            return new Position()
            {
                ID = positionModel.ID,
                Name = positionModel.Name
            };
        }

        public static explicit operator PositionModel(Position position)
        {
            return new PositionModel()
            {
                ID = position.ID,
                Name = position.Name
            };
        }
    }
}