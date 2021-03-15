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
            return View();
        }

        public ActionResult Odhod()
        {
            string cookieUserId;
            string cookieLocationId;
            if (Request.Cookies["UserId"] == null)
            {
                return RedirectToAction("prijava");
            }
            if(Request.Cookies["LocationId"] == null)
            {
                // pohandlaj napako
                return RedirectToAction("index", "home");
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
            if (tip == null) return RedirectToAction("index", "home");
            
            ViewBag.Tip = tip;

            // mogoce ni najboljse
            User user = DatabaseService.GetUsers(Int32.Parse(Request.Cookies["UserId"].Value))[0];
            ViewBag.Ime = user.Name;
            ViewBag.Priimek = user.LastName;
            ViewBag.Id = user.IdUsers;

            return View();
        }
    }
}