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
        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            TeacherProfile pageobj = new TeacherProfile();
            pageobj.Show();
            Close();
        }
    }
}
