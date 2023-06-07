using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Models.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2,ErrorMessage ="CountryName have max 20 characters")]
        public string CountryName { get; set; }
    }
}
