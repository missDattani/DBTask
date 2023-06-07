using OrderManagement.Helpers.Helpers;
using OrderManagement.Models.Context;
using OrderManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    [LoginAction]
    public class OrderController : Controller
    {
        OrderManagementEntities entities = new OrderManagementEntities();
       
        // GET: Order
        public ActionResult AddOrder()
        {
            try
            {
                OrderModel order = new OrderModel();
                int UserId = 0;
                if (Session["Id"] != null)
                {
                    UserId = Convert.ToInt32(Session["Id"]) + 0;
                }

                order.UserId = UserId;
                order.Items = entities.Items.ToList();
                return View(order);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddOrder(OrderModel order)
        {
            try
            {
                if (order.CouponId != null)
                {
                    int couponCode = entities.CouponCodeMasters.Where(m => m.CouponCode == order.CouponId).FirstOrDefault().CouponICoded;
                    CouponCodeMaster dcrCoupon = entities.CouponCodeMasters.Where(m => m.CouponCode == order.CouponId).FirstOrDefault();
                    dcrCoupon.UsageLimit = dcrCoupon.UsageLimit - 1;
                    Order order1 = OrderHelper.ConvertToOrder(order, couponCode);
                    entities.Orders.Add(order1);
                    entities.SaveChanges();
                    TempData["Success"] = "Order Added Successfully";
                }
                else
                {
                    Order order1 = OrderHelper.ConvertToOrder(order, 0);
                    entities.Orders.Add(order1);
                    entities.SaveChanges();
                    TempData["Success"] = "Order Added Successfully";
                }
                return RedirectToAction("OrderList");
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult OrderList()
        {
            try
            {
                int UserId = 0;
                if (Session["Id"] != null)
                {
                    UserId = Convert.ToInt32(Session["Id"]) + 0;
                }
                List<SP_GetOrderDetails_Result> orderList = entities.SP_GetOrderDetails(UserId).ToList();
                return View(orderList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       
    }
}