using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Student
{
    public partial class StudentResultSearch : Window
    {
        //INITIALISATION CODE
        public StudentResultSearch()
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

        //NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new StudentProfile());
            Hide();
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
            Hide();
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void dgStudentResults_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        //END OF DATAGRID SETTINGS CODE


    }
}
