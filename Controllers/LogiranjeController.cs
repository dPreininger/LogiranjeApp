using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogiranjeApp.Control;
using LogiranjeApp.Models;

namespace LogiranjeApp.Controllers
{
    public class LogiranjeController : Controller
    {
        public ActionResult Dodaj(int id)
        {
            //Session["locationId"] = id;

            string cookie;
            if (Request.Cookies["UserId"] != null)
            {
                cookie = Request.Cookies["UserId"].Value;

                // Preverimo, ce se je osebek nazadnje prijavil
                if (DatabaseService.GetLogLast(Int32.Parse(cookie), id).Count == 0 || DatabaseService.GetLogLast(Int32.Parse(cookie), id)[0].LogType != "Prijava")
                {
                    LogNoId obj = new LogNoId();
                    obj.IdUsers = Int32.Parse(cookie);
                    obj.IdLocations = id;
                    obj.LogType = "Prijava";

                    DatabaseService.PostLogs(obj);

                    TempData["tip"] = "Prihod";
                    return RedirectToAction("uspeh");
                }
                else
                {
                    HttpCookie hc = new HttpCookie("LocationId", id.ToString());
                    Response.Cookies.Add(hc);
                    return RedirectToAction("odhod");
                }
            }
            else
            {
                HttpCookie hc = new HttpCookie("LocationId", id.ToString());
                Response.Cookies.Add(hc);
                return RedirectToAction("prijava");
            }
        }

        public ActionResult Prijava()
        {
            //Int32 id = (Int32)Session["locationId"];

            return View();
        }

        public ActionResult Odhod()
        {
            //Int32 id = (Int32)Session["locationId"];

            string cookieUserId;
            string cookieLocationId;
            if (Request.Cookies["UserId"] == null)
            {
                return RedirectToAction("prijava");
            }
            else
            {
                cookieUserId = Request.Cookies["UserId"].Value;
                cookieLocationId = Request.Cookies["LocationId"].Value;
                if (DatabaseService.GetLogLast(Int32.Parse(cookieUserId), Int32.Parse(cookieLocationId)).Count == 0 || DatabaseService.GetLogLast(Int32.Parse(cookieUserId), Int32.Parse(cookieLocationId))[0].LogType != "Prijava")
                {
                    return RedirectToAction("dodaj", new { id = Int32.Parse(cookieLocationId) });
                }
            }

            TempData["tip"] = "Odhod";
            return View();
        }

        public ActionResult Uspeh()
        {
            HttpCookie hc = new HttpCookie("LocationId");
            hc.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(hc);

            string tip = (string)TempData["tip"];
            ViewBag.Tip = tip;

            return View();
        }

        //public ActionResult UspehPrijava()
        //{
        //    return View();
        //}

        //public ActionResult UspehOdjava()
        //{
        //    return View();
        //}


    }
}