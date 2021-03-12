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
    public class LogController : ApiController
    {
        public List<Log> Get()
        {
            return DatabaseService.GetLogs();
        }

        [Route("api/log/{usersId}/last")]
        public List<Log> Get(int usersId)
        {
            return DatabaseService.GetLogLast(usersId);
        }

        public string Post([FromBody] LogNoId log)
        {
            return DatabaseService.PostLogs(log);
        }
    }
}
