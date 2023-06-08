using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Username must have min 5 and max 10 character")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Min 8 character or Max 10 character required")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doesn't matched")]
        public string ConfirmPassword { get; set; }
    }
}