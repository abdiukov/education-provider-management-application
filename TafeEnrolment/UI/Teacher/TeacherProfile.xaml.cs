using BusinessLayer;
using System.Windows;
using System.Windows.Controls;

namespace UI.Teacher
{
    public partial class TeacherProfile : Window
    {

        //INITIALISATION CODE
        public TeacherProfile()
        {
            InitializeComponent();
            comboBox_GenderSelection.ItemsSource = App.logic.GetFromDB("GetGenders");
            comboBox_Course.ItemsSource = App.logic.GetFromDB("GetCourses");
            comboBox_Locations.ItemsSource = App.logic.GetFromDB("GetLocations");
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE

        //NAVIGATION CODE
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            string address = textBox_Address.Text;

            string mobile = textBox_PhoneNumber.Text;
            string email = textBox_Email.Text;
            string dob = datePicker_DateOfBirth.SelectedDate.Value.ToString("yyyy-MM-dd");
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter something into 'Address' field ");
                return;
            }

            Gender selecteDgender = (Gender)comboBox_GenderSelection.SelectedItem;

            if (selecteDgender is null)
            {
                MessageBox.Show("Please select teacher gender field ");
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

            dynamic selectedCourse = comboBox_Course.SelectedItem;

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



            string outcome =
                App.logic.ManageDB("InsertNewTeacher", new object[] { address, genderID, mobile, email, dob, firstName, lastName, courseID, locationID });

            MessageBox.Show(outcome);
        }

        //END OF NAVIGATION CODE
    }
}
