using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Student;
namespace UI
{

    public partial class StudentInformation : Window
    {

        List<BusinessLayer.Student> Students = new List<BusinessLayer.Student>();

        //INITIALISATION CODE
        public StudentInformation()
        {
            InitializeComponent();
            this.Students = (List<BusinessLayer.Student>)App.logic.GetFromDB("GetStudents");
            DgStudentProfiles.ItemsSource = Students;
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
        //END OF INITIALISATION CODE

        //SEARCH DATAGRID CODE

        private void Checkbox_SearchPartTime_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchFullTime.IsChecked = false;
        }

        private void Checkbox_SearchFullTime_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchPartTime.IsChecked = false;
        }

        private void SearchBox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            SearchBox.Text = PageLogic.SearchBoxReplaceDefaultValue(SearchBox.Text);
        }

        private void Search()
        {
            if (!int.TryParse(SearchBox.Text, out int idToSearch))
            {
                idToSearch = -99999;
            }
            //making copy
            List<BusinessLayer.Student> StudentsCopy = new List<BusinessLayer.Student>(Students);

            List<BusinessLayer.Student> SearchResult = PageLogic.SearchStudent(idToSearch, Checkbox_SearchPartTime.IsChecked,
    Checkbox_SearchFullTime.IsChecked, Checkbox_EnrolledNoFees.IsChecked, Students);
            DgStudentProfiles.ItemsSource = SearchResult;
            Students = StudentsCopy;
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        //END OF SEARCH DATAGRID CODE


        //PAGE NAVIGATION CODE        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0, this);
        }


        private void BtnStudentResult_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedStudentID = Students.ElementAt(DgStudentProfiles.SelectedIndex).Id;
            //string studentName = Students.ElementAt(DgStudentProfiles.SelectedIndex).FirstName + " " + Students.ElementAt(DgStudentProfiles.SelectedIndex).LastName;

            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch(selectedStudentID));
        }


        private void BtnStudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedStudentID = Students.ElementAt(DgStudentProfiles.SelectedIndex).Id;
            //string studentName = Students.ElementAt(DgStudentProfiles.SelectedIndex).FirstName + " " + Students.ElementAt(DgStudentProfiles.SelectedIndex).LastName;

            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment(selectedStudentID));
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        /// <summary>
        /// Upon right clicking on the datagrid, the user is presented with the page where they can hide columns in the datagrid
        /// </summary>
        private void DgStudentProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgStudentProfiles);
            page.Show();
        }



        //END OF DATAGRID SETTINGS CODE

    }
}
