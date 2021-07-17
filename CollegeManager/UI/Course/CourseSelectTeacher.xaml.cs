using System;
using System.Windows;

namespace View.Course
{
    /// <summary>
    /// Page allows user to select teacher(s) from the list of teachers
    /// </summary>
    public partial class CourseSelectTeacher : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the listbox to be retrieved from a static property (list of all teachers) in CourseProfile
        /// </summary>
        public CourseSelectTeacher()
        {
            InitializeComponent();
            lbSelectTeacher.ItemsSource = CourseProfile.allTeachers;
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
        /// Upon clicking the left mouse on the teacher, its "IsSelected" property gets changed in static allTeachers located in CourseProfile.
        /// The listbox gets updated
        /// </summary>
        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbSelectTeacher.SelectedIndex != -1)
            {
                Model.Teacher selectedItem = (Model.Teacher)lbSelectTeacher.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectTeacher.ItemsSource = null;
                lbSelectTeacher.ItemsSource = CourseProfile.allTeachers;
            }
        }
    }
}
