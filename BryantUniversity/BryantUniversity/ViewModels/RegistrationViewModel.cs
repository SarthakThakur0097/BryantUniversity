﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class RegistrationViewModel
    {
        public bool SameClassConflict { get; set; }
        public bool TimeConflict { get; set; }
    }
}