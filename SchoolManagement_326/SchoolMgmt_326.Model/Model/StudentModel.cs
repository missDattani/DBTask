
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class StudentModel
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Mobile { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
    
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Select your gender")]
        public string Gender { get; set; }
        public Genders genderE { get;set; }
        [Required(ErrorMessage = "Please Select any one")]
        public string TeacherId { get; set; }
        [Required(ErrorMessage = "Please Select any one")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please Select any one")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select any one")]
        public int CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
     

}
