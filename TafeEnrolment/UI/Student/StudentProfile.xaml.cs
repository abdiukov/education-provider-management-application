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

namespace UI.Student
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : Window
    {
        public StudentProfile()
        {
            InitializeComponent();
            Title = "Student's name goes here";
            Breadcrumbs brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
            dgBreadcrmbs.ItemsSource = brdcrumb_tracker.GetListOfPagesVisited();



            //            bool student_paid_fees = true;

            //            textbox_placeholder3.Text = student_paid_fees ? 
            //              "The student has paid fees" : "The student has not paid fees";

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentInformation pageobj = new StudentInformation();
            pageobj.Show();
            Close();
        }

        private void Btn_StudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            StudentEnrolment pageobj = new StudentEnrolment();
            pageobj.Show();
            Close();
        }

        private void Btn_StudentResult_Click(object sender, RoutedEventArgs e)
        {
            StudentResultSearch pageobj = new StudentResultSearch();
            pageobj.Show();
            Close();
        }

    }
}
