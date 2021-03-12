﻿using System;
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

                    return RedirectToAction("uspehPrijava");
                }
                else
                {
                    return RedirectToAction("odjava", new { id });
                }
            }
            else
            {
                return RedirectToAction("prijava", new { id });
            }
        }

        public ActionResult Prijava(int id)
        {
            return View();
        }

        public ActionResult Odjava(int id)
        {
            string cookie;
            if (Request.Cookies["UserId"] == null)
            {
                return RedirectToAction("prijava", new { id });
            }
            else
            {
                cookie = Request.Cookies["UserId"].Value;
                if (DatabaseService.GetLogLast(Int32.Parse(cookie), id).Count == 0 || DatabaseService.GetLogLast(Int32.Parse(cookie), id)[0].LogType != "Prijava")
                {
                    return RedirectToAction("dodaj", new { id });
                }
            }

            return View();
        }

        public ActionResult UspehPrijava()
        {
            return View();
        }

        public ActionResult UspehOdjava()
        {
            return View();
        }


    }
}