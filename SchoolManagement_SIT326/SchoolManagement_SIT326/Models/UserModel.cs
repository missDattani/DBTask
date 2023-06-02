using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement_SIT326.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2,ErrorMessage ="FirstName Must have max 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "LastName Must have max 20 characters")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage ="Password doesn't Matched")]
        public string ConfirmPassWord { get; set; }
        [Required(ErrorMessage ="Please Select Role")]
        public Nullable<int> Role { get; set; }
        public string RoleName { get; set; }
    }
}