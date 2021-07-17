using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace View.Edit
{
    /// <summary>
    /// Page that allows user to select student and then edit their payment in another window
    /// </summary>
    public partial class EditStudentPayment : Window
    {
        private readonly List<Model.Student> allStudents = new List<Model.Student>();

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(students, genders) are filled from Control.cs
        /// methods GetStudents(), GetGenders() respectively.
        /// allStudents, allGenders are filled from Control.cs methods GetStudents(), GetGenders() methods respectively.
        /// </summary>
        public EditStudentPayment()
        {
            InitializeComponent();
            allStudents = App.logic.SortStudentList((List<Model.Student>)App.logic.GetFromDB("GetStudents"));
            ComboBoxSelectStudent.ItemsSource = allStudents;
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
            FillInDataGrid();
        }

        private void FillInDataGrid()
        {
            Model.Student selectedStudent = (Model.Student)ComboBoxSelectStudent.SelectedItem;
            DgStudentEnrolment.ItemsSource = App.logic.GetFromDB("GetEnrolmentsByID", new object[] { selectedStudent.Id });
        }

        /// <summary>
        /// Upon right clicking on the datagrid, the user is presented with the page where they can hide columns in the datagrid
        /// </summary>
        private void DgStudentEnrolment_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgStudentEnrolment);
            page.Show();
        }

        /// <summary>
        /// Passes student payment information/ student details into new page "SelectNewPaymentStatus" where they can be edited.
        /// </summary>
        private void BtnEditPayment_Click(object sender, RoutedEventArgs e)
        {
            if (DgStudentEnrolment.SelectedItem is null)
            {
                return;
            }
            Model.Enrolment selectedPaymentToChange = (Model.Enrolment)DgStudentEnrolment.SelectedItem;
            SelectNewPaymentStatus page = new SelectNewPaymentStatus(selectedPaymentToChange.AmountPaid, selectedPaymentToChange.AmountDue,
                selectedPaymentToChange.CourseStudentID);
            page.ShowDialog();
            FillInDataGrid();

        }

        /// <summary>
        /// If the main window is not visible, and this window is being closed - shut down the application.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
