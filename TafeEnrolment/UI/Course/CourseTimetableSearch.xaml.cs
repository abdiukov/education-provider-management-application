using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for CourseTimetableSearch.xaml
    /// </summary>
    public partial class CourseTimetableSearch : Window
    {
        Breadcrumbs brdcrumb_tracker;
        public CourseTimetableSearch()
        {
            InitializeComponent();
            brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("CourseInformation");
            Hide();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //logic
        private void SearchTextbox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextbox.Text == "Enter keywords by which criteria to search")
            {
                SearchTextbox.Text = "";
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //logic to update the datagrid for a specific teacher
            SearchDataGrid(SearchTextbox.Text);
        }

        private void SearchDataGrid(string searchInput)
        {
            if (SearchTextbox.Text == "Enter keywords by which criteria to search" || SearchTextbox.Text == "")
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
            string selected_page = dgBreadcrmbs.SelectedItem.ToString();

            //if the current page is NOT the page the user has clicked on
            if (selected_page != this.GetType().Name)
            {
                PageNavigation.Navigate(selected_page);
                Hide();
            }
            dgBreadcrmbs.CancelEdit();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = brdcrumb_tracker.GetListOfPagesVisited();
            }
        }
    }
}
