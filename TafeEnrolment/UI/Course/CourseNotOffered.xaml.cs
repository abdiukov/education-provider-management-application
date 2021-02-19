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

namespace UI
{
    /// <summary>
    /// Interaction logic for CourseNotOffered.xaml
    /// </summary>
    public partial class CourseNotOffered : Window
    {
        public CourseNotOffered()
        {
            InitializeComponent();
            Breadcrumbs brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
            dgBreadcrmbs.ItemsSource = brdcrumb_tracker.GetListOfPagesVisited();
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            CourseInformation pageobj = new CourseInformation();
            pageobj.Show();
            Close();
        }
    }
}
