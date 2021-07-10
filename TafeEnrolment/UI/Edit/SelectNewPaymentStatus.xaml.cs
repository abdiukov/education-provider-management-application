using System.Windows;

namespace UI.Edit
{
    /// <summary>
    /// Interaction logic for SelectNewPaymentStatus.xaml
    /// </summary>
    public partial class SelectNewPaymentStatus : Window
    {
        private readonly int CourseStudentID;
        public SelectNewPaymentStatus(double AmountPaid, double AmountDue, int CourseStudentID)
        {
            InitializeComponent();
            Textbox_AmountDue.Text = AmountDue.ToString();
            Textbox_AmountPaid.Text = AmountPaid.ToString();
            this.CourseStudentID = CourseStudentID;
        }

        private void Btn_UpdatePayment_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(Textbox_AmountPaid.Text, out double amountPaid))
            {
                MessageBox.Show("Please enter a number into \"Amount Paid\"");
                return;
            }
            if (!double.TryParse(Textbox_AmountDue.Text, out double amountDue))
            {
                MessageBox.Show("Please enter a number into \"Amount Due\"");
                return;
            }

            if (amountPaid < 0)
            {
                MessageBox.Show("Amount paid cannot be negative");
                return;
            }

            if (amountDue < 0)
            {
                MessageBox.Show("Amount due cannot be negative");
                return;
            }

            if (amountPaid > amountDue)
            {
                MessageBox.Show("Amount paid cannot be more than amount due");
                return;
            }



            string outcome = App.logic.ManageDB("EditStudentPayment", new object[] { CourseStudentID, amountPaid, amountDue });
            MessageBox.Show(outcome);
            Close();
        }
    }
}
