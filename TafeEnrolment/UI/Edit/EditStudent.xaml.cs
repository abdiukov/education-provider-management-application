using BusinessLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Page that allows the user to select one of existing students and then either append its details in the database or delete the student details
    /// </summary>
    public partial class EditStudent : Window
    {
        private readonly List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();
        private readonly List<BusinessLayer.Gender> allGenders = new List<BusinessLayer.Gender>();

        /// <summary>
        /// Initialises the page.
        /// The comboboxes(students, genders) are filled from Control.cs
        /// methods GetStudents(), GetGenders() respectively.
        /// allStudents, allGenders are filled from Control.cs methods GetStudents(), GetGenders() methods respectively.
        /// </summary>
        public EditStudent()
        {
            InitializeComponent();
            allStudents = App.logic.SortStudentList((List<BusinessLayer.Student>)App.logic.GetFromDB("GetStudents"));
            allGenders = (List<BusinessLayer.Gender>)App.logic.GetFromDB("GetGenders");
            ComboBoxSelectStudent.ItemsSource = allStudents;
            comboBox_GenderSelection.ItemsSource = allGenders;
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
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
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
            textBox_Address.Text = selectedStudent.Address;
            textBox_PhoneNumber.Text = selectedStudent.Mobile;
            textBox_Email.Text = selectedStudent.Email;
            textBox_FirstName.Text = selectedStudent.FirstName;
            textBox_LastName.Text = selectedStudent.LastName;
            int selectedGenderIndex = -1;

            foreach (Gender item in allGenders)
            {
                selectedGenderIndex++;
                if (item.GenderDescription == selectedStudent.PersonGender)
                {
                    break;
                }
            }

            comboBox_GenderSelection.SelectedIndex = selectedGenderIndex;
            datePicker_DateOfBirth.SelectedDate = selectedStudent.DateofBirth;


        }
        /// <summary>
        /// When user clicks on the button, user input gets verified
        /// and then information gets send to EditStudent() method in Control.cs.
        /// This results in student details being altered in the database.
        /// </summary>
        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;
            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)ComboBoxSelectStudent.SelectedItem;
            int studentID = selectedStudent.Id;

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

            string outcome = App.logic.ManageDB("EditStudent",
                new object[] { studentID, address, genderID, mobile, email, dob, firstName, lastName });
            MessageBox.Show(outcome);

            GoBack();
        }

        /// <summary>
        /// When user clicks button, information gets send to DeleteStudent() method in Control.cs.
        /// This results in student details being deleted in the database.
        /// </summary>
        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)ComboBoxSelectStudent.SelectedItem;

            string outcome = App.logic.ManageDB("DeleteStudent", new object[] { selectedStudent.Id });
            MessageBox.Show(outcome);

            GoBack();
        }
    }
}
