namespace Nyanko.Forms
{
    partial class NyankoWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NyankoWindow));
            this.menuStripOption = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchConvertToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cfgBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uiPanelHeader = new Sunny.UI.UIPanel();
            this.uiSymbolButtonMinimise = new Sunny.UI.UISymbolButton();
            this.uiSymbolButtonMaximise = new Sunny.UI.UISymbolButton();
            this.uiSymbolButtonClose = new Sunny.UI.UISymbolButton();
            this.uiPanelContent = new Sunny.UI.UIPanel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPageNouns = new System.Windows.Forms.TabPage();
            this.string5UserControlNoun = new Nyanko.UserControls.String5UserControl();
            this.tabPageTexts = new System.Windows.Forms.TabPage();
            this.string5UserControlText = new Nyanko.UserControls.String5UserControl();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.string5UserControlDebug = new Nyanko.UserControls.String5UserControl();
            this.cRC32FinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripOption.SuspendLayout();
            this.uiPanelHeader.SuspendLayout();
            this.uiPanelContent.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPageNouns.SuspendLayout();
            this.tabPageTexts.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripOption
            // 
            this.menuStripOption.BackColor = System.Drawing.Color.Transparent;
            this.menuStripOption.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStripOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.batchConvertToToolStripMenuItem});
            this.menuStripOption.Location = new System.Drawing.Point(0, 8);
            this.menuStripOption.Name = "menuStripOption";
            this.menuStripOption.Size = new System.Drawing.Size(347, 27);
            this.menuStripOption.TabIndex = 0;
            this.menuStripOption.Text = "menuStripOption";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.cRC32FinderToolStripMenuItem,
            this.expandAllToolStripMenuItem,
            this.collapseAllToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.collapseAllToolStripMenuItem.Text = "Collapse All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
            // 
            // batchConvertToToolStripMenuItem
            // 
            this.batchConvertToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtToolStripMenuItem,
            this.xmlToolStripMenuItem,
            this.cfgBinToolStripMenuItem});
            this.batchConvertToToolStripMenuItem.Name = "batchConvertToToolStripMenuItem";
            this.batchConvertToToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.batchConvertToToolStripMenuItem.Text = "Batch Convert To";
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.txtToolStripMenuItem.Text = "Txt";
            this.txtToolStripMenuItem.Click += new System.EventHandler(this.TxtToolStripMenuItem_Click);
            // 
            // xmlToolStripMenuItem
            // 
            this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
            this.xmlToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.xmlToolStripMenuItem.Text = "Xml";
            this.xmlToolStripMenuItem.Click += new System.EventHandler(this.XmlToolStripMenuItem_Click);
            // 
            // cfgBinToolStripMenuItem
            // 
            this.cfgBinToolStripMenuItem.Name = "cfgBinToolStripMenuItem";
            this.cfgBinToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.cfgBinToolStripMenuItem.Text = "Cfg Bin";
            this.cfgBinToolStripMenuItem.Click += new System.EventHandler(this.CfgBinToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // uiPanelHeader
            // 
            this.uiPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonMinimise);
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonMaximise);
            this.uiPanelHeader.Controls.Add(this.menuStripOption);
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
            this.uiPanelHeader.Size = new System.Drawing.Size(892, 40);
            this.uiPanelHeader.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanelHeader.TabIndex = 9;
            this.uiPanelHeader.Text = "Nyanko";
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
            this.uiSymbolButtonMinimise.Location = new System.Drawing.Point(772, 0);
            this.uiSymbolButtonMinimise.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonMinimise.Name = "uiSymbolButtonMinimise";
            this.uiSymbolButtonMinimise.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMinimise.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonMinimise.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonMinimise.Symbol = 0;
            this.uiSymbolButtonMinimise.TabIndex = 3;
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
            this.uiSymbolButtonMaximise.Location = new System.Drawing.Point(812, 0);
            this.uiSymbolButtonMaximise.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonMaximise.Name = "uiSymbolButtonMaximise";
            this.uiSymbolButtonMaximise.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonMaximise.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonMaximise.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonMaximise.Symbol = 0;
            this.uiSymbolButtonMaximise.TabIndex = 2;
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
            this.uiSymbolButtonClose.Location = new System.Drawing.Point(852, 0);
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
            this.uiPanelContent.Controls.Add(this.uiTabControl1);
            this.uiPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelContent.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelContent.Location = new System.Drawing.Point(4, 40);
            this.uiPanelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelContent.Name = "uiPanelContent";
            this.uiPanelContent.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.Size = new System.Drawing.Size(892, 556);
            this.uiPanelContent.TabIndex = 10;
            this.uiPanelContent.Text = null;
            this.uiPanelContent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPageNouns);
            this.uiTabControl1.Controls.Add(this.tabPageTexts);
            this.uiTabControl1.Controls.Add(this.tabPageDebug);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(892, 556);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TabSelectedHighColor = System.Drawing.Color.Black;
            this.uiTabControl1.TabUnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.SystemColors.ControlDark;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // tabPageNouns
            // 
            this.tabPageNouns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPageNouns.Controls.Add(this.string5UserControlNoun);
            this.tabPageNouns.Location = new System.Drawing.Point(0, 40);
            this.tabPageNouns.Name = "tabPageNouns";
            this.tabPageNouns.Size = new System.Drawing.Size(892, 516);
            this.tabPageNouns.TabIndex = 1;
            this.tabPageNouns.Text = "Nouns";
            // 
            // string5UserControlNoun
            // 
            this.string5UserControlNoun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.string5UserControlNoun.Enabled = false;
            this.string5UserControlNoun.Location = new System.Drawing.Point(0, 0);
            this.string5UserControlNoun.Margin = new System.Windows.Forms.Padding(5);
            this.string5UserControlNoun.Name = "string5UserControlNoun";
            this.string5UserControlNoun.Size = new System.Drawing.Size(892, 516);
            this.string5UserControlNoun.TabIndex = 9;
            // 
            // tabPageTexts
            // 
            this.tabPageTexts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPageTexts.Controls.Add(this.string5UserControlText);
            this.tabPageTexts.Location = new System.Drawing.Point(0, 40);
            this.tabPageTexts.Name = "tabPageTexts";
            this.tabPageTexts.Size = new System.Drawing.Size(892, 516);
            this.tabPageTexts.TabIndex = 0;
            this.tabPageTexts.Text = "Texts";
            // 
            // string5UserControlText
            // 
            this.string5UserControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.string5UserControlText.Enabled = false;
            this.string5UserControlText.Location = new System.Drawing.Point(0, 0);
            this.string5UserControlText.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.string5UserControlText.Name = "string5UserControlText";
            this.string5UserControlText.Size = new System.Drawing.Size(892, 516);
            this.string5UserControlText.TabIndex = 10;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPageDebug.Controls.Add(this.string5UserControlDebug);
            this.tabPageDebug.Location = new System.Drawing.Point(0, 40);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Size = new System.Drawing.Size(892, 516);
            this.tabPageDebug.TabIndex = 2;
            this.tabPageDebug.Text = "Debug Texts";
            // 
            // string5UserControlDebug
            // 
            this.string5UserControlDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.string5UserControlDebug.Enabled = false;
            this.string5UserControlDebug.Location = new System.Drawing.Point(0, 0);
            this.string5UserControlDebug.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.string5UserControlDebug.Name = "string5UserControlDebug";
            this.string5UserControlDebug.Size = new System.Drawing.Size(892, 516);
            this.string5UserControlDebug.TabIndex = 10;
            // 
            // cRC32FinderToolStripMenuItem
            // 
            this.cRC32FinderToolStripMenuItem.Name = "cRC32FinderToolStripMenuItem";
            this.cRC32FinderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.cRC32FinderToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.cRC32FinderToolStripMenuItem.Text = "CRC32 Finder";
            this.cRC32FinderToolStripMenuItem.Click += new System.EventHandler(this.CRC32FinderToolStripMenuItem_Click);
            // 
            // NyankoWindow
            // 
            this.AllowDrop = true;
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.uiPanelContent);
            this.Controls.Add(this.uiPanelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripOption;
            this.Name = "NyankoWindow";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Nyanko";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 884, 555);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NyankoWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NyankoWindow_DragEnter);
            this.menuStripOption.ResumeLayout(false);
            this.menuStripOption.PerformLayout();
            this.uiPanelHeader.ResumeLayout(false);
            this.uiPanelHeader.PerformLayout();
            this.uiPanelContent.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPageNouns.ResumeLayout(false);
            this.tabPageTexts.ResumeLayout(false);
            this.tabPageDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private Sunny.UI.UIPanel uiPanelHeader;
        private Sunny.UI.UISymbolButton uiSymbolButtonMinimise;
        private Sunny.UI.UISymbolButton uiSymbolButtonMaximise;
        private Sunny.UI.UISymbolButton uiSymbolButtonClose;
        private Sunny.UI.UIPanel uiPanelContent;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPageTexts;
        private System.Windows.Forms.TabPage tabPageNouns;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.ToolStripMenuItem batchConvertToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cfgBinToolStripMenuItem;
        private UserControls.String5UserControl string5UserControlNoun;
        private UserControls.String5UserControl string5UserControlText;
        private UserControls.String5UserControl string5UserControlDebug;
        private System.Windows.Forms.ToolStripMenuItem cRC32FinderToolStripMenuItem;
    }
}
