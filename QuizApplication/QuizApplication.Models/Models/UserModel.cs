using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Models
{
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
    }
}
