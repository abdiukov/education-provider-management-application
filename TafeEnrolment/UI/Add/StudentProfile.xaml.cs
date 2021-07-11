using BusinessLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    /// <summary>
    /// Page allows user to add a new student into the database
    /// </summary>
    public partial class StudentProfile : Window
    {

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(genders, courses) are filled from Control.cs
        /// methods GetGenders(), GetCourses() respectively.
        /// </summary>
        public StudentProfile()
        {
            InitializeComponent();
            comboBox_GenderSelection.ItemsSource = App.logic.GetFromDB("GetGenders");
            comboBox_Course.ItemsSource = App.logic.GetFromDB("GetCourses");

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
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0, this);
        }


        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        /// <summary>
        /// Verifies user input and then sends it to the database
        /// </summary>
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;
            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;


            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter something into 'Address' field ");
                return;
            }

            Gender selectedGender = (Gender)comboBox_GenderSelection.SelectedItem;

            if (selectedGender is null)
            {
                MessageBox.Show("Please enter a gender");
                return;
            }
            int genderID = selectedGender.GenderID;

            if (string.IsNullOrWhiteSpace(mobile))
            {
                MessageBox.Show("Please enter something into 'Phone number' field ");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter something into 'Email' field ");
                return;
            }

            if (datePicker_DateOfBirth.SelectedDate is null)
            {
                MessageBox.Show("Select a valid date of birth");
                return;
            }

            string dob = datePicker_DateOfBirth.SelectedDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter something into 'First name' field ");
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter something into 'Last name' field ");
                return;
            }

            dynamic selectedCourse = comboBox_Course.SelectedItem;

            if (selectedCourse is null)
            {
                MessageBox.Show("Please select a course which the student will be enrolled into");
                return;
            }
            int courseID = selectedCourse.CourseID;


            if (!double.TryParse(textBox_CourseCost.Text, out double CourseCost))
            {
                MessageBox.Show("Please enter a number into 'Course cost' field ");
                return;
            }

            string outcome = App.logic.ManageDB("InsertNewStudent", new object[]{address, genderID, mobile, email, dob,
                firstName, lastName, courseID, CourseCost });

            MessageBox.Show(outcome);
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
