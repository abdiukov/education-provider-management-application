using System;
using System.Collections.Generic;
using System.Windows;

namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseSelectUnits.xaml
    /// </summary>
    public partial class CourseSelectUnits : Window
    {
        public CourseSelectUnits(List<BusinessLayer.Unit> allUnits)
        {
            InitializeComponent();

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
                //BusinessLayer.Student selectedItem = (BusinessLayer.Student)lbSelectStudent.SelectedItem;
                //selectedItem.isSelected = !selectedItem.isSelected;
                //lbSelectUnits.ItemsSource = null;
                //lbSelectUnits.ItemsSource = CourseProfile.allStudents;
            }
        }


    }
}
