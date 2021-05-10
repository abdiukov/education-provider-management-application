using System;

namespace BusinessLayer
{
    public class Unit
    {
        public Unit(int id, string name, int numberOfHours, string packageName)
        {
            Id = id;
            Name = name;
            NumberOfHours = numberOfHours;
            PackageName = packageName;
        }

        //PROPERTIES

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int NumberOfHours
        {
            get; set;
        }

        public string PackageName
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
