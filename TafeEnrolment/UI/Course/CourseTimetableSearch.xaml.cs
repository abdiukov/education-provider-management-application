using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for CourseTimetableSearch.xaml
    /// </summary>
    public partial class CourseTimetableSearch : Window
    {

        public CourseTimetableSearch()
        {
            InitializeComponent();

        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseInformation());
            Hide();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //logic
        private void SearchBox_MouseClick(object sender, MouseButtonEventArgs e)
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

        private void SearchDataGrid(string searchInput)
        {
            if (SearchBox.Text == "Enter keywords by which criteria to search" || SearchBox.Text == "")
            {
                MessageBox.Show("Please enter something into the search bar");
            }
            else
            {
                MessageBox.Show(searchInput);
            }
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
