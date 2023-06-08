using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class StudentModel
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Select any Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please Select any State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select any City")]
        public int CityId { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}