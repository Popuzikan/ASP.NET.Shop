using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        [StringLength(25)]
        [Required(ErrorMessage = "The length of the name is no more than 25 characters")]
        public string Name { get; set; }

        [Display(Name = "Enter your last name")]
        [StringLength(25)]
        public string SurName { get; set; }

        [Display(Name = "Enter your adress")]
        [StringLength(25)]
        public string Adress { get; set; }

        [Display(Name = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Phone { get; set; }

        [Display(Name = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        public string Email { get; set; }

        public DateTime AddTime { get; set; }
    }
}
