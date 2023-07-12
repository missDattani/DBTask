using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Model.ViewModels
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get;set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public int Role { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CityId { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }

        public RoleType RoleName {  get; set; }
    }
}
