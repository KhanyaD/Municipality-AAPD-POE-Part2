using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Events;

namespace MunicipalServicesApp
{
    public sealed class LocalEventsForm : Form
    {
        private readonly EventService service = EventService.Current;
        private readonly TextBox keyword = new TextBox { Width = 240 };
        private readonly ComboBox category = new ComboBox { Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly CheckBox useDates = new CheckBox { Text = "Filter dates", AutoSize = true };
        private readonly DateTimePicker from = new DateTimePicker { Width = 130, Format = DateTimePickerFormat.Short, Enabled = false };
        private readonly DateTimePicker to = new DateTimePicker { Width = 130, Format = DateTimePickerFormat.Short, Enabled = false };
        private readonly DataGridView eventsGrid = CreateGrid();
        private readonly DataGridView recommendationGrid = CreateGrid();
        private readonly ListBox history = new ListBox { Dock = DockStyle.Fill, HorizontalScrollbar = true, IntegralHeight = false };
        private readonly Label resultCount = new Label { AutoSize = true };
        private readonly Label recommendationMessage = new Label { AutoSize = true, MaximumSize = new Size(850, 0) };
        private readonly RichTextBox details = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, BackColor = Color.White, BorderStyle = BorderStyle.None };
        private readonly Label dateLabel = new Label { AutoSize = true, ForeColor = Color.White, Margin = new Padding(0, 10, 0, 0) };
        private readonly System.Windows.Forms.Timer dateTimer = new System.Windows.Forms.Timer { Interval = 60000 };

        public LocalEventsForm()
        {
            Text = "Ubuntu Municipality | Local Events and Announcements";
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(242, 248, 253);
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(900, 680);
            Size = new Size(1180, 850);
            AutoScaleMode = AutoScaleMode.Font;
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5, Padding = new Padding(16) };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            Controls.Add(layout);

