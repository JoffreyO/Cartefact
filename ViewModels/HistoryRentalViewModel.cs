using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cartefact.Models;

namespace Cartefact.ViewModels
{
    public class HistoryRentalViewModel
    {
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        public List<Rental> RentalList { get; set; }
        public int PersonId { get; set; }

        public HistoryRentalViewModel()
        {

            using (Entities db = new Entities())
            {
                int session = (int)@HttpContext.Current.Session["Id"];
                var rentals = db.Rental.Where(s => s.PersonId == session).ToList();
                RentalList = rentals;
            }
        }
    }
}