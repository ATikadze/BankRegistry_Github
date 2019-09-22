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

    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id, string text = null)
        {
            #region Adding Positions (Enable only Once!)
            //PositionService positionService = new PositionService();
            //positionService.Save(new Position() { Name = "Bank Teller" });
            //positionService.Save(new Position() { Name = "Bank Marketing Representative" });
            //positionService.Save(new Position() { Name = "Internal Auditor" });
            //positionService.Save(new Position() { Name = "Branch Manager" });
            //positionService.Save(new Position() { Name = "Loan Officer" });
            //positionService.Save(new Position() { Name = "Data Processing Officer" });
            //positionService.Save(new Position() { Name = "General Director" });
            //positionService.Commit();
            #endregion

            BankService bankService = new BankService();
            if (id != null)
            {
                bankService.Remove(bankService.Set().Single(s => s.ID == id));
                bankService.Commit();
                return RedirectToAction("Index", new { id = (int?)null });
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                if (string.IsNullOrWhiteSpace(text))
                    return RedirectToAction("Index");
                BankModelItem newBankModel = new BankModelItem();
                newBankModel.BankModels = bankService.Set().Where(w => w.Name.ToLower().Contains(text.ToLower().Trim())).Select(s => (BankModel)s).ToList();
                return View(newBankModel);
            }

            return View(new BankModelItem() { BankModels = bankService.Set().Select(s => (BankModel)s).ToList() });
        }
    }
}