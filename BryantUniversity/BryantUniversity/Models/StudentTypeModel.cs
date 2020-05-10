using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class StudentTypeModel
    {
        public StudentTypeModel(){}

        public StudentTypeModel(int userId, int studentTypeId)
        {
            UserId = userId;
            StudentTypeId = studentTypeId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StudentTypeId { get; set; }
        public StudentType StudentType { get; set; }
    }
}