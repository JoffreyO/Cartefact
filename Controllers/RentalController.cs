using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cartefact.Models;
using Cartefact.ViewModels;

namespace Cartefact.Controllers
{
    public class RentalController : Controller
    {
        public ActionResult List()
        {
           
            if (Session["Id"] != null)
            {
                return View(new ListRentalViewModel());
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }
   
        
        public ActionResult Add()
        {
            
            if (Session["Id"] != null)
            {
                return View(new AddRentalViewModel());
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }

        [HttpPost]
        public ActionResult Add(AddRentalViewModel model)
        {
            try
            {
                using (Entities context = new Entities())
                {
                    var rental = new Rental();

                    rental.StartDate = model.StartDate;
                    rental.EndDate = model.EndDate;

                    rental.EstimatedKilometers = model.EstimatedKilometers;
                    rental.CarId = model.CarId;
                    rental.PersonId = (int)Session["Id"];

                    context.Rental.Add(rental);
                    context.SaveChanges();

                }
                return RedirectToAction("List");
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult History()
        {
            if (Session["Id"] != null)
            {
                return View(new HistoryRentalViewModel());
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }
    }
}