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

namespace UI.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherProfile.xaml
    /// </summary>
    public partial class TeacherProfile : Window
    {
        public TeacherProfile()
        {
            InitializeComponent();

            Breadcrumbs brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
            Title = "Teacher's name goes here";
            dgBreadcrmbs.ItemsSource = brdcrumb_tracker.GetListOfPagesVisited();

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("TeacherInformation");
            Hide();
        }

        private void Btn_teacherCourseHistory_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("TeacherCourseHistory");
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
