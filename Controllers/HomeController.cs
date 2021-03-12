using LogiranjeApp.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogiranjeApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string cookie;
            if(Request.Cookies["UserId"] != null)
            {
                cookie = Request.Cookies["UserId"].Value;
                
                // serviraj ok stran
            } 
            else
            {
                //Random r = new Random();
                //int id;
                //while (true)
                //{
                //    id = r.Next(100000, 999999);
                //    if (DatabaseService.GetUsers(id).Count == 0) break;
                //}
                //cookie = id.ToString();
                //HttpCookie hc = new HttpCookie("UserId", cookie);

                // redirect na stran za prijavo
                return RedirectToAction("Prijava");

                //hc.Expires = DateTime.Now.AddDays(365 * 10);
                //Response.Cookies.Add(hc);
            }




            ViewBag.Id = cookie;

            return View();
        }

        public ActionResult Prijava()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}