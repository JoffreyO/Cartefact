using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class ListPersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string DrivingHabits { get; set; }
        public int DriverExperience { get; set; }
        public string Password { get; set; }


        public static List<ListPersonViewModel> GetAll()
        {
            var model = new List<ListPersonViewModel>();

            using (var context = new Entities())
            {
                var persons = context.Person.ToList();
                foreach (var person in persons)
                {
                    model.Add(new ListPersonViewModel()
                    {
                        PersonId = person.Id,
                        Name = person.Name,
                        NickName = person.NickName,
                        DrivingHabits = person.DrivingHabits,
                        DriverExperience = person.DriverExperience,
                        Password = person.Password
                    });
                }
            }

            return model;
        }
    }
}