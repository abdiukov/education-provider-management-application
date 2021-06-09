using ModelLayer;
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
        Logic logic = new Logic();
        List<BusinessLayer.Student> Students = new List<BusinessLayer.Student>();

        //INITIALISATION CODE
        public StudentInformation()
        {
            InitializeComponent();
            this.Students = (List<BusinessLayer.Student>)logic.GetStudents(false);
            dgStudentProfiles.ItemsSource = Students;
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

        //SEARCH DATAGRID CODE

        private void checkbox_SearchPartTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchFullTime.IsChecked = false;
        }

        private void checkbox_SearchFullTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPartTime.IsChecked = false;
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

            List<BusinessLayer.Student> SearchResult = PageLogic.SearchStudent(idToSearch, checkbox_SearchPartTime.IsChecked,
    checkbox_SearchFullTime.IsChecked, checkbox_EnrolledNoFees.IsChecked, Students);
            dgStudentProfiles.ItemsSource = SearchResult;
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


        //PAGE NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }


        private void BtnStudentResult_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedStudentID = Students.ElementAt(dgStudentProfiles.SelectedIndex).Id;
            //string studentName = Students.ElementAt(dgStudentProfiles.SelectedIndex).FirstName + " " + Students.ElementAt(dgStudentProfiles.SelectedIndex).LastName;

            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch(selectedStudentID));
        }


        private void BtnStudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedStudentID = Students.ElementAt(dgStudentProfiles.SelectedIndex).Id;
            //string studentName = Students.ElementAt(dgStudentProfiles.SelectedIndex).FirstName + " " + Students.ElementAt(dgStudentProfiles.SelectedIndex).LastName;

            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment(selectedStudentID));
        }

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE
        private void dgStudentProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgStudentProfiles);
            page.Show();
        }



        //END OF DATAGRID SETTINGS CODE

    }
}
