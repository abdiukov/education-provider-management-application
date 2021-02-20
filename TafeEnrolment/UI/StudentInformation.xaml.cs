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
using UI.Student;

namespace UI
{
    /// <summary>
    /// Interaction logic for StudentInformation.xaml
    /// </summary>
    public partial class StudentInformation : Window
    {
        Breadcrumbs brdcrumb_tracker;
        public StudentInformation()
        {
            InitializeComponent();
            brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
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
            //logic to update the datagrid for a specific student
            SearchDataGrid(SearchTextbox.Text);

            //below is placeholder code for testing
            PageNavigation.Navigate("StudentProfile");
            Hide();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //logic to go to student's page
            PageNavigation.Navigate("StudentProfile");
            Hide();
        }


        private void SearchDataGrid(string searchInput)
        {
            searchInput = searchInput == "Enter keywords by which criteria to search" ? "" : searchInput;

            if (checkbox_SearchPartTime.IsChecked == true)
            {
                if (checkbox_EnrolledNoFees.IsChecked == true)
                {
                    MessageBox.Show("Show part time students who have not paid fees " + searchInput);
                }
                else
                {
                    MessageBox.Show("Show part time students " + searchInput);
                }
            }
            else if (checkbox_SearchFullTime.IsChecked == true)
            {
                if (checkbox_EnrolledNoFees.IsChecked == true)
                {
                    MessageBox.Show("Show full time students who have not paid fees " +searchInput );
                }
                else
                {
                    MessageBox.Show("Show full time students " + searchInput);
                }
            }
            else if (checkbox_EnrolledNoFees.IsChecked == true)
            {
                MessageBox.Show("Show all students who have not paid fees " +searchInput);
            }
            else
            {
                MessageBox.Show("Search everyone" + searchInput);
            }
        }

        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("MainWindow");
            Hide();
        }


        //check box logic
        private void checkbox_SearchPartTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchFullTime.IsChecked = false;
        }

        private void checkbox_SearchFullTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPartTime.IsChecked = false;
        }


        private void BtnStudentResult_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("StudentResultSearch");
            Hide();
        }

        private void dgStudentProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        private void BtnStudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("StudentEnrolment");
            Hide();
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            string selected_page = dgBreadcrmbs.SelectedItem.ToString();

            //if the current page is NOT the page the user has clicked on
            if (selected_page[0] != '<')
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
                List<BreadcrumbsData> data = brdcrumb_tracker.GetListOfPagesVisited();

                foreach (var item in data)
                {
                    if(item.ToString() == this.GetType().Name)
                    {
                        item.Name = "<-- " + item.Name + " -->";
                        dgBreadcrmbs.ItemsSource = data;
                        return;
                    }
                }
            }

        }
    }
}
