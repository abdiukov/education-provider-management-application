using BusinessLayer;
using ModelLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Course
{
    /// <summary>
    /// Interaction logic for CourseProfile.xaml
    /// </summary>
    public partial class CourseProfile : Window
    {
        //VARIABLE DECLARATIONS


        public static List<BusinessLayer.Student> allStudents = new List<BusinessLayer.Student>();

        private List<BusinessLayer.Unit> allUnits = new List<BusinessLayer.Unit>();

        private List<BusinessLayer.Teacher> allTeachers = new List<BusinessLayer.Teacher>();

        public static List<BusinessLayer.Student> selectedStudents;

        public static List<BusinessLayer.Unit> selectedUnits;

        public static List<BusinessLayer.Teacher> selectedTeachers;


        Logic logic = new Logic();
        //INITIALISATION CODE
        public CourseProfile()
        {
            InitializeComponent();

            //UI
            comboBox_Locations.ItemsSource = logic.GetLocations();
            comboBox_Delivery.ItemsSource = logic.GetDelivery();
            IEnumerable<Semester> availableSemesters = logic.GetSemesters();
            comboBox_SemesterStart.ItemsSource = availableSemesters;
            comboBox_SemesterEnd.ItemsSource = availableSemesters;

            //LOGIC
            allStudents = (List<BusinessLayer.Student>)logic.GetAvailableStudents();
            allUnits = (List<Unit>)logic.GetUnits();
            allTeachers = (List<BusinessLayer.Teacher>)logic.GetTeachers();

            //RESETTING STATIC PUBLIC VALUES

            selectedStudents = new List<BusinessLayer.Student>();
            selectedUnits = new List<BusinessLayer.Unit>();
            selectedTeachers = new List<BusinessLayer.Teacher>();

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

        //END OF NAVIGATION CODE

        private void BtnSelectTeachers_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectTeacher pageobj = new CourseSelectTeacher(allTeachers);
            pageobj.Show();
        }

        private void BtnSelectUnits_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectUnits pageobj = new CourseSelectUnits(allUnits);
            pageobj.Show();
        }

        private void BtnSelectStudents_Click(object sender, RoutedEventArgs e)
        {
            CourseSelectStudent pageobj = new CourseSelectStudent();
            pageobj.Show();
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {

        }



    }
}
