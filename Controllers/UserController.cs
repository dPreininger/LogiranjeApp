using System;
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
        public User Post([FromBody] UserNoId user)
        {
            Random r = new Random();
            int id;
            while (true)
            {
                id = r.Next(100000, 999999);
                if (DatabaseService.GetUsers(id).Count == 0) break;
            }

            return DatabaseService.PostUser(user, id);
        }

        public User Get(int id)
        {
            List<User> user = DatabaseService.GetUsers(id);

            if(user.Count == 0)
            {
                return null;
            }
            else
            {
                return user[0];
            }
        }
    }
}
