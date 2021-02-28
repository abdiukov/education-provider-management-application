using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Teacher;

namespace UI
{
    public partial class TeacherInformation : Window
    {
        //INITIALISATION CODE
        public TeacherInformation()
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
            //below is placeholder code for testing
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            Hide();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            PageLogic.SearchTeacher(SearchBox.Text, checkbox_SearchPartTime.IsChecked,
    checkbox_SearchFullTime.IsChecked, checkbox_SearchTeacherNotBasedLocation.IsChecked);
        }

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




        //NAVIGATION CODE


        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new MainWindow());
            Hide();
        }

        private void Btn_CourseHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE
        private void dgTeacherProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
