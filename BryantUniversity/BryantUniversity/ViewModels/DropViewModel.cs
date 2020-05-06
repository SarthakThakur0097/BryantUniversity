using BryantUniversity.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class DropViewModel
    {
        public DropViewModel()
        {
            NonGraded = new List<Registration>();
        }

        public IList<Registration> NonGraded { get; set; }
    }
}