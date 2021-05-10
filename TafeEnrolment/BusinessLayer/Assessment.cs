using System;

namespace BusinessLayer
{
    public class Assessment
    {
        //CONSTRUCTOR

        public Assessment(int Id, string Name, DateTime StartDate, DateTime DueDate, AssessmentType assessmentType)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.DueDate = DueDate;
            this.assessmentType = assessmentType;
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

        public DateTime DueDate
        {
            get; set;
        }

        public AssessmentType assessmentType
        {
            get; set;
        }

        public enum AssessmentType
        {
            Skill = 1,
            Knowledge = 2,
            Project = 3,

        }

        //METHODS

        public void AddAssessment()
        {

        }

        public void DeleteAssessment()
        {

        }

        public void UpdateAssessment()
        {

        }

        public void SearchAssessments()
        {

        }

        public void ViewAllAssessments()
        {

        }

    }
}
