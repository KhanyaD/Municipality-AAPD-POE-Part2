using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public class MyReportsForm : Form
    {
        private readonly Color navy = Color.FromArgb(8, 42, 76);
        private readonly Color teal = Color.FromArgb(0, 145, 148);
        private DataGridView grid;
        private Label lblReference, lblDetails, lblTimeline, lblCurrentStatus;
        private Button btnAdvance;

        public MyReportsForm()
        {
            BuildInterface();
            Load += (s, e) => RefreshGrid();
        }

        private void BuildInterface()
        {
            Font = new Font("Segoe UI", 10F);
            Text = "Ubuntu Municipality | My Reports";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1040, 720);
            BackColor = Color.FromArgb(244, 248, 251);

            Panel side = new Panel { Dock = DockStyle.Left, Width = 210, BackColor = navy };
            side.Controls.Add(new Label { Text = "UBUNTU\nMUNICIPALITY", ForeColor = Color.White, Font = new Font("Segoe UI", 16F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(10, 35), Size = new Size(190, 72) });
            side.Controls.Add(new Label { Text = "▣   My Reports", ForeColor = Color.White, BackColor = teal, Font = new Font("Segoe UI", 10F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(20, 0, 0, 0), Location = new Point(8, 150), Size = new Size(194, 46) });
            Button back = new Button { Text = "←  Back to Dashboard", ForeColor = Color.White, BackColor = navy, FlatStyle = FlatStyle.Flat, Location = new Point(15, 640), Size = new Size(180, 40) };
            back.FlatAppearance.BorderColor = Color.FromArgb(65, 102, 135); back.Click += (s, e) => Close(); side.Controls.Add(back);

            Label title = new Label { Text = "Track Your Reports", Font = new Font("Segoe UI", 23F, FontStyle.Bold), ForeColor = navy, AutoSize = true, Location = new Point(245, 25) };
            Label sub = new Label { Text = "Select a report to view its current municipal service status.", ForeColor = Color.DimGray, AutoSize = true, Location = new Point(249, 69) };
            grid = new DataGridView { Location = new Point(250, 110), Size = new Size(750, 220), BackgroundColor = Color.White, BorderStyle = BorderStyle.None, ReadOnly = true, AllowUserToAddRows = false, RowHeadersVisible = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            grid.EnableHeadersVisualStyles = false; grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = navy, ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }; grid.SelectionChanged += Grid_SelectionChanged;

            Panel detail = new Panel { Location = new Point(250, 355), Size = new Size(750, 295), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            lblReference = new Label { Text = "No report selected", Font = new Font("Segoe UI", 17F, FontStyle.Bold), ForeColor = teal, AutoSize = true, Location = new Point(25, 20) };
            lblDetails = new Label { ForeColor = navy, Location = new Point(28, 63), Size = new Size(680, 48) };
            lblTimeline = new Label { Text = "●────────○────────○────────○\nReported        Assigned        In Progress        Resolved", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = teal, Location = new Point(30, 125), Size = new Size(680, 58), TextAlign = ContentAlignment.MiddleCenter };
            lblCurrentStatus = new Label { Text = "Current status: —", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = navy, AutoSize = true, Location = new Point(28, 215) };
            btnAdvance = new Button { Text = "Demonstrate Next Status", BackColor = teal, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(510, 207), Size = new Size(200, 40) }; btnAdvance.FlatAppearance.BorderSize = 0; btnAdvance.Click += BtnAdvance_Click;
            detail.Controls.AddRange(new Control[] { lblReference, lblDetails, lblTimeline, lblCurrentStatus, btnAdvance });
            Controls.AddRange(new Control[] { detail, grid, title, sub, side });
        }

        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = IssueRepository.Issues.OrderByDescending(i => i.DateReported).Select(i => new { Reference = i.ReferenceNumber, i.Category, Location = i.Location, Date = i.DateReported.ToString("dd MMM yyyy"), i.Status }).ToList();
            if (IssueRepository.Issues.Count == 0) { lblReference.Text = "No reports submitted yet"; lblDetails.Text = "Return to Report an Issue to submit your first municipal service report."; btnAdvance.Enabled = false; }
        }

        private ReportedIssue SelectedIssue()
        {
            if (grid.CurrentRow == null) return null;
            string reference = Convert.ToString(grid.CurrentRow.Cells["Reference"].Value);
            return IssueRepository.Issues.FirstOrDefault(i => i.ReferenceNumber == reference);
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            ReportedIssue issue = SelectedIssue(); if (issue == null) return;
            lblReference.Text = issue.ReferenceNumber;
            lblDetails.Text = issue.Category + " • " + issue.Location + "\nReported " + issue.DateReported.ToString("dd MMMM yyyy 'at' HH:mm") + (issue.IsEmergency ? "  •  EMERGENCY" : "");
            lblCurrentStatus.Text = "Current status: " + issue.Status;
            string[] steps = { "Reported", "Assigned", "In Progress", "Resolved" }; int n = Array.IndexOf(steps, issue.Status);
            lblTimeline.Text = (n >= 0 ? "●" : "○") + "────────" + (n >= 1 ? "●" : "○") + "────────" + (n >= 2 ? "●" : "○") + "────────" + (n >= 3 ? "●" : "○") + "\nReported        Assigned        In Progress        Resolved";
            btnAdvance.Enabled = issue.Status != "Resolved";
        }

        private void BtnAdvance_Click(object sender, EventArgs e)
        {
            ReportedIssue issue = SelectedIssue(); if (issue == null) return;
            string[] steps = { "Reported", "Assigned", "In Progress", "Resolved" }; int n = Array.IndexOf(steps, issue.Status);
            if (n >= 0 && n < steps.Length - 1) issue.Status = steps[n + 1];
            RefreshGrid();
        }
    }
}
