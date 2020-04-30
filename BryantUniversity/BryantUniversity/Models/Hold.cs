using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Hold
    {
        public Hold() { }

        public Hold(string holdName)
        {
            HoldName = holdName;
        }

        public int Id { get; set; }
        public string HoldName { get; set; }

        public List<StudentHold> StudentHolds { get; set; }
    }
}