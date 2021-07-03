using BusinessLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditTeacher.xaml
    /// </summary>
    public partial class EditTeacher : Window
    {


        private List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();
        private List<Gender> allGenders = new List<Gender>();
        private List<Location> allLocations = new List<Location>();
        public EditTeacher()
        {
            InitializeComponent();
            allTeachers = (List<BusinessLayer.Teacher>)App.logic.GetTeachers(true);
            allGenders = (List<BusinessLayer.Gender>)App.logic.GetFromDB("GetGenders");
            allLocations = (List<Location>)App.logic.GetFromDB("GetLocations");
            comboBox_GenderSelection.ItemsSource = allGenders;
            cbSelectTeacher.ItemsSource = allTeachers;
            comboBox_Locations.ItemsSource = allLocations;
        }


        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        public void GoBack()
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        private void cbSelectTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)cbSelectTeacher.SelectedItem;

            textBox_Address.Text = selectedTeacher.Address;
            textBox_PhoneNumber.Text = selectedTeacher.Mobile;
            textBox_Email.Text = selectedTeacher.Email;
            textBox_FirstName.Text = selectedTeacher.FirstName;
            textBox_LastName.Text = selectedTeacher.LastName;

            int selectedGenderIndex = -1;

            foreach (Gender item in allGenders)
            {
                selectedGenderIndex++;
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


            comboBox_GenderSelection.SelectedIndex = selectedGenderIndex;
            datePicker_DateOfBirth.SelectedDate = selectedTeacher.DateofBirth;
            comboBox_Locations.SelectedIndex = selectedLocationIndex;
        }

        private void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;
            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string dob = datePicker_DateOfBirth.SelectedDate.Value.ToString("yyyy-MM-dd");
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)cbSelectTeacher.SelectedItem;
            int teacherID = selectedTeacher.Id;

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

            if (string.IsNullOrWhiteSpace(dob))
            {
                MessageBox.Show("Select a valid date of birth");
                return;
            }

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


            string outcome = App.logic.EditTeacher(teacherID, address, genderID,
                mobile, email, dob, firstName, lastName, selectedLocation.Id);
            MessageBox.Show(outcome);

            GoBack();
        }

        private void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.Teacher selectedTeacher = (BusinessLayer.Teacher)cbSelectTeacher.SelectedItem;

            string outcome = App.logic.DeleteTeacher(selectedTeacher.Id);
            MessageBox.Show(outcome);
            GoBack();
        }
    }
}
