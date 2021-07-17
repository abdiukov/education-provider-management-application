using System;
using System.Windows;

namespace UI.Edit
{
    /// <summary>
    /// Page that allows user to select which units are going to be edited
    /// </summary>
    public partial class EditCourseSelectUnit : Window
    {
        public EditCourseSelectUnit()
        {
            InitializeComponent();
            lbSelectUnit.ItemsSource = EditCourse.modifiedUnits;
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
            if (lbSelectUnit.SelectedIndex != -1)
            {
                BusinessLayer.Unit selectedItem = (BusinessLayer.Unit)lbSelectUnit.SelectedItem;
                selectedItem.IsSelected = !selectedItem.IsSelected;
                lbSelectUnit.ItemsSource = null;
                lbSelectUnit.ItemsSource = EditCourse.modifiedUnits;
            }
        }
    }
}
