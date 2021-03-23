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
            return View();
        }
        
        public ActionResult Streznik()
        {
            return View();
        }
    }
}