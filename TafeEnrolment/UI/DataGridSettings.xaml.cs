using System;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for DataGridSettings.xaml
    /// </summary>
    public partial class DataGridSettings : Window
    {
        private readonly DataGrid Dg;
        public DataGridSettings(DataGrid Dg)
        {
            InitializeComponent();
            this.Dg = Dg;
            lbDataGridSettings.ItemsSource = Dg.Columns;
        }

        private void lbDataGridSettings_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbDataGridSettings.SelectedIndex != -1)
            {
                switch (Dg.Columns[lbDataGridSettings.SelectedIndex].Visibility)
                {
                    case Visibility.Visible:
                        Dg.Columns[lbDataGridSettings.SelectedIndex].Visibility = Visibility.Hidden;
                        break;
                    case Visibility.Hidden:
                    case Visibility.Collapsed:
                        Dg.Columns[lbDataGridSettings.SelectedIndex].Visibility = Visibility.Visible;
                        break;
                }
            }
        }


        private void Window_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            try
            {
                var window = (Window)sender;
                if (window.IsActive == false && window.Topmost == false)
                {
                    window.Close();
                }
            }
            catch (Exception) { };
        }

    }
}
