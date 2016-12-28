using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class ListRentalViewModel
    {
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        public List<Rental> RentalList { get; set; }
        public int CarId { get; set; }
        public List<Car> CarList { get; set; }  

        public ListRentalViewModel()
        {
            
            using (Entities db = new Entities())
            {
                var rentals = db.Rental.ToList();
                RentalList = rentals;
                CarList = db.Car.ToList();
            }
        }
    }
}