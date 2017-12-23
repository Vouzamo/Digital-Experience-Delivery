using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Context
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }
        public string CountryCode { get; set; }
        public string UserAgent { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}