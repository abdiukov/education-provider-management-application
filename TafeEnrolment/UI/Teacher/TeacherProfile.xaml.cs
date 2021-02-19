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
            TeacherInformation pageobj = new TeacherInformation();
            pageobj.Show();
            Close();
        }

        private void Btn_teacherCourseHistory_Click(object sender, RoutedEventArgs e)
        {
            TeacherCourseHistory pageobj = new TeacherCourseHistory();
            pageobj.Show();
            Close();
        }
    }
}
