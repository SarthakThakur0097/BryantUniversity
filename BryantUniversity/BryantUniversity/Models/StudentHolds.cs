using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class StudentHold
    {
        public StudentHold() { }

        public StudentHold(int userId, int holdId)
        {
            UserId = userId;
            HoldId = holdId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int HoldId { get; set; }
        public Hold Hold { get; set; }
    }
}