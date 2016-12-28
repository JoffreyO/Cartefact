using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cartefact.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Firstname Required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "NickName Required")]
        public String NickName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String DrivingHabits { get; set; }
        public int DriverExperience { get; set; }
        public string Role { get; set;  }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; } 

    }
}