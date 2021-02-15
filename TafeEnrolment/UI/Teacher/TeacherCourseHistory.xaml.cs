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
        public TeacherCourseHistory()
        {
            InitializeComponent();
            dgCourseHistory.Visibility = Visibility.Hidden;

            //Logic logic = new Logic();
        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherProfile pageobj = new TeacherProfile();
            pageobj.Show();
            Close();
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
                MessageBox.Show("Searches everything");
            }
            else if (checkbox_SearchPresentCourse.IsChecked == true)
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

            dgCourseHistory.Visibility = Visibility.Hidden;
        }

        private void SearchTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextbox.Text != "Enter keywords by which criteria to search")
            {
                dgCourseHistory.Visibility = Visibility.Hidden;
            }
        }
    }
}
