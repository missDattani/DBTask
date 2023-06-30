using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Models.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public string DOBFormat { get; set; }
        [Required]
        public Nullable<int> Role { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Does'nt matched")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }

    }
}
