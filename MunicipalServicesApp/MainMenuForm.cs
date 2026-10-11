using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // ============================================================
        // REPORT ISSUES
        // PART 1 - ACTIVE
        // ============================================================

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            try
            {
                ReportIssueForm reportForm = new ReportIssueForm();

                this.Hide();

                reportForm.FormClosed += (s, args) =>
                {
                    this.Show();
                };

                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open the Report Issues page.\n\n" +
                    ex.Message,
                    "Ubuntu Municipality",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // LOCAL EVENTS AND ANNOUNCEMENTS
        // PART 2 - ACTIVE
        // ============================================================

        private void btnLocalEventsAnnouncements_Click(
            object sender,
            EventArgs e)
        {
            using (var eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog(this);
            }
        }


        // ============================================================
        // SERVICE REQUEST STATUS
        // PART 3 - NOT ACTIVE YET
        // ============================================================

        private void btnServiceRequestStatus_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Service Request Status will be available soon.",
                "Ubuntu Municipality",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // ============================================================
        // FORM LOAD
        // Needed because Designer is linked to MainMenuForm_Load
        // ============================================================

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }
    }
}