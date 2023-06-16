using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Models.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "FirstName have max 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "LastName have max 20 characters")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage ="Password doesn't matched")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Nullable<int> Role { get; set; }
       
        public string RoleName { get; set; }
    }
}
