using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Min 8 character or Max 10 character required")]
        public string PassWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Password doesn't matched")]
        public string ConfirmPassWord { get; set; }

    }
}