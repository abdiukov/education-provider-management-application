using BusinessLayer;
using ModelLayer;
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
using UI.Teacher;

namespace UI
{
    /// <summary>
    /// Interaction logic for TeacherCourseHistory.xaml
    /// </summary>
    public partial class TeacherCourseHistory : Window
    {
        private readonly Logic logic;
        Breadcrumbs brdcrumb_tracker;
        public TeacherCourseHistory()
        {
            InitializeComponent();
            dgCourseHistory.Visibility = Visibility.Hidden;

            Logic logic = new Logic();
            this.logic = logic;
            brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("TeacherProfile");
            Hide();
        }

        private void SearchTextbox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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

        private void SearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchDataGrid(SearchTextbox.Text);
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
