using BusinessLayer;
using ModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace UI.Teacher
{
    public partial class TeacherProfile : Window
    {
        Logic logic = new Logic();
        //INITIALISATION CODE
        public TeacherProfile()
        {
            InitializeComponent();
            comboBox_GenderSelection.ItemsSource = logic.GetGenders();
            comboBox_Course.ItemsSource = logic.GetCourses();
            comboBox_Locations.ItemsSource = logic.GetLocations();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE

        //NAVIGATION CODE
        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;

            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string dob = datePicker_DateOfBirth.SelectedDate.ToString();
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
                MessageBox.Show("Please select teacher gender field ");
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

            CourseSelection selectedCourse = (CourseSelection)comboBox_Course.SelectedItem;

            if (selectedCourse is null)
            {
                MessageBox.Show("Please select a course which the teacher will be enrolled into");
                return;
            }
            int courseID = selectedCourse.CourseID;

            Location selectedLocation = (Location)comboBox_Locations.SelectedItem;

            if (selectedLocation is null)
            {
                MessageBox.Show("Please select the teacher's base location");
                return;
            }

            int locationID = selectedLocation.Id;



            string outcome = logic.InsertNewTeacher(address, genderID, mobile, email, dob,
              firstName, lastName, courseID, locationID);

            MessageBox.Show(outcome);
        }

        //END OF NAVIGATION CODE
    }
}
