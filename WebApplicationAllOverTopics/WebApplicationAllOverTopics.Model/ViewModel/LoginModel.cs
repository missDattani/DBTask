using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Model.ViewModel
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserModel 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [NotMapped]
        [Compare("Password",ErrorMessage ="Password Doesn't Matched")]
        public string ConfirmPassword { get; set; }

    }

}
