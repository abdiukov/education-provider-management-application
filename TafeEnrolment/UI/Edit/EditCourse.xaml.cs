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
        private List<Model.CourseInformation> allCourses;
        private List<Location> allLocations;
        private List<Delivery> allDelivery;
        private List<Semester> allSemesters;

        //
        private Model.CourseInformation selectedCourse;
        private List<BusinessLayer.Student> initialStudents;
        public static List<BusinessLayer.Student> modifiedStudents;

        private List<Unit> initialUnits;
        public static List<BusinessLayer.Unit> modifiedUnits;

        private int initialStartSemster;
        private int initialEndSemester;
        private int modifiedStartSemester;
        private int modifiedEndSemester;


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

            int initialStartSemster = selectedCourse.StartSemesterID;
            int initialEndSemester = selectedCourse.EndSemesterID;

            initialUnits = App.logic.GetUnitsThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            initialTeachers = App.logic.GetTeachersThatBelongAndDontBelongCourse(selectedCourse.CourseID);
            initialStudents = App.logic.GetStudentsThatBelongAndDontBelongCourse(selectedCourse.CourseID);

            modifiedUnits = new List<Unit>(initialUnits);
            modifiedTeachers = new List<BusinessLayer.Teacher>(initialTeachers);
            modifiedStudents = new List<BusinessLayer.Student>(initialStudents);

        }

        private void BtnEditCourse_Click(object sender, RoutedEventArgs e)
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

            double courseCost = 0;
            if (courseCost < 0)
            {
                MessageBox.Show("The course cost cannot be a negative number");
                return;
            }


            //List<int> selectedStudentIDs = new List<int>();
            //List<int> selectedTeacherIDs = new List<int>();
            //List<int> selectedUnitIDs = new List<int>();


            //foreach (var item in allStudents)
            //{
            //    if (item.IsSelected)
            //    {
            //        selectedStudentIDs.Add(item.Id);
            //    }
            //}

            //foreach (var item in allTeachers)
            //{
            //    if (item.IsSelected)
            //    {
            //        selectedTeacherIDs.Add(item.Id);
            //    }
            //}

            //foreach (var item in allUnits)
            //{
            //    if (item.IsSelected)
            //    {
            //        selectedUnitIDs.Add(item.UnitID);
            //    }
            //}

            //if (selectedStudentIDs.Count < 1)
            //{
            //    MessageBox.Show("Please select at least one student to attend the course.");
            //    return;
            //}

            //if (selectedTeacherIDs.Count < 1)
            //{
            //    MessageBox.Show("Please select at least one teacher to teach the course.");
            //    return;
            //}

            //if (selectedUnitIDs.Count < 1)
            //{
            //    MessageBox.Show("Please select at least one unit that needs to be taught.");
            //    return;
            //}

            //bool success = App.logic.InsertCourse(courseName, selectedLocationId, selectedDeliveryId, startSemester,
            //    endSemester, courseCost, selectedStudentIDs, selectedTeacherIDs, selectedUnitIDs);

            //if (success)
            //{
            //    MessageBox.Show("The course has been successfully inserted");
            //}
            //else
            //{
            //    MessageBox.Show("Something went wrong - failed to insert the course. Please contact the administrator");
            //}

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
