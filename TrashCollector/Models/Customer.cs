using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Required]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Please Enter 5 digit numeric ZIP Code")]
        public string ZIP { get; set; }

        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }

        [Display(Name = "Pickup Date")]
        [Column(TypeName = "Date")]
        public DateTime PickupDate { get; set; }

        [Display(Name = "Pickup Date")]
        [Column(TypeName = "Date")]
        public DateTime SuspendStartDate { get; set; }

        [Display(Name = "Pickup Date")]
        [Column(TypeName = "Date")]
        public DateTime SuspendEndDate { get; set; }

        [Display(Name = "Account Balance")]
        public double AccountBalance { get; set; }

        [ForeignKey("User")]
        public string UserGuid { get; set; }
        public ApplicationUser User { get; set; }
    }
}