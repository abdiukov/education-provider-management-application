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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //Navigation
        private void NavigateTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            TeacherInformation pageobj = new TeacherInformation();
            pageobj.Show();
            Close();
        }

        private void NavigateCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            CourseInformation pageobj = new CourseInformation();
            pageobj.Show();
            Close();
        }

        private void NavigateStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            StudentInformation pageobj = new StudentInformation();
            pageobj.Show();
            Close();
        }
    }
}
