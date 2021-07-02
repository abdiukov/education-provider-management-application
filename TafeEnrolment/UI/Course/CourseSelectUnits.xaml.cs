using System;
using System.Windows;

namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseSelectUnits.xaml
    /// </summary>
    public partial class CourseSelectUnits : Window
    {
        public CourseSelectUnits()
        {
            InitializeComponent();
            lbSelectUnits.ItemsSource = CourseProfile.allUnits;

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

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbSelectUnits.SelectedIndex != -1)
            {
                BusinessLayer.Unit selectedItem = (BusinessLayer.Unit)lbSelectUnits.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectUnits.ItemsSource = null;
                lbSelectUnits.ItemsSource = CourseProfile.allUnits;
            }
        }


    }
}
