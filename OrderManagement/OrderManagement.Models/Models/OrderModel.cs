using OrderManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CouponId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime OrderDate { get; set; }
        [Required]
        public int OrderTotalQty { get; set; }
        [Required]
        public int OrderItemQty { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public decimal AfterGST { get; set; }
        [Required]
        public decimal TotalPayable { get; set; }

        [Required]
        public int SGST { get; set; }
        [Required]
        public int CGST { get; set; }
        [Required]
        public string ItemId { get; set; }

        public List<Item> Items { get; set; }
    }
}
