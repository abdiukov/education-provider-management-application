using System;
using System.Windows;

namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseSelectTeacher.xaml
    /// </summary>
    public partial class CourseSelectTeacher : Window
    {
        public CourseSelectTeacher()
        {
            InitializeComponent();
            lbSelectTeacher.ItemsSource = CourseProfile.allTeachers;
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
            if (lbSelectTeacher.SelectedIndex != -1)
            {
                BusinessLayer.Teacher selectedItem = (BusinessLayer.Teacher)lbSelectTeacher.SelectedItem;
                selectedItem.isSelected = !selectedItem.isSelected;
                lbSelectTeacher.ItemsSource = null;
                lbSelectTeacher.ItemsSource = CourseProfile.allTeachers;
            }
        }
    }
}
