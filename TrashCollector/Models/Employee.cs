﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Please Enter 5 digit numeric ZIP Code")]
        public string ZIP { get; set; }

        [ForeignKey("User")]
        public string UserGuid { get; set; }
        public ApplicationUser User { get; set; }
    }
}