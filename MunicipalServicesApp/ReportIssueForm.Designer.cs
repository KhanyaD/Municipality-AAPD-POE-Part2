using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel sidebar;
        private Panel header;
        private Panel formCard;
        private Panel attachmentCard;
        private Panel progressCard;

        private Label lblBrand;
        private Label lblDashboard;
        private Label lblActiveReport;
        private Label lblMyReports;

        private Label lblReportTitle;
        private Label lblSubtitle;
        private Label lblReportDate;

        private Label lblLocation;
        private Label lblCategory;
        private Label lblDescription;

        private Label lblAttachment;
        private Label lblEmergencyHelp;

        private Label lblProgressTitle;
        private Label lblProgressMessage;
        private Label lblReferencePreview;

        private TextBox txtLocation;
        private ComboBox cmbCategory;
        private RichTextBox rtbDescription;

        private Button btnAttachFile;
        private Button btnBack;
        private Button btnSubmit;

        private ProgressBar progressBarReport;
        private CheckBox chkEmergency;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.sidebar = new Panel();
            this.header = new Panel();
            this.formCard = new Panel();
            this.attachmentCard = new Panel();
            this.progressCard = new Panel();

            this.lblBrand = new Label();
            this.lblDashboard = new Label();
            this.lblActiveReport = new Label();
            this.lblMyReports = new Label();

            this.lblReportTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblReportDate = new Label();

            this.lblLocation = new Label();
            this.lblCategory = new Label();
            this.lblDescription = new Label();

            this.lblAttachment = new Label();
            this.lblEmergencyHelp = new Label();

            this.lblProgressTitle = new Label();
            this.lblProgressMessage = new Label();
            this.lblReferencePreview = new Label();

            this.txtLocation = new TextBox();
            this.cmbCategory = new ComboBox();
            this.rtbDescription = new RichTextBox();

            this.btnAttachFile = new Button();
            this.btnBack = new Button();
            this.btnSubmit = new Button();

            this.progressBarReport = new ProgressBar();
            this.chkEmergency = new CheckBox();

            this.sidebar.SuspendLayout();
            this.header.SuspendLayout();
            this.formCard.SuspendLayout();
            this.attachmentCard.SuspendLayout();
            this.progressCard.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // SIDEBAR
            // =========================================================
            this.sidebar.BackColor = Color.FromArgb(8, 42, 76);
            this.sidebar.Dock = DockStyle.Left;
            this.sidebar.Location = new Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new Size(210, 760);
            this.sidebar.TabIndex = 0;

            // lblBrand
            this.lblBrand.ForeColor = Color.White;
            this.lblBrand.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblBrand.Location = new Point(10, 35);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new Size(190, 72);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "UBUNTU\r\nMUNICIPALITY";
            this.lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            // lblDashboard
            this.lblDashboard.ForeColor = Color.White;
            this.lblDashboard.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblDashboard.Location = new Point(8, 112);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Padding = new Padding(20, 0, 0, 0);
            this.lblDashboard.Size = new Size(194, 44);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "⌂   Dashboard";
            this.lblDashboard.TextAlign = ContentAlignment.MiddleLeft;

            // lblActiveReport
            this.lblActiveReport.BackColor = Color.FromArgb(0, 145, 148);
            this.lblActiveReport.ForeColor = Color.White;
            this.lblActiveReport.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblActiveReport.Location = new Point(8, 160);
            this.lblActiveReport.Name = "lblActiveReport";
            this.lblActiveReport.Padding = new Padding(20, 0, 0, 0);
            this.lblActiveReport.Size = new Size(194, 46);
            this.lblActiveReport.TabIndex = 2;
            this.lblActiveReport.Text = "✎   Report an Issue";
            this.lblActiveReport.TextAlign = ContentAlignment.MiddleLeft;

            // lblMyReports
            this.lblMyReports.ForeColor = Color.White;
            this.lblMyReports.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblMyReports.Location = new Point(8, 210);
            this.lblMyReports.Name = "lblMyReports";
            this.lblMyReports.Padding = new Padding(20, 0, 0, 0);
            this.lblMyReports.Size = new Size(194, 44);
            this.lblMyReports.TabIndex = 3;
            this.lblMyReports.Text = "▣   My Reports";
            this.lblMyReports.TextAlign = ContentAlignment.MiddleLeft;

            this.sidebar.Controls.Add(this.lblBrand);
            this.sidebar.Controls.Add(this.lblDashboard);
            this.sidebar.Controls.Add(this.lblActiveReport);
            this.sidebar.Controls.Add(this.lblMyReports);

            // =========================================================
            // HEADER
            // =========================================================
            this.header.BackColor = Color.White;
            this.header.Dock = DockStyle.Top;
            this.header.Location = new Point(210, 0);
            this.header.Name = "header";
            this.header.Size = new Size(825, 100);
            this.header.TabIndex = 1;

            // lblReportTitle
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new Font(
                "Segoe UI",
                23F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblReportTitle.ForeColor = Color.FromArgb(8, 42, 76);
            this.lblReportTitle.Location = new Point(32, 18);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Report an Issue";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = Color.DimGray;
            this.lblSubtitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblSubtitle.Location = new Point(36, 62);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Help us respond quickly by providing clear information.";

            // lblReportDate
            this.lblReportDate.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            this.lblReportDate.AutoSize = true;
            this.lblReportDate.ForeColor = Color.FromArgb(8, 42, 76);
            this.lblReportDate.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblReportDate.Location = new Point(680, 36);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.TabIndex = 2;
            this.lblReportDate.Text = "Date";

            this.header.Controls.Add(this.lblReportTitle);
            this.header.Controls.Add(this.lblSubtitle);
            this.header.Controls.Add(this.lblReportDate);

            // =========================================================
            // MAIN FORM CARD
            // =========================================================
            this.formCard.BackColor = Color.White;
            this.formCard.BorderStyle = BorderStyle.FixedSingle;
            this.formCard.Location = new Point(245, 125);
            this.formCard.Name = "formCard";
            this.formCard.Size = new Size(755, 545);
            this.formCard.TabIndex = 2;

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblLocation.ForeColor = Color.FromArgb(8, 42, 76);
            this.lblLocation.Location = new Point(25, 22);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";

            // txtLocation
            this.txtLocation.BorderStyle = BorderStyle.FixedSingle;
            this.txtLocation.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.txtLocation.Location = new Point(25, 51);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new Size(705, 30);
            this.txtLocation.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblCategory.ForeColor = Color.FromArgb(8, 42, 76);
            this.lblCategory.Location = new Point(25, 96);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";

            // cmbCategory
            this.cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbCategory.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new Point(25, 125);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(705, 31);
            this.cmbCategory.TabIndex = 3;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblDescription.ForeColor =
                Color.FromArgb(8, 42, 76);

            this.lblDescription.Location =
                new Point(25, 169);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text =
                "Describe the problem";

            // rtbDescription
            this.rtbDescription.BorderStyle =
                BorderStyle.FixedSingle;

            this.rtbDescription.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.rtbDescription.Location =
                new Point(25, 198);

            this.rtbDescription.Name =
                "rtbDescription";

            this.rtbDescription.Size =
                new Size(705, 105);

            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";

            // =========================================================
            // ATTACHMENT CARD
            // =========================================================
            this.attachmentCard.BackColor =
                Color.FromArgb(248, 252, 252);

            this.attachmentCard.BorderStyle =
                BorderStyle.FixedSingle;

            this.attachmentCard.Location =
                new Point(25, 322);

            this.attachmentCard.Name =
                "attachmentCard";

            this.attachmentCard.Size =
                new Size(440, 92);

            this.attachmentCard.TabIndex = 6;

            // btnAttachFile
            this.btnAttachFile.BackColor = Color.White;
            this.btnAttachFile.Cursor = Cursors.Hand;
            this.btnAttachFile.FlatStyle = FlatStyle.Flat;

            this.btnAttachFile.FlatAppearance.BorderColor =
                Color.FromArgb(0, 145, 148);

            this.btnAttachFile.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.btnAttachFile.ForeColor =
                Color.FromArgb(0, 145, 148);

            this.btnAttachFile.Location =
                new Point(15, 14);

            this.btnAttachFile.Name =
                "btnAttachFile";

            this.btnAttachFile.Size =
                new Size(250, 36);

            this.btnAttachFile.TabIndex = 0;

            this.btnAttachFile.Text =
                "＋  Add photos or documents";

            this.btnAttachFile.UseVisualStyleBackColor = false;

            // lblAttachment
            this.lblAttachment.AutoEllipsis = true;
            this.lblAttachment.ForeColor = Color.DimGray;

            this.lblAttachment.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblAttachment.Location =
                new Point(17, 59);

            this.lblAttachment.Name =
                "lblAttachment";

            this.lblAttachment.Size =
                new Size(400, 22);

            this.lblAttachment.TabIndex = 1;

            this.lblAttachment.Text =
                "No file selected";

            this.attachmentCard.Controls.Add(this.btnAttachFile);
            this.attachmentCard.Controls.Add(this.lblAttachment);

            // =========================================================
            // EMERGENCY CHECKBOX
            // =========================================================
            this.chkEmergency.AutoSize = false;

            this.chkEmergency.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.chkEmergency.ForeColor =
                Color.FromArgb(165, 68, 36);

            this.chkEmergency.Location =
                new Point(490, 337);

            this.chkEmergency.Name =
                "chkEmergency";

            this.chkEmergency.Size =
                new Size(220, 26);

            this.chkEmergency.TabIndex = 7;

            this.chkEmergency.Text =
                "This is an emergency";

            this.chkEmergency.UseVisualStyleBackColor = true;

            // lblEmergencyHelp
            this.lblEmergencyHelp.ForeColor =
                Color.DimGray;

            this.lblEmergencyHelp.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblEmergencyHelp.Location =
                new Point(490, 367);

            this.lblEmergencyHelp.Name =
                "lblEmergencyHelp";

            this.lblEmergencyHelp.Size =
                new Size(230, 42);

            this.lblEmergencyHelp.TabIndex = 8;

            this.lblEmergencyHelp.Text =
                "Select only if there is an immediate risk\r\n" +
                "to life, property or essential services.";

            // =========================================================
            // PROGRESS CARD
            // =========================================================
            this.progressCard.BackColor =
                Color.FromArgb(245, 250, 250);

            this.progressCard.Location =
                new Point(25, 430);

            this.progressCard.Name =
                "progressCard";

            this.progressCard.Size =
                new Size(705, 68);

            this.progressCard.TabIndex = 9;

            // lblProgressTitle
            this.lblProgressTitle.AutoSize = true;

            this.lblProgressTitle.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblProgressTitle.ForeColor =
                Color.FromArgb(8, 42, 76);

            this.lblProgressTitle.Location =
                new Point(14, 8);

            this.lblProgressTitle.Name =
                "lblProgressTitle";

            this.lblProgressTitle.TabIndex = 0;

            this.lblProgressTitle.Text =
                "REPORT COMPLETION";

            // progressBarReport
            this.progressBarReport.Location =
                new Point(15, 29);

            this.progressBarReport.Name =
                "progressBarReport";

            this.progressBarReport.Size =
                new Size(430, 17);

            this.progressBarReport.Style =
                ProgressBarStyle.Continuous;

            this.progressBarReport.TabIndex = 1;

            // lblProgressMessage
            this.lblProgressMessage.ForeColor =
                Color.FromArgb(0, 145, 148);

            this.lblProgressMessage.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.lblProgressMessage.Location =
                new Point(462, 20);

            this.lblProgressMessage.Name =
                "lblProgressMessage";

            this.lblProgressMessage.Size =
                new Size(225, 38);

            this.lblProgressMessage.TabIndex = 2;

            this.lblProgressMessage.Text =
                "Complete the form to increase your progress";

            this.lblProgressMessage.TextAlign =
                ContentAlignment.MiddleLeft;

            this.progressCard.Controls.Add(this.lblProgressTitle);
            this.progressCard.Controls.Add(this.progressBarReport);
            this.progressCard.Controls.Add(this.lblProgressMessage);

            // lblReferencePreview
            this.lblReferencePreview.AutoSize = true;

            this.lblReferencePreview.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.lblReferencePreview.ForeColor =
                Color.FromArgb(8, 42, 76);

            this.lblReferencePreview.Location =
                new Point(26, 512);

            this.lblReferencePreview.Name =
                "lblReferencePreview";

            this.lblReferencePreview.TabIndex = 10;

            this.lblReferencePreview.Text =
                "Reference preview: generated on submission";

            this.formCard.Controls.Add(this.lblLocation);
            this.formCard.Controls.Add(this.txtLocation);
            this.formCard.Controls.Add(this.lblCategory);
            this.formCard.Controls.Add(this.cmbCategory);
            this.formCard.Controls.Add(this.lblDescription);
            this.formCard.Controls.Add(this.rtbDescription);
            this.formCard.Controls.Add(this.attachmentCard);
            this.formCard.Controls.Add(this.chkEmergency);
            this.formCard.Controls.Add(this.lblEmergencyHelp);
            this.formCard.Controls.Add(this.progressCard);
            this.formCard.Controls.Add(this.lblReferencePreview);

            // =========================================================
            // BACK BUTTON
            // =========================================================
            this.btnBack.BackColor = Color.White;
            this.btnBack.Cursor = Cursors.Hand;

            this.btnBack.FlatStyle = FlatStyle.Flat;

            this.btnBack.FlatAppearance.BorderColor =
                Color.FromArgb(215, 225, 232);

            this.btnBack.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.btnBack.ForeColor =
                Color.FromArgb(8, 42, 76);

            this.btnBack.Location =
                new Point(245, 688);

            this.btnBack.Name =
                "btnBack";

            this.btnBack.Size =
                new Size(120, 43);

            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;

            // =========================================================
            // SUBMIT BUTTON
            // =========================================================
            this.btnSubmit.BackColor =
                Color.FromArgb(0, 145, 148);

            this.btnSubmit.Cursor = Cursors.Hand;

            this.btnSubmit.FlatStyle =
                FlatStyle.Flat;

            this.btnSubmit.FlatAppearance.BorderSize = 0;

            this.btnSubmit.Font = new Font(
                "Segoe UI",
                11F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            this.btnSubmit.ForeColor = Color.White;

            this.btnSubmit.Location =
                new Point(805, 688);

            this.btnSubmit.Name =
                "btnSubmit";

            this.btnSubmit.Size =
                new Size(195, 43);

            this.btnSubmit.TabIndex = 4;

            this.btnSubmit.Text =
                "Submit Report  ➤";

            this.btnSubmit.UseVisualStyleBackColor = false;

            // =========================================================
            // REPORT ISSUE FORM
            // =========================================================
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(244, 248, 251);

            this.ClientSize =
                new Size(1035, 760);

            this.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            this.MinimumSize =
                new Size(1051, 799);

            this.Name =
                "ReportIssueForm";

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.Text =
                "Ubuntu Municipality | Report an Issue";

            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.formCard);
            this.Controls.Add(this.header);
            this.Controls.Add(this.sidebar);

            this.sidebar.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();

            this.attachmentCard.ResumeLayout(false);
            this.progressCard.ResumeLayout(false);
            this.progressCard.PerformLayout();

            this.formCard.ResumeLayout(false);
            this.formCard.PerformLayout();

            this.ResumeLayout(false);
        }
    }
}