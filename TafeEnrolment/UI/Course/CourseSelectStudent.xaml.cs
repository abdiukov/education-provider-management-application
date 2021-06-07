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
