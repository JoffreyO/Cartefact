using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class AddRentalViewModel
    {
            [Required]
            [Display(Name = "Start Date:")]
            public string StartDate { get; set; }

            [Required]
            public string EndDate { get; set; }

            [Required]
            public int Price { get; set; }

            [Required]
            [Display(Name = "Estimated Kilometers :")]
            public int EstimatedKilometers { get; set; }

            [Required]
            [Display(Name = "Car :")]
            public int CarId { get; set; }
            public List<SelectListItem> Car { get; set; }

        public AddRentalViewModel()
            {
                Car = new List<SelectListItem>();
                using (var context = new Entities())
                {
                    var carList = context.Car.ToList();
                    Car.Add(new SelectListItem()
                    {
                        Text = "Select a car",
                        Value = null
                    });

                    foreach (var car in carList)
                    {
                        Car.Add(new SelectListItem()
                        {
                            Text = car.Brand,
                            Value = car.Id.ToString()
                        });
                    }
                }
            }
        }
 }