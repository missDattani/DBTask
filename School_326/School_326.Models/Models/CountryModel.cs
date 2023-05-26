using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Models.Models
{
    public class CountryModel
    {
        [Key]
        public int CoId { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
