using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {
        //
        private readonly List<Model.CourseInformation> allCourses;
        private readonly List<Location> allLocations;
        private readonly List<Delivery> allDelivery;
        private readonly List<Semester> allSemesters;

        //
        private Model.CourseInformation selectedCourse;

        private List<BusinessLayer.Student> initialStudents;
        public static List<BusinessLayer.Student> modifiedStudents;

        private List<Unit> initialUnits;
        public static List<Unit> modifiedUnits;

        private int initialStartSemester;
        private int initialEndSemester;

        private List<BusinessLayer.Teacher> initialTeachers;
        public static List<BusinessLayer.Teacher> modifiedTeachers;

        public EditCourse()
        {
            InitializeComponent();

            //Assigning to lists
            allLocations = (List<Location>)App.logic.GetFromDB("GetLocations");
            allDelivery = (List<Delivery>)App.logic.GetFromDB("GetDelivery");
            allSemesters = (List<Semester>)App.logic.GetFromDB("GetSemesters");
            allCourses = (List<Model.CourseInformation>)App.logic.GetFromDB("GetCoursesForAutofill");

            //UI
            comboBox_Locations.ItemsSource = allLocations;
            comboBox_Delivery.ItemsSource = allDelivery;
            comboBox_SemesterStart.ItemsSource = allSemesters;
            comboBox_SemesterEnd.ItemsSource = allSemesters;
            ComboBoxSelectCourse.ItemsSource = allCourses;

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
        private void DgNavigationBar_NavigateToSelectedPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

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
            EditCourseSelectTeacher pageobj = new EditCourseSelectTeacher();
            pageobj.Show();
        }

        /// <summary>
        /// When user clicks on "Select Units" button, a page is displayed where the user can select whichever units they wish.
        /// </summary>
        private void BtnSelectUnits_Click(object sender, RoutedEventArgs e)
        {
            EditCourseSelectUnit pageobj = new EditCourseSelectUnit();
            pageobj.Show();
        }

        /// <summary>
        /// When user clicks on "Select Students" button, a page is displayed where the user can select whichever student they wish.
        /// </summary>
        private void BtnSelectStudents_Click(object sender, RoutedEventArgs e)
        {
            EditCourseSelectStudent pageobj = new EditCourseSelectStudent();
            pageobj.Show();
        }

        private void ComboBoxSelectCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Model.CourseInformation)ComboBoxSelectCourse.SelectedItem;


            textBox_CourseName.Text = selectedCourse.CourseName;

            foreach (Location item in allLocations)
            {
                if (item.Id == selectedCourse.LocationID)
                {
                    comboBox_Locations.SelectedItem = item;
                    break;
                }
            }

            foreach (Delivery item in allDelivery)
            {
                if (item.Id == selectedCourse.DeliveryID)
                {
                    comboBox_Delivery.SelectedItem = item;
                    break;
                }
            }

            foreach (Delivery item in allDelivery)
            {
                if (item.Id == selectedCourse.DeliveryID)
                {
                    comboBox_Delivery.SelectedItem = item;
                    break;
                }
            }

            foreach (Semester item in allSemesters)
            {
                if (item.Id == selectedCourse.StartSemesterID)
                {
                    comboBox_SemesterStart.SelectedItem = item;
                    break;
                }
            }

            foreach (Semester item in allSemesters)
            {
                if (item.Id == selectedCourse.EndSemesterID)
                {
                    comboBox_SemesterEnd.SelectedItem = item;
                    break;
                }
            }

            initialStartSemester = selectedCourse.StartSemesterID;
            initialEndSemester = selectedCourse.EndSemesterID;

            initialUnits = App.logic.GetUnitsThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            initialTeachers = App.logic.GetTeachersThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            initialStudents = App.logic.GetStudentsThatBelongAndDontBelongCourse(selectedCourse.CourseID);

            modifiedUnits = App.logic.GetUnitsThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            modifiedTeachers = App.logic.GetTeachersThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            modifiedStudents = App.logic.GetStudentsThatBelongAndDontBelongCourse(selectedCourse.CourseID);
        }

        private void BtnEditCourse_Click(object sender, RoutedEventArgs e)
        {
            VerifyInput();

            List<int> studentsToInsert = new List<int>();
            List<int> studentsToDelete = new List<int>();

            for (int i = 0; i < modifiedStudents.Count; i++)
            {
                if (initialStudents[i].IsSelected != modifiedStudents[i].IsSelected)
                {
                    //if student was selected initially but is now not selected
                    if (initialStudents[i].IsSelected == true)
                    {
                        studentsToDelete.Add(initialStudents[i].Id);
                    }
                    //if student was not selected initially but is now selected
                    else
                    {
                        studentsToInsert.Add(initialStudents[i].Id);
                    }
                }
            }

            List<int> teachersToInsert = new List<int>();
            List<int> teachersToDelete = new List<int>();

            for (int i = 0; i < modifiedTeachers.Count; i++)
            {
                if (initialTeachers[i].IsSelected != modifiedTeachers[i].IsSelected)
                {
                    //if teacher was selected initially but is now not selected
                    if (initialTeachers[i].IsSelected == true)
                    {
                        teachersToDelete.Add(initialTeachers[i].Id);
                    }
                    //if teacher was not selected initially but is now selected
                    else
                    {
                        teachersToInsert.Add(initialTeachers[i].Id);
                    }
                }
            }

            List<int> unitsToInsert = new List<int>();
            List<int> unitsToDelete = new List<int>();

            for (int i = 0; i < modifiedUnits.Count; i++)
            {
                if (initialUnits[i].IsSelected != modifiedUnits[i].IsSelected)
                {
                    //if unit was selected initially but is now not selected
                    if (initialUnits[i].IsSelected == true)
                    {
                        unitsToDelete.Add(initialUnits[i].UnitID);
                    }
                    //if unit was not selected initially but is now selected
                    else
                    {
                        unitsToInsert.Add(initialUnits[i].UnitID);
                    }
                }
            }

            Semester startSemester = (Semester)comboBox_SemesterStart.SelectedItem;
            Semester endSemester = (Semester)comboBox_SemesterEnd.SelectedItem;

            int modifiedStartSemester = startSemester.Id;
            int modifiedEndSemester = endSemester.Id;

            List<int> initialSemesters = new List<int>();
            List<int> modifiedSemesters = new List<int>();

            for (int i = initialStartSemester; i <= initialEndSemester; i++)
            {
                initialSemesters.Add(i);
            }
            for (int i = modifiedStartSemester; i <= modifiedEndSemester; i++)
            {
                modifiedSemesters.Add(i);
            }

            List<int> semestersToInsert = new List<int>();
            List<int> semestersToDelete = new List<int>();

            foreach (int item in initialSemesters)
            {
                if (modifiedSemesters.Contains(item))
                {
                    modifiedSemesters.Remove(item);
                }
                else
                {
                    semestersToDelete.Add(item);
                }
            }

            foreach (int item in modifiedSemesters)
            {
                semestersToInsert.Add(item);
            }

            double courseCost = -1;

            if (studentsToInsert.Count > 0)
            {
                if (!double.TryParse(textBox_CourseCost.Text, out double coursecost))
                {
                    MessageBox.Show("Please enter a number into \"Course Cost\" field");
                    return;
                }

                if (coursecost < 0)
                {
                    MessageBox.Show("The course cost cannot be a negative number");
                    return;
                }
                courseCost = coursecost;
            }

            Delivery selectedDelivery = (Delivery)comboBox_Delivery.SelectedItem;
            Location selectedLocation = (Location)comboBox_Locations.SelectedItem;
            string courseName = textBox_CourseName.Text;
            int locationID = selectedLocation.Id;
            int deliveryID = selectedDelivery.Id;


            MessageBox.Show(
                SendData(selectedCourse.CourseID,
                courseName,
                locationID, deliveryID)
                );

            string output =
                SendDataBridgingTables(studentsToInsert, studentsToDelete, teachersToInsert,
                teachersToDelete, unitsToInsert, unitsToDelete,
                semestersToInsert, semestersToDelete, selectedCourse.CourseID, courseCost);

            if (!string.IsNullOrEmpty(output))
            {
                MessageBox.Show(output);
            }

            PageNavigation.GoToExistingPage(0, this);
        }

        private bool VerifyInput()
        {
            if (string.IsNullOrWhiteSpace(textBox_CourseName.Text))
            {
                MessageBox.Show("Please enter something into \"Course name\" field");
                return false;
            }

            if (comboBox_Locations.SelectedItem is null)
            {
                MessageBox.Show("Please select the location");
                return false;
            }
            if (comboBox_Delivery.SelectedItem is null)
            {
                MessageBox.Show("Please select the delivery of the course");
                return false;
            }

            Semester startSemester = (Semester)comboBox_SemesterStart.SelectedItem;

            if (startSemester is null)
            {
                MessageBox.Show("Please select the start semester");
                return false;
            }

            Semester endSemester = (Semester)comboBox_SemesterEnd.SelectedItem;

            if (endSemester is null)
            {
                MessageBox.Show("Please select the end semester");
                return false;
            }

            if (endSemester.StartDate < startSemester.StartDate)
            {
                MessageBox.Show("The start semester is bigger than end semester. Please select appropriate semesters");
                return false;
            }

            return true;
        }

        private string SendDataBridgingTables(List<int> studentsToInsert, List<int> studentsToDelete,
            List<int> teachersToInsert, List<int> teachersToDelete, List<int> unitsToInsert,
            List<int> unitsToDelete, List<int> semestersToInsert, List<int> semestersToDelete, int courseID, double courseCost)
        {
            //PERFORMING DB OPERATIONS
            string outcome = "";

            foreach (int item in teachersToInsert)
            {
                outcome += App.logic.ManageDB("InsertCourseTeacher", new object[] { courseID, item });
            }
            foreach (int item in teachersToDelete)
            {
                outcome += App.logic.ManageDB("DeleteCourseTeacher", new object[] { courseID, item });
            }

            foreach (int item in unitsToInsert)
            {
                outcome += App.logic.ManageDB("InsertCluster", new object[] { courseID, item });
            }
            foreach (int item in unitsToDelete)
            {
                outcome += App.logic.ManageDB("DeleteCluster", new object[] { courseID, item });
            }

            foreach (int item in semestersToInsert)
            {
                outcome += App.logic.ManageDB("InsertCourseSemester", new object[] { courseID, item });
            }
            foreach (int item in semestersToDelete)
            {
                outcome += App.logic.ManageDB("DeleteCourseSemester", new object[] { courseID, item });
            }

            foreach (int item in studentsToInsert)
            {
                outcome += App.logic.ManageDB("InsertCourseStudentPayment", new object[] { courseID, item, courseCost });
            }
            foreach (int item in studentsToDelete)
            {
                outcome += App.logic.ManageDB("DeleteCourseStudentPayment", new object[] { courseID, item });
            }
            return outcome;
        }

        private string SendData(int courseID, string courseName, int locationID, int deliveryID)
        {
            string outcome = App.logic.ManageDB("EditCourse", new object[] { courseID, courseName, locationID, deliveryID });
            return outcome;
        }

        private void BtnDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            string output = App.logic.ManageDB("DeleteCourse",
                new object[] { selectedCourse.CourseID });
            MessageBox.Show(output);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }

    }
}
