using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Sunny.UI;
using Nyanko.UserControls;

namespace Nyanko.Forms
{
    public partial class SearchWindow : UIForm
    {
        private NyankoWindow _mainWindow;

        public SearchWindow()
        {
            InitializeComponent();

            if (this.uiPanelHeader != null)
            {
                this.uiPanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UiPanelHeader_MouseDown);
            }
        }

        public SearchWindow(NyankoWindow mainWindow) : this()
        {
            _mainWindow = mainWindow;
        }

        #region Public Methods
        #endregion

        #region Private Methods

        // Win32 APIs used to enable dragging of the borderless form via the custom title bar panel
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private void ConfigureDataGridView()
        {
            if (uiDataGridViewResult != null)
            {
                // Enable custom style mode to stop Sunny.UI from overriding colors
                uiDataGridViewResult.Style = Sunny.UI.UIStyle.Custom;
                uiDataGridViewResult.StyleCustomMode = true;

                // Reapply the gray designer colors
                uiDataGridViewResult.BackgroundColor = System.Drawing.Color.White;
                uiDataGridViewResult.GridColor = System.Drawing.SystemColors.ControlDark;
                uiDataGridViewResult.RectColor = System.Drawing.SystemColors.ControlDark;

                // Header styles
                uiDataGridViewResult.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                uiDataGridViewResult.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                uiDataGridViewResult.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
                uiDataGridViewResult.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                // Alternate & regular row styles
                uiDataGridViewResult.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                uiDataGridViewResult.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                uiDataGridViewResult.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
                uiDataGridViewResult.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                uiDataGridViewResult.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                uiDataGridViewResult.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                uiDataGridViewResult.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
                uiDataGridViewResult.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                // Zebra striping colors
                uiDataGridViewResult.StripeEvenColor = System.Drawing.Color.White;
                uiDataGridViewResult.StripeOddColor = System.Drawing.SystemColors.ControlLight;

                // Row headers
                uiDataGridViewResult.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                uiDataGridViewResult.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                uiDataGridViewResult.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
                uiDataGridViewResult.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

                // Scrollbar colors
                uiDataGridViewResult.ScrollBarColor = System.Drawing.Color.Gray;
                uiDataGridViewResult.ScrollBarRectColor = System.Drawing.Color.LightGray;

                // Enable multi-line cell formatting for the text column
                if (uiDataGridViewResult.Columns.Count > 0)
                {
                    uiDataGridViewResult.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // Automatically adjust the row heights based on cell content
                uiDataGridViewResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void SearchInUserControl(String5UserControl userControl, string typeName, string searchText)
        {
            if (userControl == null || userControl.TreeViewText == null) return;

            // Iterates through a fixed 3-tier node structure layout:
            // RootNode (Category/File) -> KeyNode (Translation ID) -> ItemNode (Raw Text value)
            foreach (TreeNode rootNode in userControl.TreeViewText.Nodes)
            {
                foreach (TreeNode keyNode in rootNode.Nodes)
                {
                    foreach (TreeNode itemNode in keyNode.Nodes)
                    {
                        if (itemNode.Text != null && itemNode.Text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int rowIndex = uiDataGridViewResult.Rows.Add();
                            uiDataGridViewResult.Rows[rowIndex].Cells[0].Value = itemNode.Text;
                            uiDataGridViewResult.Rows[rowIndex].Cells[1].Value = keyNode.Text;

                            // Stores the physical node reference to facilitate direct UI navigation on click
                            uiDataGridViewResult.Rows[rowIndex].Cells[1].Tag = itemNode;
                            uiDataGridViewResult.Rows[rowIndex].Cells[2].Value = typeName;
                        }
                    }
                }
            }
        }

        private bool DoesNodeExistInTreeView(UITreeView treeView, TreeNode targetNode)
        {
            if (treeView == null || targetNode == null) return false;
            return CheckNodeExistsRecursive(treeView.Nodes, targetNode);
        }

        private bool CheckNodeExistsRecursive(TreeNodeCollection nodes, TreeNode targetNode)
        {
            // Verifies that the matched node is still present in the tree hierarchy to prevent potential targeting issues
            foreach (TreeNode node in nodes)
            {
                if (node == targetNode) return true;
                if (node.Nodes.Count > 0)
                {
                    if (CheckNodeExistsRecursive(node.Nodes, targetNode)) return true;
                }
            }
            return false;
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            // Call the base method which applies default Sunny.UI styles
            base.OnLoad(e);

            // Reapply custom gray styles immediately after to override the default blue theme
            ConfigureDataGridView();
        }

        private void UiPanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void UiSymbolButtonMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UiSymbolButtonMaximise_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void UiSymbolButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void uiButtonSearch_Click(object sender, EventArgs e)
        {
            uiDataGridViewResult.Rows.Clear();
            string searchText = uiTextBoxSearch.Text;
            if (string.IsNullOrEmpty(searchText) || _mainWindow == null) return;

            SearchInUserControl(_mainWindow.String5UserControlText, "Text", searchText);
            SearchInUserControl(_mainWindow.String5UserControlNoun, "Noun", searchText);
            SearchInUserControl(_mainWindow.String5UserControlDebug, "DebugText", searchText);
        }

        private void UiDataGridViewResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Double-clicking a result row focuses the matching item and tab on the main window

            if (e.RowIndex < 0 || _mainWindow == null) return;

            DataGridViewRow row = uiDataGridViewResult.Rows[e.RowIndex];
            TreeNode targetNode = row.Cells[1].Tag as TreeNode;
            string type = row.Cells[2].Value?.ToString();

            if (targetNode == null || string.IsNullOrEmpty(type)) return;

            TabPage targetTabPage = null;
            String5UserControl targetUserControl = null;

            // Map UI control targets based on metadata retrieved from search results
            if (type == "Text")
            {
                targetTabPage = _mainWindow.TabPageTexts;
                targetUserControl = _mainWindow.String5UserControlText;
            }
            else if (type == "Noun")
            {
                targetTabPage = _mainWindow.TabPageNouns;
                targetUserControl = _mainWindow.String5UserControlNoun;
            }
            else if (type == "DebugText")
            {
                targetTabPage = _mainWindow.TabPageDebug;
                targetUserControl = _mainWindow.String5UserControlDebug;
            }

            if (targetTabPage != null && targetUserControl != null)
            {
                _mainWindow.TabControl1.SelectedTab = targetTabPage;

                UITreeView treeView = targetUserControl.TreeViewText;
                if (treeView != null && DoesNodeExistInTreeView(treeView, targetNode))
                {
                    treeView.SelectedNode = targetNode;
                    treeView.Focus();
                }
            }
        }

        #endregion
    }
}