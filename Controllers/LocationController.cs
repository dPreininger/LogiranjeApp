using LogiranjeApp.Control;
using LogiranjeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogiranjeApp.Controllers
{
    public class LocationController : ApiController
    {
        public List<Location> Get()
        {
            return DatabaseService.GetLocations();
        }

        public List<Location> Get(int id)
        {
            return DatabaseService.GetLocations(id);
        }
    }
}
