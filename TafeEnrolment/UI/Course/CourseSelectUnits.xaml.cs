using System;
using System.Windows;

namespace UI.Course
{
    /// <summary>
    /// Page allows user to select unit(s) from the list of units
    /// </summary>
    public partial class CourseSelectUnits : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the listbox to be retrieved from a static property (list of all units) in CourseProfile
        /// </summary>
        public CourseSelectUnits()
        {
            InitializeComponent();
            lbSelectUnits.ItemsSource = CourseProfile.allUnits;

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
