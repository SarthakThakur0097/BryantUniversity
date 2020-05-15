using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class HoldViewModel
    {
        public HoldViewModel() { }

        public int HoldId { get; set; }
        public IList<Hold> Holds { get; set; }

        public SelectList HoldsList
        {
            get
            {
                return new SelectList(Holds, "Id", "HoldName");
            }
        }

        public void PopulateSelectList(IList<Hold> holds)
        {
            Holds = holds;
        }
    }
}