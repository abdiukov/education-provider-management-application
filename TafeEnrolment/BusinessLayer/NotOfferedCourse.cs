namespace BusinessLayer
{
    public class NotOfferedCourse
    {

        //CONSTRUCTOR
        public NotOfferedCourse(string CourseName, string Semester, string UnitName,
            int UnitHoursAmount, string CampusName, string Delivery)
        {
            this.CourseName = CourseName;
            this.Semester = Semester;
            this.UnitName = UnitName;
            this.UnitHoursAmount = UnitHoursAmount;
            this.CampusName = CampusName;
            this.Delivery = Delivery;
        }

        //PROPERTIES
        public string CourseName
        {
            get; set;
        }

        public string Semester
        {
            get; set;
        }

        public string UnitName
        {
            get; set;
        }

        public int UnitHoursAmount
        {
            get; set;
        }

        public string CampusName
        {
            get; set;
        }

        public string Delivery
        {
            get; set;
        }


    }
}
