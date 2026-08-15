namespace Nyanko.Forms
{
    partial class SearchWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanelHeader = new Sunny.UI.UIPanel();
            this.uiSymbolButtonMinimise = new Sunny.UI.UISymbolButton();
            this.uiSymbolButtonMaximise = new Sunny.UI.UISymbolButton();
            this.uiSymbolButtonClose = new Sunny.UI.UISymbolButton();
            this.uiPanelContent = new Sunny.UI.UIPanel();
            this.uiPanelResult = new Sunny.UI.UIPanel();
            this.uiDataGridViewResult = new Sunny.UI.UIDataGridView();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanelSearch = new Sunny.UI.UIPanel();
            this.uiTextBoxSearch = new Sunny.UI.UITextBox();
            this.uiButtonSearch = new Sunny.UI.UIButton();
            this.uiLabelSearch = new Sunny.UI.UILabel();
            this.uiPanelHeader.SuspendLayout();
            this.uiPanelContent.SuspendLayout();
            this.uiPanelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewResult)).BeginInit();
            this.uiPanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelHeader
            // 
            this.uiPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonMinimise);
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonMaximise);
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonClose);
            this.uiPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.uiPanelHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiPanelHeader.ForeColor = System.Drawing.Color.Black;
            this.uiPanelHeader.Location = new System.Drawing.Point(4, 0);
            this.uiPanelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelHeader.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelHeader.Name = "uiPanelHeader";
            this.uiPanelHeader.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelHeader.Size = new System.Drawing.Size(959, 40);
            this.uiPanelHeader.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanelHeader.TabIndex = 10;
            this.uiPanelHeader.Text = "Search";
            this.uiPanelHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButtonMinimise
            // 
            this.uiSymbolButtonMinimise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButtonMinimise.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButtonMinimise.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonMinimise.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonMinimise.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiSymbolButtonMinimise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiSymbolButtonMinimise.ForeHoverColor = System.Drawing.Color.Blue;
            this.uiSymbolButtonMinimise.Location = new System.Drawing.Point(839, 0);
            this.uiSymbolButtonMinimise.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonMinimise.Name = "uiSymbolButtonMinimise";
            this.uiSymbolButtonMinimise.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonMinimise.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonMinimise.Symbol = 0;
            this.uiSymbolButtonMinimise.TabIndex = 5;
            this.uiSymbolButtonMinimise.Text = "─";
            this.uiSymbolButtonMinimise.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButtonMinimise.Click += new System.EventHandler(this.UiSymbolButtonMinimise_Click);
            // 
            // uiSymbolButtonMaximise
            // 
            this.uiSymbolButtonMaximise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButtonMaximise.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButtonMaximise.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonMaximise.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonMaximise.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiSymbolButtonMaximise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiSymbolButtonMaximise.ForeHoverColor = System.Drawing.Color.Blue;
            this.uiSymbolButtonMaximise.Location = new System.Drawing.Point(879, 0);
            this.uiSymbolButtonMaximise.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonMaximise.Name = "uiSymbolButtonMaximise";
            this.uiSymbolButtonMaximise.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonMaximise.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonMaximise.Symbol = 0;
            this.uiSymbolButtonMaximise.TabIndex = 4;
            this.uiSymbolButtonMaximise.Text = "☐";
            this.uiSymbolButtonMaximise.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButtonMaximise.Click += new System.EventHandler(this.UiSymbolButtonMaximise_Click);
            // 
            // uiSymbolButtonClose
            // 
            this.uiSymbolButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButtonClose.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiSymbolButtonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiSymbolButtonClose.ForeHoverColor = System.Drawing.Color.Red;
            this.uiSymbolButtonClose.Location = new System.Drawing.Point(919, 0);
            this.uiSymbolButtonClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonClose.Name = "uiSymbolButtonClose";
            this.uiSymbolButtonClose.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonClose.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonClose.Symbol = 0;
            this.uiSymbolButtonClose.TabIndex = 1;
            this.uiSymbolButtonClose.Text = "X";
            this.uiSymbolButtonClose.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButtonClose.Click += new System.EventHandler(this.UiSymbolButtonClose_Click);
            // 
            // uiPanelContent
            // 
            this.uiPanelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelContent.Controls.Add(this.uiPanelResult);
            this.uiPanelContent.Controls.Add(this.uiPanelSearch);
            this.uiPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelContent.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelContent.Location = new System.Drawing.Point(4, 40);
            this.uiPanelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelContent.Name = "uiPanelContent";
            this.uiPanelContent.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelContent.Size = new System.Drawing.Size(959, 643);
            this.uiPanelContent.TabIndex = 13;
            this.uiPanelContent.Text = null;
            this.uiPanelContent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelResult
            // 
            this.uiPanelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelResult.Controls.Add(this.uiDataGridViewResult);
            this.uiPanelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelResult.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelResult.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelResult.Location = new System.Drawing.Point(0, 40);
            this.uiPanelResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelResult.Name = "uiPanelResult";
            this.uiPanelResult.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelResult.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelResult.Size = new System.Drawing.Size(959, 603);
            this.uiPanelResult.TabIndex = 17;
            this.uiPanelResult.Text = null;
            this.uiPanelResult.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiDataGridViewResult
            // 
            this.uiDataGridViewResult.AllowUserToAddRows = false;
            this.uiDataGridViewResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.uiDataGridViewResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridViewResult.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridViewResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridViewResult.ColumnHeadersHeight = 32;
            this.uiDataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnText,
            this.Node,
            this.ColumnType});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridViewResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridViewResult.EnableHeadersVisualStyles = false;
            this.uiDataGridViewResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDataGridViewResult.Location = new System.Drawing.Point(16, 8);
            this.uiDataGridViewResult.MultiSelect = false;
            this.uiDataGridViewResult.Name = "uiDataGridViewResult";
            this.uiDataGridViewResult.ReadOnly = true;
            this.uiDataGridViewResult.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiDataGridViewResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uiDataGridViewResult.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uiDataGridViewResult.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.uiDataGridViewResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiDataGridViewResult.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.uiDataGridViewResult.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uiDataGridViewResult.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.uiDataGridViewResult.ScrollBarColor = System.Drawing.Color.Black;
            this.uiDataGridViewResult.ScrollBarRectColor = System.Drawing.Color.Black;
            this.uiDataGridViewResult.ScrollBarStyleInherited = false;
            this.uiDataGridViewResult.SelectedIndex = -1;
            this.uiDataGridViewResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridViewResult.Size = new System.Drawing.Size(939, 587);
            this.uiDataGridViewResult.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uiDataGridViewResult.StripeOddColor = System.Drawing.SystemColors.ControlLight;
            this.uiDataGridViewResult.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridViewResult.TabIndex = 0;
            this.uiDataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDataGridViewResult.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UiDataGridViewResult_CellMouseDoubleClick);
            // 
            // ColumnText
            // 
            this.ColumnText.HeaderText = "Text";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            this.ColumnText.Width = 500;
            // 
            // Node
            // 
            this.Node.HeaderText = "Node";
            this.Node.Name = "Node";
            this.Node.ReadOnly = true;
            this.Node.Width = 250;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // uiPanelSearch
            // 
            this.uiPanelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelSearch.Controls.Add(this.uiTextBoxSearch);
            this.uiPanelSearch.Controls.Add(this.uiButtonSearch);
            this.uiPanelSearch.Controls.Add(this.uiLabelSearch);
            this.uiPanelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelSearch.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelSearch.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelSearch.Location = new System.Drawing.Point(0, 0);
            this.uiPanelSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelSearch.Name = "uiPanelSearch";
            this.uiPanelSearch.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelSearch.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelSearch.Size = new System.Drawing.Size(959, 40);
            this.uiPanelSearch.TabIndex = 13;
            this.uiPanelSearch.Text = null;
            this.uiPanelSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBoxSearch
            // 
            this.uiTextBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxSearch.Location = new System.Drawing.Point(80, 7);
            this.uiTextBoxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxSearch.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxSearch.Name = "uiTextBoxSearch";
            this.uiTextBoxSearch.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxSearch.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiTextBoxSearch.ShowText = false;
            this.uiTextBoxSearch.Size = new System.Drawing.Size(694, 26);
            this.uiTextBoxSearch.TabIndex = 1;
            this.uiTextBoxSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxSearch.Watermark = "";
            this.uiTextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // uiButtonSearch
            // 
            this.uiButtonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiButtonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonSearch.FillColor = System.Drawing.Color.White;
            this.uiButtonSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiButtonSearch.ForeColor = System.Drawing.Color.Black;
            this.uiButtonSearch.Location = new System.Drawing.Point(781, 7);
            this.uiButtonSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonSearch.Name = "uiButtonSearch";
            this.uiButtonSearch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.uiButtonSearch.Size = new System.Drawing.Size(174, 26);
            this.uiButtonSearch.TabIndex = 0;
            this.uiButtonSearch.Text = "Search";
            this.uiButtonSearch.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButtonSearch.Click += new System.EventHandler(this.uiButtonSearch_Click);
            this.uiButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // uiLabelSearch
            // 
            this.uiLabelSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelSearch.Location = new System.Drawing.Point(12, 11);
            this.uiLabelSearch.Name = "uiLabelSearch";
            this.uiLabelSearch.Size = new System.Drawing.Size(61, 23);
            this.uiLabelSearch.TabIndex = 0;
            this.uiLabelSearch.Text = "Search";
            // 
            // SearchWindow
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(967, 687);
            this.Controls.Add(this.uiPanelContent);
            this.Controls.Add(this.uiPanelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "SearchWindow";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ShowTitle = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "SearchWindow";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.uiPanelHeader.ResumeLayout(false);
            this.uiPanelContent.ResumeLayout(false);
            this.uiPanelResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewResult)).EndInit();
            this.uiPanelSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanelHeader;
        private Sunny.UI.UISymbolButton uiSymbolButtonClose;
        private Sunny.UI.UIPanel uiPanelContent;
        private Sunny.UI.UIPanel uiPanelSearch;
        private Sunny.UI.UITextBox uiTextBoxSearch;
        private Sunny.UI.UILabel uiLabelSearch;
        private Sunny.UI.UIButton uiButtonSearch;
        private Sunny.UI.UIPanel uiPanelResult;
        private Sunny.UI.UIDataGridView uiDataGridViewResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private Sunny.UI.UISymbolButton uiSymbolButtonMinimise;
        private Sunny.UI.UISymbolButton uiSymbolButtonMaximise;
    }
}