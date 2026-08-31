using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlReportCard;
        private Panel pnlEventsCard;
        private Panel pnlStatusCard;
        private Panel pnlCommitment;
        private Panel pnlFooter;
        private Panel pnlDateCard;

        private Label lblLogo;
        private Label lblHeading;
        private Label lblWelcome;
        private Label lblDivider;
        private Label lblDate;
        private Label lblDay;

        private Label lblReportIcon;
        private Label lblReportTitle;
        private Label lblReportDescription;

        private Label lblEventsIcon;
        private Label lblEventsTitle;
        private Label lblEventsDescription;

        private Label lblStatusIcon;
        private Label lblStatusTitle;
        private Label lblStatusDescription;

        private Label lblCommitmentIcon;
        private Label lblCommitment;

        private Label lblPhone;
        private Label lblEmail;
        private Label lblWebsite;
        private Label lblCopyright;

        private Button btnReportIssues;
        private Button btnLocalEventsAnnouncements;
        private Button btnServiceRequestStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlHeader = new Panel();
            pnlReportCard = new Panel();
            pnlEventsCard = new Panel();
            pnlStatusCard = new Panel();
            pnlCommitment = new Panel();
            pnlFooter = new Panel();
            pnlDateCard = new Panel();

            lblLogo = new Label();
            lblHeading = new Label();
            lblWelcome = new Label();
            lblDivider = new Label();
            lblDate = new Label();
            lblDay = new Label();

            lblReportIcon = new Label();
            lblReportTitle = new Label();
            lblReportDescription = new Label();

            lblEventsIcon = new Label();
            lblEventsTitle = new Label();
            lblEventsDescription = new Label();

            lblStatusIcon = new Label();
            lblStatusTitle = new Label();
            lblStatusDescription = new Label();

            lblCommitmentIcon = new Label();
            lblCommitment = new Label();

            lblPhone = new Label();
            lblEmail = new Label();
            lblWebsite = new Label();
            lblCopyright = new Label();

            btnReportIssues = new Button();
            btnLocalEventsAnnouncements = new Button();
            btnServiceRequestStatus = new Button();

            SuspendLayout();

            // ============================================================
            // MAIN FORM
            // ============================================================

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 253);
            ClientSize = new Size(1180, 760);
            MinimumSize = new Size(1100, 760);

            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            Text = "Ubuntu Municipality | Citizen Services";
            Font = new Font("Segoe UI", 10F);

            Load += MainMenuForm_Load;

            // ============================================================
            // HEADER
            // ============================================================

            pnlHeader.BackColor = Color.FromArgb(242, 248, 253);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 220;

            // Logo
            lblLogo.Text = "🏛";
            lblLogo.Font = new Font("Segoe UI Emoji", 36F);
            lblLogo.ForeColor = Color.FromArgb(8, 42, 76);

            lblLogo.Location = new Point(35, 25);
            lblLogo.Size = new Size(100, 80);

            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            // Main heading
            lblHeading.Text = "UBUNTU MUNICIPALITY";

            lblHeading.Font =
                new Font("Segoe UI", 28F, FontStyle.Bold);

            lblHeading.ForeColor =
                Color.FromArgb(8, 42, 76);

            lblHeading.Location =
                new Point(200, 50);

            lblHeading.Size =
                new Size(720, 60);

            lblHeading.TextAlign =
                ContentAlignment.MiddleCenter;

            // Divider
            lblDivider.Text = "────────   ●   ────────";

            lblDivider.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            lblDivider.ForeColor =
                Color.FromArgb(30, 117, 193);

            lblDivider.Location =
                new Point(350, 105);

            lblDivider.Size =
                new Size(420, 30);

            lblDivider.TextAlign =
                ContentAlignment.MiddleCenter;

            // Welcome
            lblWelcome.Text =
                "Welcome! How can we assist you today?";

            lblWelcome.Font =
                new Font("Segoe UI", 17F);

            lblWelcome.ForeColor =
                Color.FromArgb(75, 86, 105);

            lblWelcome.Location =
                new Point(280, 145);

            lblWelcome.Size =
                new Size(560, 40);

            lblWelcome.TextAlign =
                ContentAlignment.MiddleCenter;

            // ============================================================
            // DATE CARD
            // ============================================================

            pnlDateCard.BackColor = Color.White;

            pnlDateCard.BorderStyle =
                BorderStyle.FixedSingle;

            pnlDateCard.Location =
                new Point(930, 25);

            pnlDateCard.Size =
                new Size(190, 90);

            pnlDateCard.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            // Date
            lblDate.Text =
                "18 August 2026";

            lblDate.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            lblDate.ForeColor =
                Color.FromArgb(8, 42, 76);

            lblDate.Location =
                new Point(10, 18);

            lblDate.Size =
                new Size(168, 26);

            lblDate.TextAlign =
                ContentAlignment.MiddleCenter;

            // Day
            lblDay.Text =
                "Tuesday";

            lblDay.Font =
                new Font("Segoe UI", 10F);

            lblDay.ForeColor =
                Color.DimGray;

            lblDay.Location =
                new Point(10, 50);

            lblDay.Size =
                new Size(168, 24);

            lblDay.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlDateCard.Controls.Add(lblDate);
            pnlDateCard.Controls.Add(lblDay);

            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblHeading);
            pnlHeader.Controls.Add(lblDivider);
            pnlHeader.Controls.Add(lblWelcome);

            // Add date card last
            pnlHeader.Controls.Add(pnlDateCard);

            // Make sure nothing overlaps it
            pnlDateCard.BringToFront();

            // ============================================================
            // REPORT ISSUE CARD
            // ============================================================

            pnlReportCard.BackColor = Color.White;

            pnlReportCard.BorderStyle =
                BorderStyle.FixedSingle;

            pnlReportCard.Location =
                new Point(70, 240);

            pnlReportCard.Size =
                new Size(290, 300);

            lblReportIcon.Text = "✎";

            lblReportIcon.Font =
                new Font("Segoe UI Symbol", 36F, FontStyle.Bold);

            lblReportIcon.ForeColor =
                Color.FromArgb(16, 105, 210);

            lblReportIcon.Location =
                new Point(85, 25);

            lblReportIcon.Size =
                new Size(120, 70);

            lblReportIcon.TextAlign =
                ContentAlignment.MiddleCenter;

            lblReportTitle.Text =
                "Report Issues";

            lblReportTitle.Font =
                new Font("Segoe UI", 17F, FontStyle.Bold);

            lblReportTitle.ForeColor =
                Color.FromArgb(16, 105, 210);

            lblReportTitle.Location =
                new Point(25, 100);

            lblReportTitle.Size =
                new Size(240, 40);

            lblReportTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblReportDescription.Text =
                "Report service delivery issues\r\nin your area.";

            lblReportDescription.Font =
                new Font("Segoe UI", 10F);

            lblReportDescription.ForeColor =
                Color.FromArgb(85, 95, 110);

            lblReportDescription.Location =
                new Point(25, 150);

            lblReportDescription.Size =
                new Size(240, 55);

            lblReportDescription.TextAlign =
                ContentAlignment.MiddleCenter;

            btnReportIssues.Text =
                "Get Started   →";

            btnReportIssues.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnReportIssues.ForeColor =
                Color.White;

            btnReportIssues.BackColor =
                Color.FromArgb(16, 105, 210);

            btnReportIssues.FlatStyle =
                FlatStyle.Flat;

            btnReportIssues.FlatAppearance.BorderSize =
                0;

            btnReportIssues.Cursor =
                Cursors.Hand;

            btnReportIssues.Location =
                new Point(30, 225);

            btnReportIssues.Size =
                new Size(230, 50);

            btnReportIssues.Click +=
                btnReportIssues_Click;

            pnlReportCard.Controls.Add(lblReportIcon);
            pnlReportCard.Controls.Add(lblReportTitle);
            pnlReportCard.Controls.Add(lblReportDescription);
            pnlReportCard.Controls.Add(btnReportIssues);

            // ============================================================
            // EVENTS CARD
            // ============================================================

            pnlEventsCard.BackColor = Color.White;

            pnlEventsCard.BorderStyle =
                BorderStyle.FixedSingle;

            pnlEventsCard.Location =
                new Point(400, 240);

            pnlEventsCard.Size =
                new Size(290, 300);

            lblEventsIcon.Text = "▣";

            lblEventsIcon.Font =
                new Font("Segoe UI Symbol", 34F, FontStyle.Bold);

            lblEventsIcon.ForeColor =
                Color.FromArgb(36, 145, 85);

            lblEventsIcon.Location =
                new Point(85, 25);

            lblEventsIcon.Size =
                new Size(120, 70);

            lblEventsIcon.TextAlign =
                ContentAlignment.MiddleCenter;

            lblEventsTitle.Text =
                "Local Events and\r\nAnnouncements";

            lblEventsTitle.Font =
                new Font("Segoe UI", 15F, FontStyle.Bold);

            lblEventsTitle.ForeColor =
                Color.FromArgb(36, 145, 85);

            lblEventsTitle.Location =
                new Point(20, 95);

            lblEventsTitle.Size =
                new Size(250, 60);

            lblEventsTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblEventsDescription.Text =
                "View upcoming events and\r\nimportant announcements.";

            lblEventsDescription.Font =
                new Font("Segoe UI", 10F);

            lblEventsDescription.ForeColor =
                Color.FromArgb(85, 95, 110);

            lblEventsDescription.Location =
                new Point(20, 160);

            lblEventsDescription.Size =
                new Size(250, 50);

            lblEventsDescription.TextAlign =
                ContentAlignment.MiddleCenter;

            btnLocalEventsAnnouncements.Text =
                "View Events   →";

            btnLocalEventsAnnouncements.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnLocalEventsAnnouncements.ForeColor =
                Color.FromArgb(36, 145, 85);

            btnLocalEventsAnnouncements.BackColor =
                Color.White;

            btnLocalEventsAnnouncements.FlatStyle =
                FlatStyle.Flat;

            btnLocalEventsAnnouncements.FlatAppearance.BorderColor =
                Color.FromArgb(36, 145, 85);

            btnLocalEventsAnnouncements.FlatAppearance.BorderSize =
                1;

            btnLocalEventsAnnouncements.Cursor =
                Cursors.Hand;

            btnLocalEventsAnnouncements.Location =
                new Point(30, 225);

            btnLocalEventsAnnouncements.Size =
                new Size(230, 50);

            btnLocalEventsAnnouncements.Click +=
                btnLocalEventsAnnouncements_Click;

            pnlEventsCard.Controls.Add(lblEventsIcon);
            pnlEventsCard.Controls.Add(lblEventsTitle);
            pnlEventsCard.Controls.Add(lblEventsDescription);
            pnlEventsCard.Controls.Add(btnLocalEventsAnnouncements);

            // ============================================================
            // STATUS CARD
            // ============================================================

            pnlStatusCard.BackColor = Color.White;

            pnlStatusCard.BorderStyle =
                BorderStyle.FixedSingle;

            pnlStatusCard.Location =
                new Point(730, 240);

            pnlStatusCard.Size =
                new Size(290, 300);

            lblStatusIcon.Text =
                "☷";

            lblStatusIcon.Font =
                new Font("Segoe UI Symbol", 36F, FontStyle.Bold);

            lblStatusIcon.ForeColor =
                Color.FromArgb(108, 62, 205);

            lblStatusIcon.Location =
                new Point(85, 25);

            lblStatusIcon.Size =
                new Size(120, 70);

            lblStatusIcon.TextAlign =
                ContentAlignment.MiddleCenter;

            lblStatusTitle.Text =
                "Service Request\r\nStatus";

            lblStatusTitle.Font =
                new Font("Segoe UI", 16F, FontStyle.Bold);

            lblStatusTitle.ForeColor =
                Color.FromArgb(108, 62, 205);

            lblStatusTitle.Location =
                new Point(20, 100);

            lblStatusTitle.Size =
                new Size(250, 60);

            lblStatusTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblStatusDescription.Text =
                "Check the status of your\r\nsubmitted service requests.";

            lblStatusDescription.Font =
                new Font("Segoe UI", 10F);

            lblStatusDescription.ForeColor =
                Color.FromArgb(85, 95, 110);

            lblStatusDescription.Location =
                new Point(20, 165);

            lblStatusDescription.Size =
                new Size(250, 50);

            lblStatusDescription.TextAlign =
                ContentAlignment.MiddleCenter;

            btnServiceRequestStatus.Text =
                "Check Status   →";

            btnServiceRequestStatus.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnServiceRequestStatus.ForeColor =
                Color.FromArgb(108, 62, 205);

            btnServiceRequestStatus.BackColor =
                Color.White;

            btnServiceRequestStatus.FlatStyle =
                FlatStyle.Flat;

            btnServiceRequestStatus.FlatAppearance.BorderColor =
                Color.FromArgb(108, 62, 205);

            btnServiceRequestStatus.FlatAppearance.BorderSize =
                1;

            btnServiceRequestStatus.Cursor =
                Cursors.Hand;

            btnServiceRequestStatus.Location =
                new Point(30, 225);

            btnServiceRequestStatus.Size =
                new Size(230, 50);

            btnServiceRequestStatus.Click +=
                btnServiceRequestStatus_Click;

            pnlStatusCard.Controls.Add(lblStatusIcon);
            pnlStatusCard.Controls.Add(lblStatusTitle);
            pnlStatusCard.Controls.Add(lblStatusDescription);
            pnlStatusCard.Controls.Add(btnServiceRequestStatus);

            // ============================================================
            // COMMITMENT CARD
            // ============================================================

            pnlCommitment.BackColor =
                Color.FromArgb(237, 246, 255);

            pnlCommitment.BorderStyle =
                BorderStyle.FixedSingle;

            pnlCommitment.Location =
                new Point(70, 565);

            pnlCommitment.Size =
                new Size(950, 75);

            lblCommitmentIcon.Text =
                "ⓘ";

            lblCommitmentIcon.Font =
                new Font("Segoe UI Symbol", 24F, FontStyle.Bold);

            lblCommitmentIcon.ForeColor =
                Color.FromArgb(16, 105, 210);

            lblCommitmentIcon.Location =
                new Point(20, 14);

            lblCommitmentIcon.Size =
                new Size(50, 45);

            lblCommitmentIcon.TextAlign =
                ContentAlignment.MiddleCenter;

            lblCommitment.Text =
                "Our Commitment:  Building better communities through efficient and transparent service delivery.\r\n" +
                "Together, we can make a difference!";

            lblCommitment.Font =
                new Font("Segoe UI", 10F);

            lblCommitment.ForeColor =
                Color.FromArgb(45, 65, 90);

            lblCommitment.Location =
                new Point(80, 14);

            lblCommitment.Size =
                new Size(830, 48);

            lblCommitment.TextAlign =
                ContentAlignment.MiddleLeft;

            pnlCommitment.Controls.Add(lblCommitmentIcon);
            pnlCommitment.Controls.Add(lblCommitment);

            // ============================================================
            // FOOTER
            // ============================================================

            pnlFooter.BackColor =
                Color.FromArgb(7, 55, 100);

            pnlFooter.Dock =
                DockStyle.Bottom;

            pnlFooter.Height =
                95;

            lblPhone.Text =
                "☎  0800 123 456\r\n     Toll-Free Line";

            lblPhone.Font =
                new Font("Segoe UI", 9F);

            lblPhone.ForeColor =
                Color.White;

            lblPhone.Location =
                new Point(45, 15);

            lblPhone.Size =
                new Size(230, 45);

            lblEmail.Text =
                "✉  info@municipal.gov.za\r\n     Email Us";

            lblEmail.Font =
                new Font("Segoe UI", 9F);

            lblEmail.ForeColor =
                Color.White;

            lblEmail.Location =
                new Point(350, 15);

            lblEmail.Size =
                new Size(250, 45);

            lblWebsite.Text =
                "◎  www.municipal.gov.za\r\n     Visit Website";

            lblWebsite.Font =
                new Font("Segoe UI", 9F);

            lblWebsite.ForeColor =
                Color.White;

            lblWebsite.Location =
                new Point(680, 15);

            lblWebsite.Size =
                new Size(250, 45);

            lblCopyright.Text =
                "© 2026 Ubuntu Municipality. All rights reserved.";

            lblCopyright.Font =
                new Font("Segoe UI", 8F);

            lblCopyright.ForeColor =
                Color.FromArgb(205, 220, 235);

            lblCopyright.Location =
                new Point(380, 65);

            lblCopyright.Size =
                new Size(350, 20);

            lblCopyright.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlFooter.Controls.Add(lblPhone);
            pnlFooter.Controls.Add(lblEmail);
            pnlFooter.Controls.Add(lblWebsite);
            pnlFooter.Controls.Add(lblCopyright);

            // ============================================================
            // ADD CONTROLS TO FORM
            // ============================================================

            Controls.Add(pnlReportCard);
            Controls.Add(pnlEventsCard);
            Controls.Add(pnlStatusCard);
            Controls.Add(pnlCommitment);

            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);

            // Ensure header and date card render correctly
            pnlHeader.BringToFront();
            pnlDateCard.BringToFront();

            ResumeLayout(false);
        }
    }
}