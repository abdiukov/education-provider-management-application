using Model;
using System.Collections.Generic;
using System.Windows;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for SelectNewOutcome.xaml
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

        private void Btn_EditOutcome_Click(object sender, RoutedEventArgs e)
        {
            if (CbOutcome.SelectedItem is null)
            {
                MessageBox.Show("Please select the outcome");
                return;
            }
            Outcome selectedOutcome = (Outcome)CbOutcome.SelectedItem;

            string outcome = App.logic.ManageDB("EditStudentOutcome", new object[] { CourseStudentID, selectedOutcome.OutcomeID });
            MessageBox.Show(outcome);
            Close();
        }
    }
}
