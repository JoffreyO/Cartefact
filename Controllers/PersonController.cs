using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cartefact.Models;
using Cartefact.ViewModels;

namespace Cartefact.Controllers
{
    public class PersonController : Controller
    {
    
        [HttpGet]
        public ActionResult List()
        {
            return View(ListPersonViewModel.GetAll());
        }

        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Person account)
        {
            if (ModelState.IsValid)
            {

                    using (Entities db = new Entities())
                    {
                        account.Role = "1";
                        db.Person.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.Name + " " + account.NickName + " successfully registration";

                
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Id"] != null )
            {
                if ((string) Session["Role"] ==  "1")
                {
                    return View(new CreatePersonViewModel());
                }
                else
                {
                    return RedirectToAction("Index", "AccessDenied");
                }
               
            }
            else
            {
                 return RedirectToAction("Index", "AccessDenied");
            }
            
        }

        [HttpPost]
        public ActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Entities())
                {
                    var person = new Person()
                    {
                        
                        Name = model.Name,
                        NickName = model.NickName,
                        Password = model.Password,
                        DrivingHabits = model.DrivingHabits,
                        DriverExperience = model.DriverExperience,
                        Role = model.Role
                    };
                    context.Person.Add(person);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person user)
        {
            using (Entities db = new Entities())
            {
                try
                {
                    var usr = db.Person.SingleOrDefault(u => u.NickName == user.NickName && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["Id"] = usr.Id;
                        Session["NickName"] = usr.NickName;
                        Session["Role"] = usr.Role;
                        return RedirectToAction("LoggedIn");
                    }
                    if (usr == null)
                    {
                        
                        ModelState.AddModelError("", "NickName or PassWord wrong.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
             
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LoggedOut()
        {
            Session["Id"] = null;
            Session["NickName"] = null;
            Session["Role"] = null;
            return RedirectToAction("../Home/Index");
        }


        [HttpGet]
        public ActionResult EditAccount(int id =0)
        {
            
            if (Session["Id"] != null)
            {
                if (id != null)
                {
                    return View(EditAccountViewModel.Get(id));
                }
                else
                {
                    return View();
                }
                
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }

        [HttpPost]
        public ActionResult EditAccount(EditAccountViewModel model)
        {
           
                using (var context = new Entities())
                {
                int id = (int)Session["Id"];
                var person = context.Person.FirstOrDefault(s => s.Id == id);
                if (person != null)
                    {
                        
                            person.Name = model.Name;
                            person.NickName = model.NickName;
                            person.DrivingHabits = model.DrivingHabits;
                            person.DriverExperience = model.DriverExperience;
                            person.Password = model.NewPassword;

                            context.SaveChanges();
                      

                    }

                    return RedirectToAction("Index");
                }
        }
    

    [HttpGet]
    public ActionResult EditPerson()
    {
        if (Session["Id"] != null)
        {
            if ((string) Session["Role"] == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "AccessDenied");
            }
        }
        else
        {
                return RedirectToAction("Index", "AccessDenied");
        }
    }

    [HttpPost]
    public ActionResult EditPerson(EditPersonViewModel model)
    {
        
            using (var context = new Entities())
            {
                
                var person = context.Person.FirstOrDefault(s => s.Id == model.Id);
                if (person != null)
                {
                    
                        person.Name = model.Name;
                        person.NickName = model.NickName;
                        person.DrivingHabits = model.DrivingHabits;
                        person.DriverExperience = model.DriverExperience;
                        person.Password = model.Password;

                        context.SaveChanges();
                    
                }

                return RedirectToAction("List");
            }
        }


}
}