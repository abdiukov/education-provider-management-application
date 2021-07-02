using System;
using System.Windows;

namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseSelectStudent.xaml
    /// </summary>
    public partial class CourseSelectStudent : Window
    {
        public CourseSelectStudent()
        {
            InitializeComponent();
            lbSelectStudent.ItemsSource = CourseProfile.allStudents;
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
            if (lbSelectStudent.SelectedIndex != -1)
            {
                BusinessLayer.Student selectedItem = (BusinessLayer.Student)lbSelectStudent.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectStudent.ItemsSource = null;
                lbSelectStudent.ItemsSource = CourseProfile.allStudents;
            }
        }
    }
}
