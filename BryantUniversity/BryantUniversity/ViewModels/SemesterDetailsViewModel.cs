using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class SemesterDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }

        public IList<SemesterDetails> semesterDetails = new List<SemesterDetails>();
        public SemesterDetailsViewModel()
        { 
        }
    }
}