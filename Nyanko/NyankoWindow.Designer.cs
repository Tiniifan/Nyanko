
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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            this.textTypeContextMenuStrip.SuspendLayout();
            this.textItemContextMenuStrip.SuspendLayout();
            this.textKeyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.Enabled = false;
            this.textTextBox.Location = new System.Drawing.Point(368, 36);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(248, 350);
            this.textTextBox.TabIndex = 2;
            this.textTextBox.TextChanged += new System.EventHandler(this.TextTextBox_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textTreeView
            // 
            this.textTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTreeView.Location = new System.Drawing.Point(12, 36);
            this.textTreeView.Name = "textTreeView";
            this.textTreeView.Size = new System.Drawing.Size(350, 350);
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
            this.renameKeyToolStripMenuItem,
            this.removeKeyToolStripMenuItem});
            this.textKeyContextMenuStrip.Name = "textKeyContextMenuStrip";
            this.textKeyContextMenuStrip.Size = new System.Drawing.Size(140, 70);
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
            // NyankoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 396);
            this.Controls.Add(this.textTreeView);
            this.Controls.Add(this.textTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NyankoWindow";
            this.Text = "Nyanko";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.textTypeContextMenuStrip.ResumeLayout(false);
            this.textItemContextMenuStrip.ResumeLayout(false);
            this.textKeyContextMenuStrip.ResumeLayout(false);
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
    }
}

