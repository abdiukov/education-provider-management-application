using System;

namespace BusinessLayer
{
    /// <summary>
    /// Contains information about college semester, such as when it starts, when it ends, what the name of semester is.
    /// </summary>
    public class Semester
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of semester e.g 10</param>
        /// <param name="Name">Name of semester e.g Semester 2 2021</param>
        /// <param name="StartDate">The date when the semester starts e.g 2021-01-30 (YYYY-MM-DD)</param>
        /// <param name="FinishDate">The date when the semester ends e.g 2021-07-15 (YYYY-MM-DD)</param>
        public Semester(int Id, string Name, DateTime StartDate, DateTime FinishDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
        }

        //PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        //METHODS
        public override string ToString()
        {
            return Name + ". " + StartDate.ToString("dd/MM/yyyy").Replace('-', '/') + " - "
                + FinishDate.ToString("dd/MM/yyyy").Replace('-', '/');
        }


    }
}
