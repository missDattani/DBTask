using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}