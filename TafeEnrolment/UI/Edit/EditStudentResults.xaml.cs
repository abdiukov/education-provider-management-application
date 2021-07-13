using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditStudentResults.xaml
    /// </summary>
    public partial class EditStudentResults : Window
    {
        private readonly List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();
        private readonly List<Model.Outcome> allOutcomes = new List<Model.Outcome>();

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(students, genders) are filled from Control.cs
        /// methods GetStudents(), GetGenders() respectively.
        /// allStudents, allGenders are filled from Control.cs methods GetStudents(), GetGenders() methods respectively.
        /// </summary>
        public EditStudentResults()
        {
            InitializeComponent();
            allStudents = App.logic.SortStudentList((List<BusinessLayer.Student>)App.logic.GetFromDB("GetStudents"));
            ComboBoxSelectStudent.ItemsSource = allStudents;
            allOutcomes = (List<Model.Outcome>)App.logic.GetFromDB("GetOutcomes");
        }

        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        /// <summary>
        /// Redirects the user to the main menu
        /// </summary>
        private void GoBack()
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        /// <summary>
        /// Updates the navigation bar at the top, whenever the window visibility changes
        /// </summary>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        /// <summary>
        /// When user selects one of students in the combobox, all the textboxes get filled and the gender combobox gets filled as well.
        /// </summary>
        private void ComboBoxSelectStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)ComboBoxSelectStudent.SelectedItem;
            DgStudentResults.ItemsSource = App.logic.GetFromDB("GetStudentResults", new object[] { selectedStudent.Id });

        }

        private void DgStudentResults_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgStudentResults);
            page.Show();
        }

        private void BtnEditOutcome_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.StudentResult selectedStudentResult = (BusinessLayer.StudentResult)DgStudentResults.SelectedItem;
            SelectNewOutcome page = new SelectNewOutcome(selectedStudentResult.CourseStudentID, allOutcomes);
            page.Show();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
