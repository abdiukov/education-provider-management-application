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
    /// Interaction logic for SubjectsClustered.xaml
    /// </summary>
    public partial class SubjectsClustered : Window
    {
        Breadcrumbs brdcrumb_tracker;
        public SubjectsClustered()
        {
            InitializeComponent();
             brdcrumb_tracker = new Breadcrumbs(this.GetType().Name);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.Navigate("CourseInformation");
            Hide();
        }


        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            string selected_page = dgBreadcrmbs.SelectedItem.ToString();

            //if the current page is NOT the page the user has clicked on
            if (selected_page[0] != '<')
            {
                PageNavigation.Navigate(selected_page);
                Hide();
            }
            dgBreadcrmbs.CancelEdit();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                List<BreadcrumbsData> data = brdcrumb_tracker.GetListOfPagesVisited();

                foreach (var item in data)
                {
                    if (item.ToString() == this.GetType().Name)
                    {
                        item.Name = "<-- " + item.Name + " -->";
                        dgBreadcrmbs.ItemsSource = data;
                        return;
                    }
                }
            }

        }
    }
}
