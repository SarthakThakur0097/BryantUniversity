﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Attendance
    {
        public Attendance(){}

        public Attendance(int registrationId, DateTime dateOfClass, bool isPresent)
        {
            RegistrationId = registrationId;
            DateOfClass = dateOfClass;
            IsPresent = isPresent;
        }

        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
        public DateTime DateOfClass { get; set; }
        public bool IsPresent { get; set; }
    }
}