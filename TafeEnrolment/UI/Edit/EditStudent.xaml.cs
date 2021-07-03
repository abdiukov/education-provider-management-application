using BusinessLayer;
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


        private readonly List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();

        private readonly List<BusinessLayer.Gender> allGenders = new List<BusinessLayer.Gender>();


        public EditStudent()
        {
            InitializeComponent();
            allStudents = (List<BusinessLayer.Student>)App.logic.GetFromDB("GetStudents");
            allStudents = App.logic.SortStudentList(allStudents);
            allGenders = (List<BusinessLayer.Gender>)App.logic.GetFromDB("GetGenders");

            ComboBoxSelectStudent.ItemsSource = allStudents;
            comboBox_GenderSelection.ItemsSource = allGenders;
        }


        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        private void ComboBoxSelectStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)ComboBoxSelectStudent.SelectedItem;

            textBox_Address.Text = selectedStudent.Address;
            textBox_PhoneNumber.Text = selectedStudent.Mobile;
            textBox_Email.Text = selectedStudent.Email;
            textBox_FirstName.Text = selectedStudent.FirstName;
            textBox_LastName.Text = selectedStudent.LastName;

            int selecteDgenderIndex = -1;

            foreach (Gender item in allGenders)
            {
                selecteDgenderIndex++;
                if (item.GenderDescription == selectedStudent.PersonGender)
                {
                    break;
                }
            }

            comboBox_GenderSelection.SelectedIndex = selecteDgenderIndex;
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

            string outcome = App.logic.ManageDB("EditStudent",
                new object[] { studentID, address, genderID, mobile, email, dob, firstName, lastName });
            MessageBox.Show(outcome);

            GoBack();
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            BusinessLayer.Student selectedStudent = (BusinessLayer.Student)ComboBoxSelectStudent.SelectedItem;

            string outcome = App.logic.ManageDB("DeleteStudent", new object[] { selectedStudent.Id });
            MessageBox.Show(outcome);

            GoBack();
        }
    }
}
