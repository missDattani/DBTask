using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Models.Models
{
    public class TeacherModel
    {
        [Key]
        public int TecId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "FirstName have max 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "LastName have max 20 characters")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string SubjectId { get; set; }
        [Required]
        public Nullable<int> CountryId { get; set; }
        [Required]
        public Nullable<int> StateId { get; set; }
        [Required]
        public Nullable<int> CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
