using System;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        // Stores the path of the file selected by the user
        private string selectedFilePath = string.Empty;

        public ReportIssueForm()
        {
            InitializeComponent();

            // =========================================================
            // FORM EVENTS
            // =========================================================
            Load += ReportIssueForm_Load;

            // =========================================================
            // INPUT EVENTS
            // =========================================================
            txtLocation.TextChanged += InputChanged;
            cmbCategory.SelectedIndexChanged += InputChanged;
            rtbDescription.TextChanged += InputChanged;

            // =========================================================
            // BUTTON EVENTS
            // =========================================================
            btnAttachFile.Click += btnAttachFile_Click;
            btnSubmit.Click += btnSubmit_Click;
            btnBack.Click += btnBack_Click;

            // =========================================================
            // SIDEBAR NAVIGATION EVENTS
            // =========================================================
            lblDashboard.Click += lblDashboard_Click;
            lblMyReports.Click += lblMyReports_Click;
            lblActiveReport.Click += lblActiveReport_Click;

            // Make sidebar labels feel clickable
            lblDashboard.Cursor = Cursors.Hand;
            lblMyReports.Cursor = Cursors.Hand;
            lblActiveReport.Cursor = Cursors.Hand;
        }

        // =============================================================
        // FORM LOAD
        // =============================================================
        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            // Display today's date
            lblReportDate.Text = DateTime.Now.ToString("dd MMMM yyyy");

            // Populate the category ComboBox
            cmbCategory.Items.Clear();

            cmbCategory.Items.Add("Roads and Potholes");
            cmbCategory.Items.Add("Water and Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Street Lights");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;

            // Initial attachment display
            lblAttachment.Text = "No file selected";

            // Initialise progress
            progressBarReport.Minimum = 0;
            progressBarReport.Maximum = 100;
            progressBarReport.Value = 0;

            lblProgressMessage.Text =
                "Complete the form to increase your progress";

            UpdateProgress();
        }

        // =============================================================
        // SIDEBAR NAVIGATION
        // =============================================================

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            // Closing ReportIssueForm returns the user
            // to the Main Menu / Dashboard that opened it.
            this.Close();
        }

        private void lblMyReports_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the My Reports screen
                using (MyReportsForm myReportsForm = new MyReportsForm())
                {
                    myReportsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open My Reports.\n\n" + ex.Message,
                    "Ubuntu Municipality",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lblActiveReport_Click(object sender, EventArgs e)
        {
            // We are already on the Report an Issue screen.
            // No navigation is required.
            txtLocation.Focus();
        }

        // =============================================================
        // PROGRESS TRACKING
        // =============================================================
        private void InputChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            int completedFields = 0;

            // Location
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                completedFields++;
            }

            // Category
            if (cmbCategory.SelectedIndex >= 0)
            {
                completedFields++;
            }

            // Description
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                completedFields++;
            }

            // Attachment
            if (!string.IsNullOrWhiteSpace(selectedFilePath))
            {
                completedFields++;
            }

            // Four sections = 25% each
            int progress = completedFields * 25;

            progressBarReport.Value = progress;

            if (progress == 0)
            {
                lblProgressMessage.Text =
                    "Complete the form to increase your progress";
            }
            else if (progress == 25)
            {
                lblProgressMessage.Text =
                    "Great start! Keep going.";
            }
            else if (progress == 50)
            {
                lblProgressMessage.Text =
                    "You are halfway there!";
            }
            else if (progress == 75)
            {
                lblProgressMessage.Text =
                    "Almost finished!";
            }
            else if (progress == 100)
            {
                lblProgressMessage.Text =
                    "Ready to submit your report!";
            }
        }

        // =============================================================
        // ATTACH FILE
        // =============================================================
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Supporting File";

                openFileDialog.Filter =
                    "Supported Files|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx|" +
                    "Images|*.jpg;*.jpeg;*.png|" +
                    "PDF Files|*.pdf|" +
                    "Word Documents|*.doc;*.docx|" +
                    "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                    // Only show the filename, not the entire path
                    lblAttachment.Text =
                        Path.GetFileName(selectedFilePath);

                    UpdateProgress();
                }
            }
        }

        // =============================================================
        // SUBMIT REPORT
        // =============================================================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the municipal issue.",
                    "Missing Location",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            // Validate category
            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the municipal issue.",
                    "Missing Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            // Generate a unique municipal reference number
            string referenceNumber =
                "UBU-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");

            // Create a ReportedIssue object
            ReportedIssue newIssue = new ReportedIssue
            {
                Location = txtLocation.Text.Trim(),

                Category =
                    cmbCategory.SelectedItem?.ToString()
                    ?? string.Empty,

                Description = rtbDescription.Text.Trim(),

                AttachmentPath = selectedFilePath,

                DateReported = DateTime.Now,

                ReferenceNumber = referenceNumber,

                Status = "Reported",

                IsEmergency = chkEmergency.Checked
            };

            // Store the submitted report in the List data structure
            IssueRepository.Issues.Add(newIssue);

            // Show successful submission feedback
            MessageBox.Show(
                "Your municipal issue has been submitted successfully!\n\n" +
                "Reference Number: " + newIssue.ReferenceNumber + "\n" +
                "Location: " + newIssue.Location + "\n" +
                "Category: " + newIssue.Category + "\n" +
                "Date: " +
                newIssue.DateReported.ToString("dd MMMM yyyy"),
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        // =============================================================
        // CLEAR FORM
        // =============================================================
        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex = -1;

            rtbDescription.Clear();

            selectedFilePath = string.Empty;

            lblAttachment.Text = "No file selected";

            chkEmergency.Checked = false;

            progressBarReport.Value = 0;

            lblProgressMessage.Text =
                "Complete the form to increase your progress";

            txtLocation.Focus();
        }

        // =============================================================
        // BACK BUTTON
        // =============================================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to Dashboard / Main Menu
            this.Close();
        }

        // =============================================================
        // EXISTING DESIGNER EVENT HANDLERS
        // Keep these so Designer connections remain valid
        // =============================================================
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void lblAttachment_Click(object sender, EventArgs e)
        {
        }

        private void progressBarReport_Click(object sender, EventArgs e)
        {
        }

        private void lblReportTitle_Click(object sender, EventArgs e)
        {
        }
    }
}