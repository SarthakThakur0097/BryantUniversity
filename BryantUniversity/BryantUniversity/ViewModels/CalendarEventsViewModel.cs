using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class CalendarEventsViewModel
    {
        public int PeriodId { get; set; }
        public IList<CalendarEvent> Events { get; set; }
    }
}