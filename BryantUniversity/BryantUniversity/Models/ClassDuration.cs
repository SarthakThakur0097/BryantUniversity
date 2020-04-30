using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class ClassDuration
    {
        public ClassDuration() { }

        public ClassDuration(ClassTime time)
        {
            TimeForClass = time;
        }
        public int Id { get; set; }
        public ClassTime TimeForClass { get; set; }
    }
}