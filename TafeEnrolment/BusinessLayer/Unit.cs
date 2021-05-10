using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Unit
    {

        //PROPERTIES

        public int Code
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public List<Course> CoursesLinkedToUnit
        {
            get; set;
        }

        //METHODS

        public void AddUnit()
        {
            throw new NotImplementedException();

        }

        public void DeleteUnit()
        {
            throw new NotImplementedException();

        }

        public void UpdateUnit()
        {
            throw new NotImplementedException();

        }

        public void SearchUnit()
        {
            throw new NotImplementedException();

        }

        public void ViewAllUnits()
        {
            throw new NotImplementedException();

        }

        public void AssignCourse()
        {
            throw new NotImplementedException();

            //unit may belong to more than one course

            //course may have more than one unit and a unit may belong to more than one course
        }
    }
}
