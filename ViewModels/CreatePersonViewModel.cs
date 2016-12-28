using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [Display(Name = "Name :")]
        public string Name { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string DrivingHabits { get; set; }

        [Required]
        public int DriverExperience { get; set; }

        [Required]
        [Display(Name = "Role :")]
        public string Role { get; set; }

        public List<SelectListItem> Roles { get; set; }


        public CreatePersonViewModel()
        {
            Roles = new List<SelectListItem>();
            using (var context = new Entities())
            {
                var rolesList = context.Person.ToList();
                Roles.Add(new SelectListItem()
                {
                    Text = "Sélectionne un role",
                    Value = null
                });

                foreach (var role in rolesList)
                {
                    Roles.Add(new SelectListItem()
                    {
                        Text = role.Role,
                        Value = role.Role
                    });
                }
            }
        }
    }
}