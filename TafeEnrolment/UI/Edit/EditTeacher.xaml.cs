using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Page that allows the user to select one of existing teachers and then either append its details in the database or delete the teachers details
    /// </summary>
    public partial class EditTeacher : Window
    {
        private readonly List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();
        private readonly List<Gender> allGenders = new List<Gender>();
        private readonly List<Location> allLocations = new List<Location>();

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(teachers, genders, locations) are filled from Control.cs
        /// methods GetTeachers(), GetGenders(), GetLocations() respectively.
        /// allTeachers, allGenders, allLocations are filled from Control.cs methods GetTeachers(), GetGenders(), GetLocations() methods respectively.
        /// </summary>
        public EditTeacher()
        {
            InitializeComponent();
            allTeachers = App.logic.SortTeacherList((List<BusinessLayer.Teacher>)App.logic.GetFromDB("GetTeachers"));
            allGenders = (List<BusinessLayer.Gender>)App.logic.GetFromDB("GetGenders");
            allLocations = (List<Location>)App.logic.GetFromDB("GetLocations");
            comboBox_GenderSelection.ItemsSource = allGenders;
            ComboBoxSelectTeacher.ItemsSource = allTeachers;
            comboBox_Locations.ItemsSource = allLocations;
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
        public void GoBack()
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
        /// When user selects one of students in the combobox, all the textboxes get filled.
        /// The gender combobox, location combobox get filled as well.
        /// </summary>
        private void ComboBoxSelectTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)ComboBoxSelectTeacher.SelectedItem;

            textBox_Address.Text = selectedTeacher.Address;
            textBox_PhoneNumber.Text = selectedTeacher.Mobile;
            textBox_Email.Text = selectedTeacher.Email;
            textBox_FirstName.Text = selectedTeacher.FirstName;
            textBox_LastName.Text = selectedTeacher.LastName;

            int selecteDgenderIndex = -1;

            foreach (Gender item in allGenders)
            {
                selecteDgenderIndex++;
                if (item.GenderDescription == selectedTeacher.PersonGender)
                {
                    break;
                }
            }

            int selectedLocationIndex = -1;

            foreach (Location item in allLocations)
            {
                selectedLocationIndex++;
                if (item.Id == selectedTeacher.BaseLocation)
                {
                    break;
                }
            }


            comboBox_GenderSelection.SelectedIndex = selecteDgenderIndex;
            datePicker_DateOfBirth.SelectedDate = selectedTeacher.DateofBirth;
            comboBox_Locations.SelectedIndex = selectedLocationIndex;
        }

        /// <summary>
        /// When user clicks on the button, user input gets verified
        /// and then information gets send to EditTeacher() method in Control.cs.
        /// This results in teacher details being altered in the database.
        /// </summary>
        private void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;
            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)ComboBoxSelectTeacher.SelectedItem;
            int teacherID = selectedTeacher.Id;

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter something into 'Address' field ");
                return;
            }

            Gender selecteDgender = (Gender)comboBox_GenderSelection.SelectedItem;

            if (selecteDgender is null)
            {
                MessageBox.Show("Please enter a gender");
                return;
            }
            int genderID = selecteDgender.GenderID;

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

            Location selectedLocation = (Location)comboBox_Locations.SelectedItem;
            if (selectedLocation is null)
            {
                MessageBox.Show("Please select the base location");
                return;
            }


            string outcome = App.logic.ManageDB("EditTeacher",
                new object[] { teacherID, address, genderID, mobile, email, dob, firstName, lastName, selectedLocation.Id });
            MessageBox.Show(outcome);

            GoBack();
        }

        /// <summary>
        /// When user clicks button, information gets send to DeleteTeacher() method in Control.cs.
        /// This results in teacher details being deleted in the database.
        /// </summary>
        private void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)ComboBoxSelectTeacher.SelectedItem;

            string outcome = App.logic.ManageDB("DeleteTeacher", new object[] { selectedTeacher.Id });
            MessageBox.Show(outcome);
            GoBack();
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
