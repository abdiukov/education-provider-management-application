using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Edit
{
    /// <summary>
    /// Page that allows the user to select one of existing teachers and then either append its details in the database or delete the unit details
    /// </summary>
    public partial class EditUnit : Window
    {
        private readonly List<Unit> allUnits = new List<Unit>();

        /// <summary>
        /// Initialises the page.
        /// The combobox and the allUnits are filled from Control.cs method GetUnits()
        /// </summary>
        public EditUnit()
        {
            InitializeComponent();
            allUnits = (List<Unit>)App.logic.GetFromDB("GetUnits");
            ComboBoxSelectUnit.ItemsSource = allUnits;
        }

        /// <summary>
        /// Redirects the user to the main menu
        /// </summary>
        private void GoBack()
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

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
        /// When user selects one of units in the combobox, all the textboxes get filled.
        /// </summary>
        private void ComboBoxSelectUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selectedUnit = (Unit)ComboBoxSelectUnit.SelectedItem;

            textBox_Name.Text = selectedUnit.UnitName;
            textBox_Hours.Text = selectedUnit.NumberOfHours.ToString();
        }

        /// <summary>
        /// When user clicks on the button, user input gets verified
        /// and then information gets send to EditUnit() method in Control.cs.
        /// This results in unit details being altered in the database.
        /// </summary>
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

        /// <summary>
        /// When user clicks button, information gets send to DeleteUnit() method in Control.cs.
        /// This results in unit details being deleted in the database.
        /// </summary>
        private void BtnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)ComboBoxSelectUnit.SelectedItem;
            string outcome = App.logic.ManageDB("DeleteUnit", new object[] { selectedUnit.UnitID });
            MessageBox.Show(outcome);
            GoBack();
        }

        /// <summary>
        /// If the main window is not visible, and this window is being closed - shut down the application.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
