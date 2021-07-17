using Model;
using System.Collections.Generic;
using System.Windows;

namespace View.Edit
{
    /// <summary>
    /// Page which allows the user to select the course outcome for the CourseStudentID provided
    /// </summary>
    public partial class SelectNewOutcome : Window
    {
        private readonly int CourseStudentID;
        public SelectNewOutcome(int CourseStudentID, List<Outcome> allOutcomes)
        {
            InitializeComponent();
            this.CourseStudentID = CourseStudentID;
            CbOutcome.ItemsSource = allOutcomes;
        }

        /// <summary>
        /// Verifies user input and then sends that information into database.
        /// Shows user the outcome of student outcome being modified.
        /// </summary>
        private void Btn_EditOutcome_Click(object sender, RoutedEventArgs e)
        {
            if (CbOutcome.SelectedItem is null)
            {
                MessageBox.Show("Please select the outcome");
                return;
            }
            Outcome selectedOutcome = (Outcome)CbOutcome.SelectedItem;

            string outcome = App.logic.ManageDB("EditStudentOutcome", new object[] { selectedOutcome.OutcomeID, CourseStudentID });
            MessageBox.Show(outcome);
            Close();
        }
    }
}
