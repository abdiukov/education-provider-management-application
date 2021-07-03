using BusinessLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseProfile.xaml
    /// </summary>
    public partial class CourseProfile : Window
    {
        //VARIABLE DECLARATIONS


        public static List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();

        public static List<BusinessLayer.Unit> allUnits = new List<BusinessLayer.Unit>();

        public static List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();




        //INITIALISATION CODE
        public CourseProfile()
        {
            InitializeComponent();

            //UI
            comboBox_Locations.ItemsSource = App.logic.GetFromDB("GetLocations");
            comboBox_Delivery.ItemsSource = App.logic.GetFromDB("GetDelivery");
            IEnumerable<Semester> availableSemesters = (IEnumerable<Semester>)App.logic.GetFromDB("GetSemesters");
            comboBox_SemesterStart.ItemsSource = availableSemesters;
            comboBox_SemesterEnd.ItemsSource = availableSemesters;

            //LOGIC
            allStudents = (List<BusinessLayer.Student>)App.logic.GetFromDB("GetAvailableStudents");
            allUnits = (List<Unit>)App.logic.GetFromDB("GetUnits");
            allTeachers = (List<BusinessLayer.Teacher>)App.logic.GetTeachers(true);

            //RESETTING STATIC PUBLIC VALUES

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE

        //NAVIGATION CODE
        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        //END OF NAVIGATION CODE

        private void BtnSelectTeachers_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectTeacher pageobj = new CourseSelectTeacher();
            pageobj.Show();
        }

        private void BtnSelectUnits_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectUnits pageobj = new CourseSelectUnits();
            pageobj.Show();
        }

        private void BtnSelectStudents_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectStudent pageobj = new CourseSelectStudent();
            pageobj.Show();
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {

            string courseName = textBox_CourseName.Text;

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter something into \"Course name\" field");
                return;
            }

            Location selectedLocation = (Location)comboBox_Locations.SelectedItem;

            if (selectedLocation is null)
            {
                MessageBox.Show("Please select the location");
                return;
            }

            int selectedLocationId = selectedLocation.Id;

            Delivery selectedDelivery = (Delivery)comboBox_Delivery.SelectedItem;

            if (selectedDelivery is null)
            {
                MessageBox.Show("Please select the delivery of the course");
                return;
            }

            int selectedDeliveryId = selectedDelivery.Id;

            Semester startSemester = (Semester)comboBox_SemesterStart.SelectedItem;

            if (startSemester is null)
            {
                MessageBox.Show("Please select the start semester");
                return;
            }

            Semester endSemester = (Semester)comboBox_SemesterEnd.SelectedItem;

            if (endSemester is null)
            {
                MessageBox.Show("Please select the end semester");
                return;
            }

            if (endSemester.StartDate < startSemester.StartDate)
            {
                MessageBox.Show("The start semester is bigger than end semester. Please select appropriate semesters");
                return;
            }

            if (!double.TryParse(textBox_CourseCost.Text, out double courseCost))
            {
                MessageBox.Show("Please enter a number into \"Course Cost\" field");
                return;
            }

            if (courseCost < 0)
            {
                MessageBox.Show("The course cost cannot be a negative number");
                return;
            }


            List<int> selectedStudentIDs = new List<int>();
            List<int> selectedTeacherIDs = new List<int>();
            List<int> selectedUnitIDs = new List<int>();


            foreach (var item in allStudents)
            {
                if (item.IsSelected)
                {
                    selectedStudentIDs.Add(item.Id);
                }
            }

            foreach (var item in allTeachers)
            {
                if (item.IsSelected)
                {
                    selectedTeacherIDs.Add(item.Id);
                }
            }

            foreach (var item in allUnits)
            {
                if (item.IsSelected)
                {
                    selectedUnitIDs.Add(item.UnitID);
                }
            }

            if (selectedStudentIDs.Count < 1)
            {
                MessageBox.Show("Please select at least one student to attend the course.");
                return;
            }

            if (selectedTeacherIDs.Count < 1)
            {
                MessageBox.Show("Please select at least one teacher to teach the course.");
                return;
            }

            if (selectedUnitIDs.Count < 1)
            {
                MessageBox.Show("Please select at least one unit that needs to be taught.");
                return;
            }

            bool success = App.logic.InsertCourse(courseName, selectedLocationId, selectedDeliveryId, startSemester,
                endSemester, courseCost, selectedStudentIDs, selectedTeacherIDs, selectedUnitIDs);

            if (success)
            {
                MessageBox.Show("The course has been successfully inserted");
            }
            else
            {
                MessageBox.Show("Failed to insert the course. Please contact the administrator");
            }


        }



    }
}