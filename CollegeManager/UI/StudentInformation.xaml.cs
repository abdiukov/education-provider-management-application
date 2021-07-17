using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using View.Student;
namespace View
{

    public partial class StudentInformation : Window
    {
        private List<Model.Student> Students = new List<Model.Student>();

        /// Initialises the page.
        /// The datagrid, Students list are filled from Control.cs method GetStudents()
        /// </summary>
        public StudentInformation()
        {
            InitializeComponent();
            Students = (List<Model.Student>)App.logic.GetFromDB("GetStudents");
            DgStudentProfiles.ItemsSource = Students;
            Checkbox_SearchCurrent.IsChecked = true;
            Search();
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
        /// If "Part Time" checkbox gets selected, "Full Time" checkbox gets unselected.
        /// </summary>
        private void Checkbox_SearchPartTime_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchFullTime.IsChecked = false;
        }
        /// <summary>
        /// If "Full Time" checkbox gets selected, "Part Time" checkbox gets unselected.
        /// </summary>
        private void Checkbox_SearchFullTime_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchPartTime.IsChecked = false;
        }


        /// <summary>
        /// After clicking on the field, the default text "Enter ID that you wish to search" is replaced with ""
        /// </summary>
        private void SearchBox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            SearchBox.Text = PageLogic.SearchBoxReplaceDefaultValue(SearchBox.Text);
        }

        /// <summary>
        /// Validate user input, perform the search, update the datagrid
        /// </summary>
        private void Search()
        {
            if (!int.TryParse(SearchBox.Text, out int idToSearch))
            {
                idToSearch = -99999;
            }
            //making copy
            List<Model.Student> StudentsCopy = new List<Model.Student>(Students);

            List<Model.Student> SearchResult = PageLogic.SearchStudent(idToSearch, Checkbox_SearchPartTime.IsChecked,
    Checkbox_SearchFullTime.IsChecked, Checkbox_EnrolledNoFees.IsChecked,
    Checkbox_SearchCurrent.IsChecked, Checkbox_SearchPast.IsChecked, Students);
            DgStudentProfiles.ItemsSource = SearchResult;
            Students = StudentsCopy;
        }

        /// <summary>
        /// If "Enter" key is pressed, perform a search
        /// </summary>
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }
        /// <summary>
        /// If "Search" button is clicked, perform a search
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }


        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// Opens new "Student Results" page that corresponds to the button the user clicked on datagrid 
        /// </summary>
        private void BtnStudentResult_Click(object sender, RoutedEventArgs e)
        {
            int selectedStudentID = Students.ElementAt(DgStudentProfiles.SelectedIndex).Id;
            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch(selectedStudentID), this);
        }

        /// <summary>
        /// Opens new "Student Enrolment" page that corresponds to the button the user clicked on datagrid 
        /// </summary>
        private void BtnStudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            int selectedStudentID = Students.ElementAt(DgStudentProfiles.SelectedIndex).Id;
            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment(selectedStudentID), this);
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        /// <summary>
        /// Upon right clicking on the datagrid, the user is presented with the page where they can hide columns in the datagrid
        /// </summary>
        private void DgStudentProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgStudentProfiles);
            page.Show();
        }

        /// <summary>
        /// If the main window is not visible, and this window is being closed - shut down the application.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }


    }
}
