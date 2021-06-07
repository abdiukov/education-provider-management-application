using System;

namespace BusinessLayer
{
    public class Semester
    {
        //CONSTRUCTOR
        public Semester(int id, string name, DateTime startDate, DateTime finishDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            FinishDate = finishDate;
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

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime FinishDate
        {
            get; set;
        }


        //METHODS
        public override string ToString()
        {
            return Name + ". " + StartDate.ToString("dd/MM/yyyy").Replace('-', '/') + " - " + FinishDate.ToString("dd/MM/yyyy").Replace('-', '/');
        }


    }
}
