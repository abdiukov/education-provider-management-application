using System;
using System.Windows;

namespace View.Course
{
    /// <summary>
    /// Page allows user to select student(s) from the list of available students
    /// </summary>
    public partial class CourseSelectStudent : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the listbox to be retrieved from a static property (list of all students) in CourseProfile
        /// </summary>
        public CourseSelectStudent()
        {
            InitializeComponent();
            lbSelectStudent.ItemsSource = CourseProfile.allStudents;
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

        /// <summary>
        /// Upon clicking the left mouse on the student, its "IsSelected" property gets changed in static allStudents located in CourseProfile.
        /// The listbox gets updated
        /// </summary>
        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbSelectStudent.SelectedIndex != -1)
            {
                Model.Student selectedItem = (Model.Student)lbSelectStudent.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectStudent.ItemsSource = null;
                lbSelectStudent.ItemsSource = CourseProfile.allStudents;
            }
        }
    }
}
