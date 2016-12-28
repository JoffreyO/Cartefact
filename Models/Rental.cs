using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartefact.Models
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public int Price { get; set; }
        public int EstimatedKilometers { get; set; }

        [ForeignKey("Car")]
        public int  CarId { get; set; }
        public virtual Car Car { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}