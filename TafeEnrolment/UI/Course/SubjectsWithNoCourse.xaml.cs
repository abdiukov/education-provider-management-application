using System.Windows;
using System.Windows.Controls;

namespace UI
{
    public partial class SubjectsWithNoCourse : Window
    {

        //INITIALISATION CODE
        public SubjectsWithNoCourse()
        {
            InitializeComponent();
            DgSubjectNoCourse.ItemsSource = App.logic.GetFromDB("GetUnallocatedUnits");
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE

        //NAVIGATION CODE
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new CourseInformation());
        }

        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }


        //END OF NAVIGATION CODE


        //DATAGRID SETTINGS CODE

        private void DgSubjectNoCourse_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgSubjectNoCourse);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
