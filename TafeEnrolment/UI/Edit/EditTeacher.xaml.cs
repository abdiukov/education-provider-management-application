using ModelLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditTeacher.xaml
    /// </summary>
    public partial class EditTeacher : Window
    {

        Logic logic = new Logic();
        public static List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();

        public EditTeacher()
        {
            InitializeComponent();
            allTeachers = (List<BusinessLayer.Teacher>)logic.GetTeachers(true);

        }


        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

    }
}
