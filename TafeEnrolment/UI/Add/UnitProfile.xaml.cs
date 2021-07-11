using System;
using System.Windows;
using System.Windows.Controls;

namespace UI.Add
{
    /// <summary>
    /// Interaction logic for UnitProfile.xaml
    /// </summary>
    public partial class UnitProfile : Window
    {
        public UnitProfile()
        {
            InitializeComponent();
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
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }


        /// <summary>
        /// Redirects the user to the main menu
        /// </summary>
        private void GoBack()
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// When user clicks on the button, user input gets verified
        /// and then information gets send to InsertUnit() method in Control.cs.
        /// This results in unit details being added to the database.
        /// </summary>
        private void BtnAddUnit_Click(object sender, RoutedEventArgs e)
        {
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

            string outcome = App.logic.ManageDB("InsertUnit", new object[] { unitName, amountOfHours });
            MessageBox.Show(outcome);
            GoBack();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
