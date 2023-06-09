using Newtonsoft.Json;
using OrderManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class GetDataController : Controller
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        // GET: GetData
        public JsonResult GetItemPrice(int ItemId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            Item item = entities.Items.Find(ItemId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCouponDiscount(string CouponCode)
        {
            entities.Configuration.ProxyCreationEnabled = false;
    
            CouponCodeMaster coupons = entities.CouponCodeMasters.Where(m => m.CouponCode.Equals(CouponCode)).FirstOrDefault();
            if(coupons != null)
            {
                return Json(coupons, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GetOrderList(int Id)
        {
            Order order = entities.Orders.Where(m => m.OrderId == Id).FirstOrDefault();
            var json = JsonConvert.SerializeObject(order);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}