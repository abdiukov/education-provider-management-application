using System;
using System.Windows;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditCourseSelectTeacher.xaml
    /// </summary>
    public partial class EditCourseSelectTeacher : Window
    {
        public EditCourseSelectTeacher()
        {
            InitializeComponent();
            lbSelectTeacher.ItemsSource = EditCourse.modifiedTeachers;
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
        /// Upon clicking the left mouse on the teacher, its "IsSelected" property gets changed in static allUnits located in CourseProfile.
        /// The listbox gets updated
        /// </summary>
        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbSelectTeacher.SelectedIndex != -1)
            {
                BusinessLayer.Teacher selectedItem = (BusinessLayer.Teacher)lbSelectTeacher.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectTeacher.ItemsSource = null;
                lbSelectTeacher.ItemsSource = EditCourse.modifiedTeachers;
            }
        }

    }
}
