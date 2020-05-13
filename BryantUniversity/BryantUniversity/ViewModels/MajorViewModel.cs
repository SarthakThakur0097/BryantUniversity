using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class MajorViewModel
    {
        public IList<Major> Majors { get; set; }
    }
}