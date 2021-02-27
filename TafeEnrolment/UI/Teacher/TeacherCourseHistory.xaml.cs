using ModelLayer;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Teacher;

namespace UI
{
    /// <summary>
    /// Interaction logic for TeacherCourseHistory.xaml
    /// </summary>
    public partial class TeacherCourseHistory : Window
    {
        private readonly Logic logic;

        public TeacherCourseHistory()
        {
            InitializeComponent();

            Logic logic = new Logic();
            this.logic = logic;

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            Hide();
        }

        private void SearchBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "Enter keywords by which criteria to search")
            {
                SearchBox.Text = "";
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //logic to update the datagrid for a specific teacher
            SearchDataGrid(SearchBox.Text);

        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchDataGrid(SearchBox.Text);
            }
        }

        private void checkbox_SearchPastCourse_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPresentCourse.IsChecked = false;
        }

        private void checkbox_SearchPresentCourse_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPastCourse.IsChecked = false;
        }

        //functions

        private void SearchDataGrid(string searchInput)
        {
            if (searchInput == "Enter keywords by which criteria to search" || searchInput == "")
            {
                if (checkbox_SearchPastCourse.IsChecked == true || (checkbox_SearchPastCourse.IsChecked == true))
                {

                    searchInput = "";
                }
                else
                {
                    MessageBox.Show("Search everything");
                    goto Exit_Loop;
                }
            }
            if (checkbox_SearchPresentCourse.IsChecked == true)
            {
                MessageBox.Show("Display results for current courses : " + searchInput);
            }
            else if (checkbox_SearchPastCourse.IsChecked == true)
            {
                MessageBox.Show("Display results for past courses : " + searchInput);
                //dgCourseHistory.ItemsSource = 
            }
            else
            {
                MessageBox.Show("Display results for both past and present courses : " + searchInput);
            }
        Exit_Loop:
            dgCourseHistory.Visibility = Visibility.Visible;
        }



        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            int selected_page = dgBreadcrmbs.SelectedIndex;

            PageNavigation.GoToExistingPage(selected_page);
            Hide();

            dgBreadcrmbs.CancelEdit();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;


            }

        }
    }
}
