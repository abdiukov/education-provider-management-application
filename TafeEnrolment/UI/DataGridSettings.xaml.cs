using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for DataGridSettings.xaml
    /// </summary>
    public partial class DataGridSettings : Window
    {
        private DataGrid dg;
        public DataGridSettings(DataGrid dg)
        {
            InitializeComponent();
            this.dg = dg;
            lbDataGridSettings.ItemsSource = dg.Columns;
        }

        private void lbDataGridSettings_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbDataGridSettings.SelectedIndex != -1)
            {
                switch (dg.Columns[lbDataGridSettings.SelectedIndex].Visibility)
                {
                    case Visibility.Visible:
                        dg.Columns[lbDataGridSettings.SelectedIndex].Visibility = Visibility.Hidden;
                        break;
                    case Visibility.Hidden:
                    case Visibility.Collapsed:
                        dg.Columns[lbDataGridSettings.SelectedIndex].Visibility = Visibility.Visible;
                        break;
                }
            }
        }

    }
}
