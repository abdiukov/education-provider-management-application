using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class TeacherInformation : Window
    {

        List<BusinessLayer.Teacher> Teachers = new List<BusinessLayer.Teacher>();

        //INITIALISATION CODE
        public TeacherInformation()
        {
            InitializeComponent();
            Teachers = (List<BusinessLayer.Teacher>)App.logic.GetFromDB("GetTeachers");
            DgTeacherProfiles.ItemsSource = Teachers;
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

            List<BusinessLayer.Teacher> SearchResult = PageLogic.SearchTeacher(idToSearch, Checkbox_SearchPartTime.IsChecked,
    Checkbox_SearchFullTime.IsChecked, Checkbox_SearchTeacherNotBasedLocation.IsChecked, Teachers);


            //making copy
            DgTeacherProfiles.ItemsSource = SearchResult;
            Teachers = TeachersCopy;
        }

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




        //NAVIGATION CODE


        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new MainWindow());
            Hide();
        }

        private void Btn_CourseHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            int selectedTeacherID = Teachers.ElementAt(DgTeacherProfiles.SelectedIndex).Id;
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory(selectedTeacherID));
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE
        private void DgTeacherProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgTeacherProfiles);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
