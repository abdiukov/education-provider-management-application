using System;

namespace BusinessLayer
{
    public class Location
    {

        //CONSTRUCTOR
        public Location(int id, string name, string address, int locationContactNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            LocationContactNumber = locationContactNumber;
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

        public string Address
        {
            get; set;
        }

        public int LocationContactNumber
        {
            get; set;
        }

        //METHODS

        public void AddLocation()
        {
            throw new NotImplementedException();

        }

        public void DeleteLocation()
        {
            throw new NotImplementedException();

        }

        public void UpdateLocation()
        {
            throw new NotImplementedException();

        }

        public void SearchLocation()
        {
            throw new NotImplementedException();

        }

        public void ViewAllLocations()
        {
            throw new NotImplementedException();

        }

        //public List<Student> Students
        //{
        //    get; set;
        //}
        //public List<Teacher> Teachers
        //{
        //    get; set;
        //}

    }
}
