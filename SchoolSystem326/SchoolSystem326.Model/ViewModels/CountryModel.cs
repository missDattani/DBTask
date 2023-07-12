using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Model.ViewModels
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
