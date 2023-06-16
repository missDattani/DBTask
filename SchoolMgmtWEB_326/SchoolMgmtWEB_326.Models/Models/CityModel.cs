using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Models.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "CityName have max 20 characters")]
        public string CityName { get; set; }
        [Required]
        public Nullable<int> StateId { get; set; }
        [Required]
        public Nullable<int> CountryId { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
