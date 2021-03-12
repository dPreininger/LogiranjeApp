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

        [Route("api/log/last")]
        public List<Log> Get([FromUri] int userId, [FromUri] int locationId)
        {
            return DatabaseService.GetLogLast(userId, locationId);
        }

        public string Post([FromBody] LogNoId log)
        {
            return DatabaseService.PostLogs(log);
        }
    }
}
