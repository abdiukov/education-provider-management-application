using BusinessLayer;
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

        public static List<BusinessLayer.Unit> allUnits = new List<BusinessLayer.Unit>();

        public EditUnit()
        {
            InitializeComponent();
            allUnits = (List<Unit>)App.logic.GetFromDB("GetUnits");
            ComboBoxSelectUnit.ItemsSource = allUnits;
        }

        private void GoBack()
        {
            PageNavigation.GoToExistingPage(0);
        }        /// <summary>
                 /// When the arrow button (located top left) is clicked, user is redirected to main menu
                 /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
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

        private void ComboBoxSelectUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selectedUnit = (Unit)ComboBoxSelectUnit.SelectedItem;

            textBox_Name.Text = selectedUnit.UnitName;
            textBox_Hours.Text = selectedUnit.NumberOfHours.ToString(); ;
        }

        private void BtnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)ComboBoxSelectUnit.SelectedItem;
            string outcome = App.logic.ManageDB("DeleteUnit", new object[] { selectedUnit.UnitID });
            MessageBox.Show(outcome);
            GoBack();
        }

        private void BtnEditUnit_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)ComboBoxSelectUnit.SelectedItem;

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

            string outcome = App.logic.ManageDB("EditUnit", new object[] { selectedUnit.UnitID, unitName, amountOfHours });
            MessageBox.Show(outcome);
            GoBack();
        }
    }
}
