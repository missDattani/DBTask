using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10,ErrorMessage ="Min 6 characters required & Max 10 Characters allowed",MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password Doesn't Matched")]
        public string ConfirmPassword { get; set; }

    }
}
