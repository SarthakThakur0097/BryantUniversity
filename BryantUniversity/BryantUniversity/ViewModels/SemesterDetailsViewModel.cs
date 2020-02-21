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

        public List<SemesterDetails> semesterDetails = new List<SemesterDetails>()
        {
            new SemesterDetails()
            {
                Name = "Spring 2020",
                UrlSlug = "/spring2020/"
            },

            new SemesterDetails()
            {
                Name = "Fall 2019",
                UrlSlug = "/fall2019/"
            },

            new SemesterDetails()
            {
                Name = "Spring 2019",
                UrlSlug = "/spring2019/"
            }

        };

        public SemesterDetailsViewModel()
        { 
        }
    }
}