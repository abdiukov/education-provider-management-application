using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Teacher;

namespace UI
{
    /// <summary>
    /// Interaction logic for TeacherInformation.xaml
    /// </summary>
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
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            PageLogic.SearchTeacher(SearchBox.Text, checkbox_SearchPartTime.IsChecked,
                checkbox_SearchFullTime.IsChecked, checkbox_SearchTeacherNotBasedLocation.IsChecked);

            //below is placeholder code for testing
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            Hide();
        }


        //START OF NAVIGATION CODE


        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
            Hide();
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new MainWindow());
            Hide();
        }

        private void Btn_CourseHistory_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
            Hide();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            Hide();
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
