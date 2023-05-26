using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class CityModel
    {
        [Key]
        public int CiId { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="City name must have max 20 characters")]
        public string CityName { get; set; }
        [Required]
        public int CoId { get; set; }
        [Required]
        public int StId { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
    }
}
