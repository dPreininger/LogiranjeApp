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
                }
                else
                {
                    return RedirectToAction("odjava", new { id });
                }
            }
            else
            {
                return RedirectToAction("prijava");
            }




            ViewBag.Id = cookie;

            return View();
        }

        public ActionResult Prijava()
        {
            return View();
        }

        public ActionResult Odjava(int id)
        {
            if (Request.Cookies["UserId"] == null)
            {
                return RedirectToAction("prijava");
            }

            return View();
        }

        public ActionResult Uspeh()
        {
            return View();
        }
    }
}