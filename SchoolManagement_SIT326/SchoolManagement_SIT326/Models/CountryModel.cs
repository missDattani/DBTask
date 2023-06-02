using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement_SIT326.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2,ErrorMessage ="CountryName must have max 20 characters")]
        public string CountryName { get; set; }
    }
}