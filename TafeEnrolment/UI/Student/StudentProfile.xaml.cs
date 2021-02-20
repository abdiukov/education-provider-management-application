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


        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("StudentInformation");
            Hide();
        }

        private void Btn_StudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("StudentEnrolment");
            Hide();
        }

        private void Btn_StudentResult_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("StudentResultSearch");
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
