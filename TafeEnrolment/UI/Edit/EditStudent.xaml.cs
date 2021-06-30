using BusinessLayer;
using ModelLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        Logic logic = new Logic();

        private List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();

        private List<BusinessLayer.Gender> allGenders = new List<BusinessLayer.Gender>();


        public EditStudent()
        {
            InitializeComponent();
            allStudents = (List<BusinessLayer.Student>)logic.GetStudents(true);
            allGenders = (List<BusinessLayer.Gender>)logic.GetGenders();

            cbSelectStudent.ItemsSource = allStudents;
            comboBox_GenderSelection.ItemsSource = allGenders;
        }


        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void GoBack()
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

        private void cbSelectStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)cbSelectStudent.SelectedItem;

            textBox_Address.Text = selectedStudent.Address;
            textBox_PhoneNumber.Text = selectedStudent.Mobile;
            textBox_Email.Text = selectedStudent.Email;
            textBox_FirstName.Text = selectedStudent.FirstName;
            textBox_LastName.Text = selectedStudent.LastName;

            int selectedGenderIndex = -1;

            foreach (Gender item in allGenders)
            {
                selectedGenderIndex++;
                if (item.GenderDescription == selectedStudent.StudentGender)
                {
                    break;
                }
            }

            comboBox_GenderSelection.SelectedIndex = selectedGenderIndex;
            datePicker_DateOfBirth.SelectedDate = selectedStudent.DateofBirth;

        }
        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;
            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string dob = datePicker_DateOfBirth.SelectedDate.Value.ToString("yyyy-mm-dd");
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)cbSelectStudent.SelectedItem;
            int studentID = selectedStudent.Id;

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

            string outcome = logic.EditStudent(studentID, address, genderID, mobile, email, dob, firstName, lastName);
            MessageBox.Show(outcome);

            GoBack();
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)cbSelectStudent.SelectedItem;

            string outcome = logic.DeleteStudent(selectedStudent.Id);
            MessageBox.Show(outcome);

            GoBack();
        }
    }
}
