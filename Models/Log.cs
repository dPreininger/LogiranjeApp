﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiranjeApp.Models
{
    public class Log
    {
        public int IdLogs { get; set; }
        public int IdLocations { get; set; }
        public int IdUsers { get; set; }
        public DateTime LogTime { get; set; }
        public string LogType { get; set; }
    }
}