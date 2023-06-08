using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CountryId { get; set; }
      
        public string CountryName { get; set; }
    
        public string StateName { get; set; }
    }
}