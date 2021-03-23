using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogiranjeApp.Controllers
{
    [HandleError]
    public class NapakaController : Controller
    {
        // GET: Napaka
        public ActionResult NiNajdeno()
        {
            Response.StatusCode = 404;
            return View();
        }
        
        public ActionResult Streznik()
        {
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult Prosnja()
        {
            Response.StatusCode = 400;
            return View();
        }

        public ActionResult Napaka()
        {
            return View();
        }
    }
}