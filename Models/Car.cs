using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartefact.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Brand { get; set; }
        public String Ref { get; set; }
        public String Description { get; set; }
        public int BuyingYear { get; set; }
        public int Kilometers { get; set; }
        public int Status { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual Person Person { get; set; }

    }
}