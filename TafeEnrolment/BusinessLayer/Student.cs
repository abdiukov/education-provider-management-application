﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Student
    {
        public bool paidFees
        {
            get;set;
        }
        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Position
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }

        public Timetable Student_Timetable
        {
            get;set;
        }
    }
}