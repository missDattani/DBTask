using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.ViewModels.User
{
    public class OTPModel
    {
        [Required]
        //[StringLength(6,ErrorMessage ="OTP Must Have Max 6 length")]
        [Range(0, 6 , ErrorMessage = "OTP Must Have Max 6 length")]
        public int OTP {  get; set; }
    }
}
