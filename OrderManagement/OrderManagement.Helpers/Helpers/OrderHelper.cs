using OrderManagement.Models.Context;
using OrderManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Helpers.Helpers
{
    public class OrderHelper
    {
        public static Order ConvertToOrder(OrderModel orderM,int CouponId)
        {
            try
            {
                Order order = new Order();
                order.OrderId = orderM.OrderId;
                order.UserId = orderM.UserId;
                if (CouponId == 0)
                {
                    order.CouponId = null;
                }
                else
                {
                    order.CouponId = CouponId;
                }
                order.OrderDate = orderM.OrderDate;
                order.OrderTotalQty = orderM.OrderTotalQty;
                order.OrderAmount = orderM.OrderAmount;
                order.AfterGST = orderM.AfterGST;
                order.TotalPayable = orderM.TotalPayable;
                order.SGST = orderM.SGST;
                order.CGST = orderM.CGST;
                return order;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
