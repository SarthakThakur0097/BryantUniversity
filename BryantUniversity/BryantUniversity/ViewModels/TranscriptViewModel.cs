﻿using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class TranscriptViewModel
    {
        public TranscriptViewModel()
        {
            AllClasses = new List<Registration>();
        }
        public float TermGpa { get; set; }
        public float CumulativeGpa { get; set; }
        public int PeriodId { get; set; }
        public IList<Registration> AllClasses { get; set; }
        public SemesterPeriod GradeSemesterPeriod { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }

        public SelectList PeriodList
        {
            get
            {
                return new SelectList(SemesterPeriods, "Id", "Period.Value");
            }
        }

        public void PopulateSelectList(IList<SemesterPeriod> populatedPeriods)
        {
            SemesterPeriods = populatedPeriods;

        }
    }
}