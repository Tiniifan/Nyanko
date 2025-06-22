
namespace Nyanko
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NyankoWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textTreeView = new System.Windows.Forms.TreeView();
            this.textTypeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textKeyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachFaceGroupBox = new System.Windows.Forms.GroupBox();
            this.faceComboBox = new System.Windows.Forms.ComboBox();
            this.faceLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.varianceKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.varianceKeyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.varianceKeyLabel = new System.Windows.Forms.Label();
            this.dialogBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDialogboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDialogboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.textTypeContextMenuStrip.SuspendLayout();
            this.textItemContextMenuStrip.SuspendLayout();
            this.textKeyContextMenuStrip.SuspendLayout();
            this.attachFaceGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.varianceKeyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.varianceKeyNumericUpDown)).BeginInit();
            this.dialogBoxContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.batchConvertToToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.expandAllToolStripMenuItem,
            this.collapseAllToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
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
            this.batchConvertToToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.batchConvertToToolStripMenuItem.Text = "Batch Convert To";
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.txtToolStripMenuItem.Text = "Txt";
            this.txtToolStripMenuItem.Click += new System.EventHandler(this.TxtToolStripMenuItem_Click);
            // 
            // xmlToolStripMenuItem
            // 
            this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
            this.xmlToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.xmlToolStripMenuItem.Text = "Xml";
            this.xmlToolStripMenuItem.Click += new System.EventHandler(this.XmlToolStripMenuItem_Click);
            // 
            // cfgBinToolStripMenuItem
            // 
            this.cfgBinToolStripMenuItem.Name = "cfgBinToolStripMenuItem";
            this.cfgBinToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.cfgBinToolStripMenuItem.Text = "Cfg Bin";
            this.cfgBinToolStripMenuItem.Click += new System.EventHandler(this.CfgBinToolStripMenuItem_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTextBox.Enabled = false;
            this.textTextBox.Location = new System.Drawing.Point(6, 201);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(334, 303);
            this.textTextBox.TabIndex = 2;
            this.textTextBox.TextChanged += new System.EventHandler(this.TextTextBox_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textTreeView
            // 
            this.textTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTreeView.HideSelection = false;
            this.textTreeView.Location = new System.Drawing.Point(3, 3);
            this.textTreeView.Name = "textTreeView";
            this.textTreeView.Size = new System.Drawing.Size(502, 510);
            this.textTreeView.TabIndex = 6;
            this.textTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TextTreeView_AfterSelect);
            this.textTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TextTreeView_NodeMouseClick);
            // 
            // textTypeContextMenuStrip
            // 
            this.textTypeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeyToolStripMenuItem});
            this.textTypeContextMenuStrip.Name = "contextMenuStrip1";
            this.textTypeContextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // addKeyToolStripMenuItem
            // 
            this.addKeyToolStripMenuItem.Name = "addKeyToolStripMenuItem";
            this.addKeyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.addKeyToolStripMenuItem.Text = "Add Key";
            this.addKeyToolStripMenuItem.Click += new System.EventHandler(this.AddKeyToolStripMenuItem_Click);
            // 
            // textItemContextMenuStrip
            // 
            this.textItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeTextToolStripMenuItem});
            this.textItemContextMenuStrip.Name = "textItemContextMenuStrip";
            this.textItemContextMenuStrip.Size = new System.Drawing.Size(142, 26);
            // 
            // removeTextToolStripMenuItem
            // 
            this.removeTextToolStripMenuItem.Name = "removeTextToolStripMenuItem";
            this.removeTextToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.removeTextToolStripMenuItem.Text = "Remove Text";
            this.removeTextToolStripMenuItem.Click += new System.EventHandler(this.RemoveTextToolStripMenuItem_Click);
            // 
            // textKeyContextMenuStrip
            // 
            this.textKeyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextToolStripMenuItem,
            this.addDialogboxToolStripMenuItem,
            this.renameKeyToolStripMenuItem,
            this.removeKeyToolStripMenuItem});
            this.textKeyContextMenuStrip.Name = "textKeyContextMenuStrip";
            this.textKeyContextMenuStrip.Size = new System.Drawing.Size(153, 92);
            this.textKeyContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TextKeyContextMenuStrip_Opening);
            // 
            // addTextToolStripMenuItem
            // 
            this.addTextToolStripMenuItem.Name = "addTextToolStripMenuItem";
            this.addTextToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.addTextToolStripMenuItem.Text = "Add Text";
            this.addTextToolStripMenuItem.Click += new System.EventHandler(this.AddTextToolStripMenuItem_Click);
            // 
            // renameKeyToolStripMenuItem
            // 
            this.renameKeyToolStripMenuItem.Name = "renameKeyToolStripMenuItem";
            this.renameKeyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.renameKeyToolStripMenuItem.Text = "Rename Key";
            this.renameKeyToolStripMenuItem.Click += new System.EventHandler(this.RenameKeyToolStripMenuItem_Click);
            // 
            // removeKeyToolStripMenuItem
            // 
            this.removeKeyToolStripMenuItem.Name = "removeKeyToolStripMenuItem";
            this.removeKeyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.removeKeyToolStripMenuItem.Text = "Remove Key";
            this.removeKeyToolStripMenuItem.Click += new System.EventHandler(this.RemoveKeyToolStripMenuItem_Click);
            // 
            // attachFaceGroupBox
            // 
            this.attachFaceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachFaceGroupBox.Controls.Add(this.faceComboBox);
            this.attachFaceGroupBox.Controls.Add(this.faceLabel);
            this.attachFaceGroupBox.Enabled = false;
            this.attachFaceGroupBox.Location = new System.Drawing.Point(6, 11);
            this.attachFaceGroupBox.Name = "attachFaceGroupBox";
            this.attachFaceGroupBox.Size = new System.Drawing.Size(334, 89);
            this.attachFaceGroupBox.TabIndex = 7;
            this.attachFaceGroupBox.TabStop = false;
            this.attachFaceGroupBox.Text = "Attach character";
            // 
            // faceComboBox
            // 
            this.faceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.faceComboBox.Enabled = false;
            this.faceComboBox.FormattingEnabled = true;
            this.faceComboBox.Items.AddRange(new object[] {
            "None"});
            this.faceComboBox.Location = new System.Drawing.Point(75, 35);
            this.faceComboBox.Name = "faceComboBox";
            this.faceComboBox.Size = new System.Drawing.Size(253, 21);
            this.faceComboBox.TabIndex = 1;
            this.faceComboBox.SelectedIndexChanged += new System.EventHandler(this.FaceComboBox_SelectedIndexChanged);
            // 
            // faceLabel
            // 
            this.faceLabel.AutoSize = true;
            this.faceLabel.Location = new System.Drawing.Point(16, 38);
            this.faceLabel.Name = "faceLabel";
            this.faceLabel.Size = new System.Drawing.Size(53, 13);
            this.faceLabel.TabIndex = 0;
            this.faceLabel.Text = "Character";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.15032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.84967F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textTreeView, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 516);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.varianceKeyGroupBox);
            this.groupBox1.Controls.Add(this.attachFaceGroupBox);
            this.groupBox1.Controls.Add(this.textTextBox);
            this.groupBox1.Location = new System.Drawing.Point(511, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 510);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // varianceKeyGroupBox
            // 
            this.varianceKeyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.varianceKeyGroupBox.Controls.Add(this.varianceKeyNumericUpDown);
            this.varianceKeyGroupBox.Controls.Add(this.varianceKeyLabel);
            this.varianceKeyGroupBox.Enabled = false;
            this.varianceKeyGroupBox.Location = new System.Drawing.Point(6, 106);
            this.varianceKeyGroupBox.Name = "varianceKeyGroupBox";
            this.varianceKeyGroupBox.Size = new System.Drawing.Size(334, 89);
            this.varianceKeyGroupBox.TabIndex = 8;
            this.varianceKeyGroupBox.TabStop = false;
            this.varianceKeyGroupBox.Text = "Variance key";
            // 
            // varianceKeyNumericUpDown
            // 
            this.varianceKeyNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.varianceKeyNumericUpDown.Enabled = false;
            this.varianceKeyNumericUpDown.Location = new System.Drawing.Point(75, 35);
            this.varianceKeyNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.varianceKeyNumericUpDown.Name = "varianceKeyNumericUpDown";
            this.varianceKeyNumericUpDown.Size = new System.Drawing.Size(253, 20);
            this.varianceKeyNumericUpDown.TabIndex = 2;
            this.varianceKeyNumericUpDown.ValueChanged += new System.EventHandler(this.VarianceKeyNumericUpDown_ValueChanged);
            // 
            // varianceKeyLabel
            // 
            this.varianceKeyLabel.AutoSize = true;
            this.varianceKeyLabel.Location = new System.Drawing.Point(16, 38);
            this.varianceKeyLabel.Name = "varianceKeyLabel";
            this.varianceKeyLabel.Size = new System.Drawing.Size(44, 13);
            this.varianceKeyLabel.TabIndex = 1;
            this.varianceKeyLabel.Text = "Number";
            // 
            // dialogBoxContextMenuStrip
            // 
            this.dialogBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextToolStripMenuItem1,
            this.deleteDialogboxToolStripMenuItem});
            this.dialogBoxContextMenuStrip.Name = "dialogBoxContextMenuStrip";
            this.dialogBoxContextMenuStrip.Size = new System.Drawing.Size(181, 70);
            // 
            // addDialogboxToolStripMenuItem
            // 
            this.addDialogboxToolStripMenuItem.Name = "addDialogboxToolStripMenuItem";
            this.addDialogboxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addDialogboxToolStripMenuItem.Text = "Add Dialogbox";
            this.addDialogboxToolStripMenuItem.Click += new System.EventHandler(this.AddDialogboxToolStripMenuItem_Click);
            // 
            // addTextToolStripMenuItem1
            // 
            this.addTextToolStripMenuItem1.Name = "addTextToolStripMenuItem1";
            this.addTextToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addTextToolStripMenuItem1.Text = "Add text";
            this.addTextToolStripMenuItem1.Click += new System.EventHandler(this.AddTextToolStripMenuItem1_Click);
            // 
            // deleteDialogboxToolStripMenuItem
            // 
            this.deleteDialogboxToolStripMenuItem.Name = "deleteDialogboxToolStripMenuItem";
            this.deleteDialogboxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteDialogboxToolStripMenuItem.Text = "Delete dialogbox";
            this.deleteDialogboxToolStripMenuItem.Click += new System.EventHandler(this.DeleteDialogboxToolStripMenuItem_Click);
            // 
            // NyankoWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 555);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NyankoWindow";
            this.Text = "Nyanko";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NyankoWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NyankoWindow_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.textTypeContextMenuStrip.ResumeLayout(false);
            this.textItemContextMenuStrip.ResumeLayout(false);
            this.textKeyContextMenuStrip.ResumeLayout(false);
            this.attachFaceGroupBox.ResumeLayout(false);
            this.attachFaceGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.varianceKeyGroupBox.ResumeLayout(false);
            this.varianceKeyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.varianceKeyNumericUpDown)).EndInit();
            this.dialogBoxContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView textTreeView;
        private System.Windows.Forms.ContextMenuStrip textTypeContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip textItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeTextToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip textKeyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.GroupBox attachFaceGroupBox;
        private System.Windows.Forms.ComboBox faceComboBox;
        private System.Windows.Forms.Label faceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem batchConvertToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cfgBinToolStripMenuItem;
        private System.Windows.Forms.GroupBox varianceKeyGroupBox;
        private System.Windows.Forms.Label varianceKeyLabel;
        private System.Windows.Forms.NumericUpDown varianceKeyNumericUpDown;
        private System.Windows.Forms.ContextMenuStrip dialogBoxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addDialogboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTextToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteDialogboxToolStripMenuItem;
    }
}

