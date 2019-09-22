using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankRegistry_MVC.Models
{
    using Domain;
    public class BankModelItem
    {
        public List<BankModel> BankModels { get; set; }
    }

    public class BankModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public static explicit operator Bank(BankModel bankModel)
        {
            return new Bank()
            {
                ID = bankModel.ID,
                Name = bankModel.Name,
                URL = bankModel.URL
            };
        }

        public static explicit operator BankModel(Bank bank)
        {
            return new BankModel()
            {
                ID = bank.ID,
                Name = bank.Name,
                URL = bank.URL
            };
        }
    }
}