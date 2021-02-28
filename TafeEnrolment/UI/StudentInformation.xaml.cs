using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Student;

namespace UI
{

    public partial class StudentInformation : Window
    {
        //INITIALISATION CODE
        public StudentInformation()
        {
            InitializeComponent();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = App.pagesVisitedTracker;
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
            PageLogic.SearchStudent(SearchBox.Text, checkbox_SearchPartTime.IsChecked,
    checkbox_SearchFullTime.IsChecked, checkbox_EnrolledNoFees.IsChecked);
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

            //below is placeholder code for testing
            Hide();
            PageNavigation.GoToNewOrExistingPage(new StudentProfile());
        }

        //END OF SEARCH DATAGRID CODE


        //PAGE NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }


        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new StudentProfile());
        }


        private void BtnStudentResult_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch());
        }


        private void BtnStudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment());
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }

        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE
        private void dgStudentProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }



        //END OF DATAGRID SETTINGS CODE

    }
}
