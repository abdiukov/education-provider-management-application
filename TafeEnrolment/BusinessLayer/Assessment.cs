using System;

namespace BusinessLayer
{
    public class Assessment
    {
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

        public Unit AssessmentUnit
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
