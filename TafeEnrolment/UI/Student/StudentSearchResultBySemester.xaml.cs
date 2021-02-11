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
    /// Interaction logic for StudentSearchResultBySemester.xaml
    /// </summary>
    public partial class StudentSearchResultBySemester : Window
    {
        public StudentSearchResultBySemester()
        {
            InitializeComponent();
        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentInformation pageobj = new StudentInformation();
            pageobj.Show();
            Close();
        }
    }
}
