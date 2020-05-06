using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class StudentMajor
    {
        public StudentMajor(){ }

        public StudentMajor(int userId, int majorId)
        {
            UserId = userId;
            MajorId = majorId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}