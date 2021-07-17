using System;
using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Page where they can hide/unhide columns in the datagrid
    /// </summary>
    public partial class DataGridSettings : Window
    {
        private readonly DataGrid dg;

        /// <param name="dg">Datagrid which is being modified</param>
        public DataGridSettings(DataGrid dg)
        {
            InitializeComponent();
            this.dg = dg;
            lbDataGridSettings.ItemsSource = dg.Columns;
        }

        /// <summary>
        /// Upon mouse clicking on one of columns in datagrid, its visibility gets changed
        /// </summary>
        private void LbDataGridSettings_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        /// <summary>
        /// If window is not visible to the user, it gets closed
        /// </summary>
        private void Window_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            try
            {
                Window window = (Window)sender;
                if (window.IsActive == false && window.Topmost == false)
                {
                    window.Close();
                }
            }
            catch (Exception) { };
        }
    }
}
