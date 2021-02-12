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
    /// Interaction logic for TeacherInformation.xaml
    /// </summary>
    public partial class TeacherInformation : Window
    {
        public TeacherInformation()
        {
            InitializeComponent();
        }


        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pageobj = new MainWindow();
            pageobj.Show();
            Close();
        }

        private void teacherPartTimeSearchSemester_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherPartTimeSearchSemester pageobj = new TeacherPartTimeSearchSemester();
            pageobj.Show();
            Close();
        }

        private void teacherPartTimeSearchLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherPartTimeSearchLocation pageobj = new TeacherPartTimeSearchLocation();
            pageobj.Show();
            Close();
        }

        private void teacherOtherThanBasedLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherOtherThanBasedLocation pageobj = new TeacherOtherThanBasedLocation();
            pageobj.Show();
            Close();
        }

        private void teacherCourseHistory_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherCourseHistory pageobj = new TeacherCourseHistory();
            pageobj.Show();
            Close();
        }
    }
}
