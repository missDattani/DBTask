using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.Models
{
    public class CouponModel
    {
        [Key]
        public int CouponICoded { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public int CouponType { get; set; }
        [Required]
        public int FlatAmount { get; set; }
        [Required]
        public int Percentage { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime ExpiryDate { get; set; }
        [Required]
        public int UsageLimit { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
