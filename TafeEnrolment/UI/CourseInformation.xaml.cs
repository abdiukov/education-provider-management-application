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
    /// Interaction logic for CourseInformation.xaml
    /// </summary>
    public partial class CourseInformation : Window
    {
        public CourseInformation()
        {
            InitializeComponent();
            Breadcrumbs brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
            dgBreadcrmbs.ItemsSource = brdcrumb_tracker.GetListOfPagesVisited();
        }

        private void courseTimetables_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("CourseTimetableSearch");
            Hide();
        }


        //navigation
        private void clusterUnitCourse_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("SubjectsClustered");
            Hide();
        }

        private void courseNotOffered_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("CourseNotOffered");
            Hide();
        }

        private void subjectsNotAllocated_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("SubjectsWithNoCourse");
            Hide();
        }

        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("MainWindow");
            Hide();
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
    }
}
