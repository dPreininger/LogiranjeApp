﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogiranjeApp.Control;
using LogiranjeApp.Models;

namespace LogiranjeApp.Controllers
{
    public class UserController : ApiController
    {
        public string Post([FromBody] User user)
        {
            return DatabaseService.PostUser(user);
        }

        [Route("api/user/generate")]
        public int Post([FromBody] UserNoId user)
        {
            Random r = new Random();
            int id = r.Next(100000, 999999);
            return DatabaseService.PostUser(user, id);
        }
    }
}
