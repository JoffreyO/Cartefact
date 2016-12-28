using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class EditPersonViewModel
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name :")]
        public string Name { get; set; }

        [Required]
        public string NickName { get; set; }
        [Required]
        public string DrivingHabits { get; set; }
        [Required]
        public int DriverExperience { get; set; }

        [Required]
        public string Password { get; set; }

        public string NewPassword { get; set; }

        public static EditPersonViewModel Get(int id)
        {
            var model = new EditPersonViewModel();

            using (var context = new Entities())
            {
                var user = context.Person.FirstOrDefault(s => s.Id == id);

                if (user != null)
                {
                    model.Name = user.Name;
                    model.NickName = user.NickName;
                    model.DrivingHabits = user.DrivingHabits;
                    model.DriverExperience = user.DriverExperience;
                    model.NewPassword = user.Password;
                }
            }
            return model;
        }
    }
}