using BusinessLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.Course;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {
        public static List<Model.CourseInformation> allCourses = new List<Model.CourseInformation>();
        public static List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();
        public static List<BusinessLayer.Unit> allUnits = new List<BusinessLayer.Unit>();
        public static List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(location, students, delivery, semester start/semester end) are filled from Control.cs
        /// methods GetLocations(), GetAvailableStudents(), GetDelivery(), GetSemesters() respectively.
        /// allStudents, allUnits, allTeachers are filled from Control.cs methods GetAvailableStudents(), GetUnits(), GetTeachers() methods respectively.
        /// </summary>
        public EditCourse()
        {
            InitializeComponent();

            //UI
            comboBox_Locations.ItemsSource = App.logic.GetFromDB("GetLocations");
            comboBox_Delivery.ItemsSource = App.logic.GetFromDB("GetDelivery");
            IEnumerable<Semester> availableSemesters = (IEnumerable<Semester>)App.logic.GetFromDB("GetSemesters");
            comboBox_SemesterStart.ItemsSource = availableSemesters;
            comboBox_SemesterEnd.ItemsSource = availableSemesters;


            //LOGIC
            allCourses = (List<Model.CourseInformation>)App.logic.GetFromDB("GetCoursesForAutofill");
            allStudents = (List<BusinessLayer.Student>)App.logic.GetFromDB("GetAvailableStudents");
            allUnits = (List<Unit>)App.logic.GetFromDB("GetUnits");
            allTeachers = App.logic.SortTeacherList((List<BusinessLayer.Teacher>)App.logic.GetFromDB("GetTeachers"));
        }

        /// <summary>
        /// Updates the navigation bar at the top, whenever the window visibility changes
        /// </summary>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// When user clicks on "Select Teachers" button, a page is displayed where the user can select whichever teacher they wish.
        /// </summary>
        private void BtnSelectTeachers_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectTeacher pageobj = new CourseSelectTeacher();
            pageobj.Show();
        }

        /// <summary>
        /// When user clicks on "Select Units" button, a page is displayed where the user can select whichever units they wish.
        /// </summary>
        private void BtnSelectUnits_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectUnits pageobj = new CourseSelectUnits();
            pageobj.Show();
        }

        /// <summary>
        /// When user clicks on "Select Students" button, a page is displayed where the user can select whichever student they wish.
        /// </summary>
        private void BtnSelectStudents_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectStudent pageobj = new CourseSelectStudent();
            pageobj.Show();
        }

        /// <summary>
        /// Verifies user input and then sends it to the database
        /// </summary>
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
                MessageBox.Show("Something went wrong - failed to insert the course. Please contact the administrator");
            }


        }


    }
}
