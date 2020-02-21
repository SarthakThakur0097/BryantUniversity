using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class SemesterDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public SemesterDetails() { }
        public SemesterDetails(string name, string urlSlug)
        {
            Name = name;
            UrlSlug = urlSlug;
        }
    }
}