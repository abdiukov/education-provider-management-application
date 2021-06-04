using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    public partial class StudentProfile : Window
    {
        //INITIALISATION CODE
        public StudentProfile()
        {
            InitializeComponent();
            Title = "Add new student";
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

        //NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new MainWindow());
            Hide();
        }


        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
            Hide();
        }

        //END OF NAVIGATION CODE
    }
}
