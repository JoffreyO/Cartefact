using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class ListCarViewModel
    {
        public int CarId { get; set; }
        public String Brand { get; set; }
        public String Ref { get; set; }
        public String Description { get; set; }
        public int BuyingYear { get; set; }
        public int Kilometers { get; set; }
        public int Status { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }


        public static List<ListCarViewModel> GetAll()
        {
            var model = new List<ListCarViewModel>();

            using (var context = new Entities())
            {
                var cars = context.Car.ToList();

                foreach (var car in cars)
                {
                    model.Add(new ListCarViewModel()
                    {
                        CarId = car.Id,
                        Brand = car.Brand,
                        Ref = car.Ref,
                        Description = car.Description,
                        BuyingYear = car.BuyingYear,
                        Kilometers = car.Kilometers,
                        Status = car.Status,
                        Latitude = car.Latitude,
                        Longitude = car.Longitude
                    });
                }
            }

            return model;
        }
    }
}