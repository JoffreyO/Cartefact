using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cartefact.Models;
using Cartefact.ViewModels;

namespace Cartefact.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        [HttpGet]
        public ActionResult List()
        {
            if (Session["Id"] != null)
            {
                return View(ListCarViewModel.GetAll());
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
                return View();
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }

        [HttpPost]
        public ActionResult Add(Car c)
        {
            if (ModelState.IsValid)
            {

                using (Entities db = new Entities())
                {
                   
                    db.Car.Add(c);
                    db.SaveChanges();
                }
                ModelState.Clear();
               

            }
            return RedirectToAction("List");
        }

    }
}