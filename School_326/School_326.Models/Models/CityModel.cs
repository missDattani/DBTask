using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Models.Models
{
    public class CityModel
    {
        [Key]
        public int CiId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int CoId { get; set; }
        [Required]
        public int StId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
    }
}
