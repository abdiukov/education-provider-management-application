using BusinessLayer;
using ModelLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for EditUnit.xaml
    /// </summary>
    public partial class EditUnit : Window
    {
        Logic logic = new Logic();
        public static List<BusinessLayer.Unit> allUnits = new List<BusinessLayer.Unit>();

        public EditUnit()
        {
            InitializeComponent();
            allUnits = (List<Unit>)logic.GetUnits();
            cbSelectUnit.ItemsSource = allUnits;
        }

        private void GoBack()
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
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

        private void cbSelectUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selectedUnit = (Unit)cbSelectUnit.SelectedItem;

            textBox_Name.Text = selectedUnit.Name;
            textBox_Hours.Text = selectedUnit.NumberOfHours.ToString(); ;
        }

        private void BtnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)cbSelectUnit.SelectedItem;
            string outcome = logic.DeleteUnit(selectedUnit.Id);
            MessageBox.Show(outcome);
            GoBack();
        }

        private void BtnEditUnit_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)cbSelectUnit.SelectedItem;

            string unitName = textBox_Name.Text;


            if (string.IsNullOrWhiteSpace(unitName))
            {
                MessageBox.Show("Please enter something into \"Name\" field ");
                return;
            }

            if (!int.TryParse(textBox_Hours.Text, out int amountOfHours))
            {
                MessageBox.Show("Please enter something into \"Hours amount\" field ");
                return;
            }

            string outcome = logic.EditUnit(selectedUnit.Id, unitName, amountOfHours);
            MessageBox.Show(outcome);
            GoBack();
        }
    }
}
