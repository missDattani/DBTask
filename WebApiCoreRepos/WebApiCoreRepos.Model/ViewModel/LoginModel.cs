using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoreRepos.Model.ViewModel
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string PASSWORD { get; set; }
    }

    public class UserModel 
    {
        [Key]
        public int USERID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
   
        [DataType(DataType.Password)]
        [Compare("PASSWORD", ErrorMessage ="Password doesn't matched")]
        [NotMapped] 
        public string CONFIRMPASSWORD { get; set; }

        public static implicit operator UserModel(string v)
        {
            throw new NotImplementedException();
        }
    }

}
