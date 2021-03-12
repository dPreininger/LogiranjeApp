using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiranjeApp.Models
{
    //TODO: odstrani LogTime
    public class LogNoId
    {
        public int IdLocations { get; set; }
        public int IdUsers { get; set; }
        public DateTime LogTime { get; set; }
        public string LogType { get; set; }
    }
}