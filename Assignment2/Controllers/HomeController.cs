using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Search(string searchTerm)
        {
  
            var sqlh = new SQLHelper();

            var sqlQuery =
                "SELECT\n" +
                "    o.order_id,\n" +
                "    o.order_status,\n" +
                "    o.order_amount,\n" +
                "    c.channel_id,\n" +
                "    c.channel_name,\n" +
                "    c.channel_type,\n" +
                "    s.store_id,\n" +
                "    s.hub_id,\n" +
                "    s.store_name,\n" +
                "    s.store_segment,\n" +
                "    s.store_plan_price,\n" +
                "    s.store_latitude,\n" +
                "    s.store_longitude\n" +
                "FROM\n" +
                "    dbo.orders AS o\n" +
                "JOIN\n" +
                "    dbo.channels AS c\n" +
                "ON\n" +
                "    o.channel_id = c.channel_id\n" +
                "JOIN\n" +
                "    dbo.stores AS s\n" +
                "ON\n" +
                "    o.store_id = s.store_id" +
                "Where" +
                "    o.order_status = "+searchTerm+"";
            ViewBag.DataTable = sqlh.ExecuteQuery(sqlQuery);


            return View();
        }

        public ActionResult Index()
        {

            ViewBag.Title = "Food Deliver Report";

            var sqlh = new SQLHelper();


            var sqlQuery =
                "SELECT\n" +
                "    o.order_id,\n" +
                "    o.order_status,\n" +
                "    o.order_amount,\n" +
                "    c.channel_id,\n" +
                "    c.channel_name,\n" +
                "    c.channel_type,\n" +
                "    s.store_id,\n" +
                "    s.hub_id,\n" +
                "    s.store_name,\n" +
                "    s.store_segment,\n" +
                "    s.store_plan_price,\n" +
                "    s.store_latitude,\n" +
                "    s.store_longitude\n" +
                "FROM\n" +
                "    dbo.orders AS o\n" +
                "JOIN\n" +
                "    dbo.channels AS c\n" +
                "ON\n" +
                "    o.channel_id = c.channel_id\n" +
                "JOIN\n" +
                "    dbo.stores AS s\n" +
                "ON\n" +
                "    o.store_id = s.store_id;";
            ViewBag.DataTable = sqlh.ExecuteQuery(sqlQuery);
            return View();
        }

        //The Details function of get the payment data from database
        public ActionResult Details()
        {
            ViewBag.Title = "Deliver Details";
            var sqlh = new SQLHelper();


            var sqlQuery =
                "SELECT\n" +
                "    o.*,\n" +
                "    dr.*,\n" +
                "    c.*,\n" +
                "    p.*\n" +
                "FROM\n" +
                "    dbo.orders o\n" +
                "JOIN\n" +
                "    dbo.deliveries d ON o.order_id = d.delivery_order_id\n" +
                "JOIN\n" +
                "    dbo.drivers dr ON d.driver_id = dr.driver_id\n" +
                "JOIN\n" +
                "    dbo.channels c ON o.channel_id = c.channel_id\n" +
                "JOIN\n" +
                "    dbo.payments p ON o.order_id = p.payment_order_id;";
            ViewBag.DataTable = sqlh.ExecuteQuery(sqlQuery);

            return View();
        }

        //The OrderHubs function of get the payment data from database
        public ActionResult OrderHubs()
        {
            ViewBag.Title = "Hub Order Report";
            var sqlh = new SQLHelper();


            var sqlQuery =
                "SELECT\n" +
                "    o.*,\n " +
                "    h.*\n" +
                "FROM\n" +
                "    dbo.orders o\n" +
                "JOIN\n" +
                "    dbo.stores s ON s.store_id = o.store_id\n" +
                "JOIN\n" +
                "    dbo.hubs h ON h.hub_id = s.hub_id;";
            ViewBag.DataTable = sqlh.ExecuteQuery(sqlQuery);
            return View();
        }

        //The Payment function of get the payment data from database
        public ActionResult Payment()
        {
            ViewBag.Title = "Payment Analysis";
            var sqlh = new SQLHelper();


            var sqlQuery =
            //"SELECT\n    p.*,\n    o.*,\n    s.*,\n    c.*\nFROM\n    dbo.orders o\nJOIN\n    dbo.stores s ON s.store_id = o.store_id\nJOIN\n    dbo.channels c ON o.channel_id = c.channel_id\nJOIN\n    dbo.payments p ON o.order_id = p.payment_order_id;";

            "SELECT\n" +
            "    p.*,\n" +
            "    o.*,\n" +
            "    s.*,\n" +
            "    c.*\n" +
            "FROM\n" +
            "    dbo.orders o\n" +
            "JOIN\n" +
            "    dbo.stores s ON s.store_id = o.store_id\n" +
            "JOIN\n" +
            "    dbo.channels c ON o.channel_id = c.channel_id\n" +
            "JOIN\n" +
            "    dbo.payments p ON o.order_id = p.payment_order_id;";
            ViewBag.DataTable = sqlh.ExecuteQuery(sqlQuery);
            return View();
        }
    }
}