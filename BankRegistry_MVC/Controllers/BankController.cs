using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankRegistry_MVC.Controllers
{
    using Models;
    using Domain;
    using Service;
    using System.Web.Routing;

    public class BankController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(ViewModelItem viewModelItem)
        {
            PositionService positionService = new PositionService();
            viewModelItem.ContactPersonModel.PositionID = positionService.Set().First(s => s.Name.Equals("General Director")).ID;
            BankService bankService = new BankService();
            ContactPerson contactPerson = (ContactPerson)viewModelItem.ContactPersonModel;

            bankService.Save(new Bank()
            {
                Name = viewModelItem.BankModel.Name,
                URL = viewModelItem.BankModel.URL,
                ContactPersons = new List<ContactPerson>()
                {
                    contactPerson
                }
            });
            bankService.Commit();
            return RedirectToAction("NewContactPerson", new { bankId = bankService.Set().Last().ID });
        }

        [HttpGet]
        public ActionResult NewContactPerson(int bankId, int? contactPersonId)
        {
            if (contactPersonId != null)
            {
                ContactPersonService contactPersonService = new ContactPersonService();
                contactPersonService.Remove(contactPersonService.Set().Single(s => s.ID == contactPersonId));
                contactPersonService.Commit();

                return RedirectToAction("NewContactPerson", new { bankId, contactPersonId = (int?)null });
            }
            BankService bankService = new BankService();
            ViewModelItem viewModelItem = new ViewModelItem();
            PositionService positionService = new PositionService();
            viewModelItem.BankModel = (BankModel)bankService.Set().Single(s => s.ID == bankId);
            viewModelItem.PositionModels = positionService.Set().Select(s => (PositionModel)s).ToList();
            var list = bankService.Set().Single(s => s.ID == bankId).ContactPersons;
            viewModelItem.ContactPersonModels = bankService.Set().Single(s => s.ID == bankId).ContactPersons.Where(w => w.Position.Name != "General Director").Select(a => (ContactPersonModel)a).ToList();

            return View(viewModelItem);
        }

        [HttpPost]
        public ActionResult NewContactPerson(ViewModelItem viewModelItem, int bankId)
        {
            PositionService positionService = new PositionService();
            BankService bankService = new BankService();
            Bank bank = bankService.Set().Single(s => s.ID == bankId);
            ContactPerson contactPerson = (ContactPerson)viewModelItem.ContactPersonModel;
            contactPerson.PositionID = positionService.Set().Single(s => s.ID == viewModelItem.ContactPersonModel.Position.ID).ID;
            bank.ContactPersons.Add(contactPerson);
            bankService.Commit();

            return RedirectToAction("NewContactPerson", new { bankId = bankService.Set().Last().ID });
        }

        [HttpGet]
        public ActionResult Edit(int bankId)
        {
            ViewModelItem viewModelItem = new ViewModelItem();
            BankService bankService = new BankService();
            Bank bank = bankService.Set().Single(s => s.ID == bankId);
            viewModelItem.BankModel = (BankModel)bank;
            viewModelItem.ContactPersonModel = (ContactPersonModel)bankService.Set().Single(s => s.ID == bankId).ContactPersons.Single(s => s.Position.Name == "General Director");

            return View(viewModelItem);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelItem viewModelItem, DateTime BirthDate)
        {
            BankService bankService = new BankService();
            Bank bank = bankService.Set().Single(s => s.ID == viewModelItem.BankModel.ID);
            bank.Name = viewModelItem.BankModel.Name;
            bank.URL = viewModelItem.BankModel.URL;
            bankService.Commit();

            viewModelItem.ContactPersonModel.DateOfBirth = BirthDate;

            ContactPersonService contactPersonService = new ContactPersonService();
            ContactPerson contactPerson = contactPersonService.Set().Single(s => s.ID == viewModelItem.ContactPersonModel.ID);
            contactPerson.FirstName = viewModelItem.ContactPersonModel.FirstName;
            contactPerson.LastName = viewModelItem.ContactPersonModel.LastName;
            contactPerson.DateOfBirth = viewModelItem.ContactPersonModel.DateOfBirth;
            contactPersonService.Commit();

            viewModelItem.FromPost = true;

            return View(viewModelItem);
        }
    }
}