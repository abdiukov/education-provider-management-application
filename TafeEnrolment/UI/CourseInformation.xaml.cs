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
        }

        private void courseTimetables_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            CourseTimetableSearch pageobj = new CourseTimetableSearch();
            pageobj.Show();
            Close();
        }


        //navigation
        private void clusterUnitCourse_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            SubjectsClustered pageobj = new SubjectsClustered();
            pageobj.Show();
            Close();
        }

        private void courseNotOffered_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            CourseNotOffered pageobj = new CourseNotOffered();
            pageobj.Show();
            Close();
        }

        private void subjectsNotAllocated_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            SubjectsWithNoCourse pageobj = new SubjectsWithNoCourse();
            pageobj.Show();
            Close();
        }

        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pageobj = new MainWindow();
            pageobj.Show();
            Close();
        }
    }
}
