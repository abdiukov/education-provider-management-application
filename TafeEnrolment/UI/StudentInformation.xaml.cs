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
    /// Interaction logic for StudentInformation.xaml
    /// </summary>
    public partial class StudentInformation : Window
    {
        public StudentInformation()
        {
            InitializeComponent();
        }


        //navigation
        // not done, need to replace Student No Fees with something else
        private void studentNotPaid_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentNoFees pageobj = new StudentNoFees();
            pageobj.Show();
            Close();
        }

        private void studentResultsLocationByLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            //pageobj = new StudentNoFees();
            //pageobj.Show();
            //Close();
        }

        private void studentEnrolmentByLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            //StudentNoFees pageobj = new StudentNoFees();
            //pageobj.Show();
            //Close();
        }

        private void studentPartTimeByLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentPartTimeSearchLocation pageobj = new StudentPartTimeSearchLocation();
            pageobj.Show();
            Close();
        }

        private void studentEnrolment_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentEnrolmentForCousre pageobj = new StudentEnrolmentForCousre();
            pageobj.Show();
            Close();
        }

        private void studentResult_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentSearchResultByCourse pageobj = new StudentSearchResultByCourse();
            pageobj.Show();
            Close();
        }

        private void studentFullTimeTimeByLocation_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentFullTimeSearchLocation pageobj = new StudentFullTimeSearchLocation();
            pageobj.Show();
            Close();
        }

        private void studentFullTimeBySemester_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentsEnrolmentSearch pageobj = new StudentsEnrolmentSearch();
            pageobj.Show();
            Close();
        }

        private void studentPartTimeBySemester_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentPartTimeSearchSemester pageobj = new StudentPartTimeSearchSemester();
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
