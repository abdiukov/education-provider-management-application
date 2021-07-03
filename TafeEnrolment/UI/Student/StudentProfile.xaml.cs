using BusinessLayer;
using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    public partial class StudentProfile : Window
    {

        //INITIALISATION CODE
        public StudentProfile()
        {
            InitializeComponent();
            comboBox_GenderSelection.ItemsSource = App.logic.GetFromDB("GetGenders");
            comboBox_Course.ItemsSource = App.logic.GetFromDB("GetCourses");

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
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new MainWindow());
            Hide();
        }


        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
            Hide();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
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

        //END OF NAVIGATION CODE
    }
}