            var header = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                BackColor = Color.FromArgb(8, 42, 76), Padding = new Padding(12), WrapContents = false };
            header.Controls.Add(new Label { Text = "LOCAL EVENTS & ANNOUNCEMENTS", AutoSize = true,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold), ForeColor = Color.White });
            header.Controls.Add(dateLabel);
            layout.Controls.Add(header, 0, 0);
            UpdateDate();
            dateTimer.Tick += (s, e) => UpdateDate();
            dateTimer.Start();

            var filters = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(0, 10, 0, 0) };
            filters.Controls.Add(Field("Keyword / location", keyword));
            filters.Controls.Add(Field("Category", category));
            filters.Controls.Add(Field("Date range", useDates));
            filters.Controls.Add(Field("From (inclusive)", from));
            filters.Controls.Add(Field("To (inclusive)", to));
            filters.Controls.Add(MakeButton("Search", (s, e) => RunSearch(true)));
            filters.Controls.Add(MakeButton("Reset filters", (s, e) => ResetFilters()));
            layout.Controls.Add(filters, 0, 1);
            category.Items.Add("All categories");
            foreach (string value in service.Categories) category.Items.Add(value);
            category.SelectedIndex = 0;
            from.Value = DateTime.Today;
            to.Value = DateTime.Today.AddDays(30);
            useDates.CheckedChanged += (s, e) => { from.Enabled = to.Enabled = useDates.Checked; };
            keyword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; RunSearch(true); } };

            var top = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32));
            top.Controls.Add(GridSection("Upcoming events and announcements", eventsGrid, resultCount), 0, 0);
            top.Controls.Add(new GroupBox { Text = "Selected item details", Dock = DockStyle.Fill, Padding = new Padding(12), Controls = { details } }, 1, 0);
            layout.Controls.Add(top, 0, 2);
            AddEventColumns(eventsGrid);
            eventsGrid.SelectionChanged += (s, e) => ShowSelected(eventsGrid);

            var bottom = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68));
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32));
            bottom.Controls.Add(GridSection("Recommended for you", recommendationGrid, recommendationMessage), 0, 0);
            AddEventColumns(recommendationGrid);
            recommendationGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Why recommended", DataPropertyName = "Reason", FillWeight = 170 });
            recommendationGrid.SelectionChanged += (s, e) => ShowSelected(recommendationGrid);
            var historyBox = new GroupBox { Text = "Recent searches — newest first", Dock = DockStyle.Fill, Padding = new Padding(10) };
            var historyLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            historyLayout.Controls.Add(history, 0, 0);
            var historyButtons = new FlowLayoutPanel { Dock = DockStyle.Fill };
            historyButtons.Controls.Add(MakeButton("Apply selected", (s, e) => ApplyHistory()));
            historyButtons.Controls.Add(MakeButton("Clear history", (s, e) => { service.ClearHistory(); RefreshPersonalisation(); }));
            historyLayout.Controls.Add(historyButtons, 0, 1);
            historyBox.Controls.Add(historyLayout);
            bottom.Controls.Add(historyBox, 1, 0);
            layout.Controls.Add(bottom, 0, 3);
            history.DoubleClick += (s, e) => ApplyHistory();
            var footer = new FlowLayoutPanel { Dock = DockStyle.Fill };
            footer.Controls.Add(MakeButton("Back to Main Menu", (s, e) => Close()));
            footer.Controls.Add(new Label { Text = "Fictional demonstration data • All data and searches are held in memory.", AutoSize = true, Margin = new Padding(12, 12, 0, 0), ForeColor = Color.DimGray });
            layout.Controls.Add(footer, 0, 4);
            RunSearch(false);
        }

        private void UpdateDate() { dateLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy"); }
        protected override void Dispose(bool disposing)
        {
            if (disposing) { dateTimer.Dispose(); }
            base.Dispose(disposing);
        }
        private static DataGridView CreateGrid()
        {
            return new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false,
                ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                RowHeadersVisible = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None, AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(242, 248, 253) } };
        }
        private static void AddEventColumns(DataGridView grid)
        {
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", FillWeight = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd MMM yyyy" } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title", FillWeight = 160 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category", FillWeight = 90 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type", DataPropertyName = "Type", FillWeight = 85 });
        }
        private static Control GridSection(string title, DataGridView grid, Label status)
        {
            var group = new GroupBox { Text = title, Dock = DockStyle.Fill, Padding = new Padding(10) };
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            panel.Controls.Add(status, 0, 0);
            panel.Controls.Add(grid, 0, 1);
            group.Controls.Add(panel);
            return group;
        }
        private static Control Field(string text, Control input)
        {
            var field = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, WrapContents = false,
                AutoSize = true, Margin = new Padding(0, 0, 10, 0) };
            field.Controls.Add(new Label { Text = text, AutoSize = true });
            field.Controls.Add(input);
            return field;
        }
        private static Button MakeButton(string text, EventHandler action)
        {
            var button = new Button { Text = text, AutoSize = true, Height = 34, FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(8, 42, 76), ForeColor = Color.White, Cursor = Cursors.Hand, Margin = new Padding(4, 8, 4, 4) };
            button.Click += action;
            return button;
        }
        private void RunSearch(bool remember)
        {
            var search = new EventSearch { Keyword = keyword.Text.Trim(),
                Category = category.SelectedIndex > 0 ? category.SelectedItem.ToString() : null,
                From = useDates.Checked ? (DateTime?)from.Value.Date : null,
                To = useDates.Checked ? (DateTime?)to.Value.Date : null };
            try
            {
                var found = service.Search(search, remember);
                details.Clear();
                eventsGrid.DataSource = found;
                resultCount.Text = found.Count == 0 ? "No matches. Try another category, keyword or date range." : found.Count + " upcoming item(s)";
                RefreshPersonalisation();
                ShowSelected(eventsGrid);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid date range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RefreshPersonalisation()
        {
            history.DataSource = null;
            history.DataSource = service.History;
            var recommended = service.Recommend(5);
            recommendationGrid.DataSource = recommended.Select(x => new { x.Event.Id, x.Event.Date,
                x.Event.Title, x.Event.Category, x.Event.Type, x.Reason }).ToList();
            recommendationMessage.Text = recommended.Count > 0 ? "Based on your searches. Select a row to view details." :
                service.History.Count == 0 ? "Search a category, keyword or date range to get personalised suggestions." :
                "No related upcoming items yet. Try another search.";
        }
        private void ResetFilters()
        {
            keyword.Clear(); category.SelectedIndex = 0; useDates.Checked = false;
            from.Value = DateTime.Today; to.Value = DateTime.Today.AddDays(30);
            RunSearch(false);
        }
        private void ApplyHistory()
        {
            var search = history.SelectedItem as EventSearch;
            if (search == null) return;
            keyword.Text = search.Keyword;
            category.SelectedIndex = string.IsNullOrEmpty(search.Category) ? 0 : category.Items.IndexOf(search.Category);
            useDates.Checked = search.From.HasValue;
            if (search.From.HasValue) { from.Value = search.From.Value; to.Value = search.To.Value; }
            RunSearch(false); // Replaying history does not count the same preference twice.
        }
        private void ShowSelected(DataGridView grid)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Cells["Id"].Value == null) return;
            var item = service.GetById(Convert.ToInt32(grid.CurrentRow.Cells["Id"].Value));
            details.Text = item.Title + "\n\n" + item.Date.ToString("dddd, dd MMMM yyyy") +
                "\n" + item.Type + " • " + item.Category + "\n" + item.Location + "\n\n" + item.Description;
        }
    }
}
