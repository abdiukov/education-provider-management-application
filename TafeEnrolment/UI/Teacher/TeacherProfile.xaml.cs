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

            Title = "Placeholder text";
            textbox_name.Text = "Placeholder text";
            textbox_placeholder.Text = "Teacher's position : " + "Full Time";
            textbox_placeholder2.Text = "Teacher's name : " + "Placeholder text";
            textbox_placeholder3.Text = "Placeholder text4";
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
