using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class TeacherInformation : Window
    {
        Logic logic = new Logic();
        List<BusinessLayer.Teacher> Teachers = new List<BusinessLayer.Teacher>();

        //INITIALISATION CODE
        public TeacherInformation()
        {
            InitializeComponent();
            Teachers = (List<BusinessLayer.Teacher>)logic.GetTeachers(false);
            dgTeacherProfiles.ItemsSource = Teachers;
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
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
            if (!int.TryParse(SearchBox.Text, out int idToSearch))
            {
                idToSearch = -99999;
            }
            List<BusinessLayer.Teacher> TeachersCopy = new List<BusinessLayer.Teacher>(Teachers);

            List<BusinessLayer.Teacher> SearchResult = PageLogic.SearchTeacher(idToSearch, checkbox_SearchPartTime.IsChecked,
    checkbox_SearchFullTime.IsChecked, checkbox_SearchTeacherNotBasedLocation.IsChecked, Teachers);


            //making copy
            dgTeacherProfiles.ItemsSource = SearchResult;
            Teachers = TeachersCopy;
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


        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new MainWindow());
            Hide();
        }

        private void Btn_CourseHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedTeacherID = Teachers.ElementAt(dgTeacherProfiles.SelectedIndex).Id;
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory(selectedTeacherID));
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE
        private void dgTeacherProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(dgTeacherProfiles);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
