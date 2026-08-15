using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Sunny.UI;
using Microsoft.VisualBasic;
using StudioElevenLib.Level5.Text;
using Nyanko.Common;
using Nyanko.UserControls;

namespace Nyanko.Forms
{
    public partial class NyankoWindow : UIForm
    {
        private T2bþ T2bþFileOpened;
        public Dictionary<int, string> Keys { get; set; }

        private SearchWindow _searchWindowInstance;

        public TabControl TabControl1 => uiTabControl1;
        public TabPage TabPageTexts => tabPageTexts;
        public TabPage TabPageNouns => tabPageNouns;
        public TabPage TabPageDebug => tabPageDebug;

        public String5UserControl String5UserControlText => string5UserControlText;
        public String5UserControl String5UserControlNoun => string5UserControlNoun;
        public String5UserControl String5UserControlDebug => string5UserControlDebug;

        public NyankoWindow()
        {
            InitializeComponent();

            Keys = new Dictionary<int, string>();

            this.uiPanelContent.BringToFront();

            if (this.uiPanelHeader != null)
            {
                this.uiPanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UiPanelHeader_MouseDown);
            }

            LoadCharacterData();

            // Initial configuration of types for each user control
            string5UserControlText.SetEntryType(EntryType.Text);
            string5UserControlNoun.SetEntryType(EntryType.Noun);
            string5UserControlDebug.SetEntryType(EntryType.DebugText);
            this.ActiveControl = uiTabControl1;

            // No file is open yet, so the CRC32 finder has nothing to work against
            cRC32FinderToolStripMenuItem.Enabled = false;
        }

        #region Public Methods
        #endregion

        #region Private Methods

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private String5UserControl GetActiveUserControl()
        {
            if (uiTabControl1.SelectedTab == tabPageTexts) return string5UserControlText;
            if (uiTabControl1.SelectedTab == tabPageNouns) return string5UserControlNoun;
            if (uiTabControl1.SelectedTab == tabPageDebug) return string5UserControlDebug;
            return null;
        }

        private TreeView GetActiveTreeView()
        {
            String5UserControl activeUC = GetActiveUserControl();
            if (activeUC == null) return null;

            // Retrieves the tree structure encapsulated in the UserControl
            return activeUC.Controls.Find("uiTreeViewText", true).FirstOrDefault() as TreeView;
        }

        private TreeView GetTreeViewFromControl(String5UserControl userControl)
        {
            if (userControl == null) return null;
            return userControl.Controls.Find("uiTreeViewText", true).FirstOrDefault() as TreeView;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;

            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                if (m.Result.ToInt32() == HTCLIENT)
                {
                    Point screenPoint = Cursor.Position;
                    Point clientPoint = this.PointToClient(screenPoint);

                    const int borderSize = 10;

                    bool isLeft = clientPoint.X <= borderSize;
                    bool isRight = clientPoint.X >= this.ClientSize.Width - borderSize;
                    bool isTop = clientPoint.Y <= borderSize;
                    bool isBottom = clientPoint.Y >= this.ClientSize.Height - borderSize;

                    if (isTop && isLeft) m.Result = (IntPtr)HTTOPLEFT;
                    else if (isTop && isRight) m.Result = (IntPtr)HTTOPRIGHT;
                    else if (isBottom && isLeft) m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (isBottom && isRight) m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else if (isLeft) m.Result = (IntPtr)HTLEFT;
                    else if (isRight) m.Result = (IntPtr)HTRIGHT;
                    else if (isTop) m.Result = (IntPtr)HTTOP;
                    else if (isBottom) m.Result = (IntPtr)HTBOTTOM;
                }
                return;
            }

            base.WndProc(ref m);
        }

        private void LoadCharacterData()
        {
            string filePath = "characters.txt";

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadLines(filePath).Skip(1))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string hexId = parts[0].Trim();
                        string name = parts[1].Trim();

                        uint id = ConvertHexToUInt32(hexId);

                        if (!Faces.IEGO.ContainsKey(id))
                        {
                            Faces.IEGO[id] = name;
                        }
                    }
                }
            }
        }

        private uint ConvertHexToUInt32(string hex)
        {
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                hex = hex.Substring(2);
            }

            if (hex.Length == 8)
            {
                byte[] bytes = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }

                return BitConverter.ToUInt32(bytes.Reverse().ToArray(), 0);
            }

            throw new FormatException("Incorrect hexadecimal ID format.");
        }

        private void DrawTreeView(string name)
        {
            if (T2bþFileOpened == null) return;

            // Share the same Keys dictionary reference as the loaded file so any edit from a user control is reflected on save
            Keys = T2bþFileOpened.Keys;

            // Injection des dictionnaires correspondants dans chaque composant utilisateur
            string5UserControlText.SetKeys(Keys);
            string5UserControlText.SetTexts(T2bþFileOpened.Texts);
            string5UserControlText.DrawTreeView("");

            string5UserControlNoun.SetKeys(Keys);
            string5UserControlNoun.SetTexts(T2bþFileOpened.Nouns);
            string5UserControlNoun.DrawTreeView("");

            string5UserControlDebug.SetKeys(Keys);
            string5UserControlDebug.SetTexts(T2bþFileOpened.TextsDebug);
            string5UserControlDebug.DrawTreeView("");
        }

        private void CleanOrphanKeys()
        {
            // Removes any key from the shared Keys dictionary that no longer matches an entry in Texts, Nouns or TextsDebug.
            // This is intentionally only called right before saving, not when a key is deleted from the tree view.

            if (T2bþFileOpened == null || T2bþFileOpened.Keys == null) return;

            List<int> orphanKeys = T2bþFileOpened.Keys.Keys
                .Where(crc32 => !T2bþFileOpened.Texts.ContainsKey(crc32) &&
                                 !T2bþFileOpened.Nouns.ContainsKey(crc32) &&
                                 !T2bþFileOpened.TextsDebug.ContainsKey(crc32))
                .ToList();

            foreach (int orphanKey in orphanKeys)
            {
                T2bþFileOpened.Keys.Remove(orphanKey);
            }
        }

        private List<int> GetNodePath(TreeNode node)
        {
            // Builds the index path (root to node) for a tree node, used to remember a selection across a tree rebuild

            List<int> path = new List<int>();
            TreeNode current = node;

            while (current != null)
            {
                path.Insert(0, current.Index);
                current = current.Parent;
            }

            return path;
        }
     
        private TreeNode GetNodeFromPath(TreeView treeView, List<int> path)
        {
            // Resolves a tree node from an index path previously built with GetNodePath

            if (treeView == null || path == null || path.Count == 0 || treeView.Nodes.Count == 0) return null;

            TreeNode current = null;
            TreeNodeCollection currentCollection = treeView.Nodes;

            foreach (int index in path)
            {
                if (index < 0 || index >= currentCollection.Count) return current;
                current = currentCollection[index];
                currentCollection = current.Nodes;
            }

            return current;
        }

        private void RefreshTreeViewsKeepingSelection()
        {
            // Redraws all 3 tree views (Texts, Nouns, TextsDebug) while keeping each one's current selection,
            // based on its position in the tree rather than its displayed text (which can change).

            TreeView textTreeView = GetTreeViewFromControl(string5UserControlText);
            TreeView nounTreeView = GetTreeViewFromControl(string5UserControlNoun);
            TreeView debugTreeView = GetTreeViewFromControl(string5UserControlDebug);

            List<int> textSelectedPath = textTreeView != null ? GetNodePath(textTreeView.SelectedNode) : null;
            List<int> nounSelectedPath = nounTreeView != null ? GetNodePath(nounTreeView.SelectedNode) : null;
            List<int> debugSelectedPath = debugTreeView != null ? GetNodePath(debugTreeView.SelectedNode) : null;

            string5UserControlText.DrawTreeView("");
            string5UserControlNoun.DrawTreeView("");
            string5UserControlDebug.DrawTreeView("");

            if (textTreeView != null) textTreeView.SelectedNode = GetNodeFromPath(textTreeView, textSelectedPath);
            if (nounTreeView != null) nounTreeView.SelectedNode = GetNodeFromPath(nounTreeView, nounSelectedPath);
            if (debugTreeView != null) debugTreeView.SelectedNode = GetNodeFromPath(debugTreeView, debugSelectedPath);
        }

        private string RemoveAllExtensionsWithRegex(string fileName)
        {
            return Regex.Replace(fileName, @"\..+$", string.Empty);
        }

        private void BulkConverter(string outputExtension, string[] searchExtensions, Encoding encoding)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to search for files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;

                    var files = Directory.GetFiles(selectedFolder, "*.*", SearchOption.AllDirectories)
                                         .Where(file => searchExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                                         .ToList();

                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                T2bþ myFile = null;

                                switch (Path.GetExtension(file))
                                {
                                    case ".txt":
                                        myFile = new T2bþ(File.ReadAllLines(file));
                                        break;
                                    case ".xml":
                                        myFile = new T2bþ(File.ReadAllText(file));
                                        break;
                                    case ".bin":
                                        myFile = new T2bþ(File.OpenRead(file));
                                        break;
                                    default:
                                        continue;
                                }

                                if (myFile != null)
                                {
                                    if (Path.GetExtension(file) == ".bin" && (myFile.Nouns.Count == 0 && myFile.Texts.Count == 0))
                                    {
                                        continue;
                                    }

                                    string outputPath = Path.Combine(
                                        Path.GetDirectoryName(file) ?? string.Empty,
                                        RemoveAllExtensionsWithRegex(Path.GetFileName(file)) + outputExtension);

                                    switch (outputExtension.ToLower())
                                    {
                                        case ".txt":
                                            File.WriteAllLines(outputPath, myFile.ExportToTxt());
                                            break;
                                        case ".xml":
                                            File.WriteAllLines(outputPath, myFile.ExportToXML());
                                            break;
                                        case "cfg.bin":
                                            myFile.Encoding = encoding;
                                            myFile.Save(outputPath, false, false);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error processing file {file}: {ex.Message}");
                            }
                        }
                    }

                    MessageBox.Show("Done!");
                }
            }
        }

        private void OpenFile(string fileName)
        {
            if (fileName.EndsWith(".bin", StringComparison.OrdinalIgnoreCase))
            {
                T2bþFileOpened = new T2bþ(new FileStream(fileName, FileMode.Open, FileAccess.Read));
            }
            else if (fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                T2bþFileOpened = new T2bþ(File.ReadAllLines(fileName));
            }
            else if (fileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                T2bþFileOpened = new T2bþ(File.ReadAllText(fileName));
            }

            DrawTreeView(Path.GetFileNameWithoutExtension(fileName));

            if (T2bþFileOpened != null)
            {
                int nounsCount = T2bþFileOpened.Nouns != null ? T2bþFileOpened.Nouns.Count : 0;
                int textsCount = T2bþFileOpened.Texts != null ? T2bþFileOpened.Texts.Count : 0;
                int debugCount = T2bþFileOpened.TextsDebug != null ? T2bþFileOpened.TextsDebug.Count : 0;

                int categoriesWithKeysCount = 0;
                if (nounsCount > 0) categoriesWithKeysCount++;
                if (textsCount > 0) categoriesWithKeysCount++;
                if (debugCount > 0) categoriesWithKeysCount++;

                if (categoriesWithKeysCount == 1)
                {
                    if (nounsCount > 0) uiTabControl1.SelectedTab = tabPageNouns;
                    else if (textsCount > 0) uiTabControl1.SelectedTab = tabPageTexts;
                    else if (debugCount > 0) uiTabControl1.SelectedTab = tabPageDebug;
                }
                else if (categoriesWithKeysCount > 1)
                {
                    if (nounsCount > 0) uiTabControl1.SelectedTab = tabPageNouns;
                    else if (textsCount > 0) uiTabControl1.SelectedTab = tabPageTexts;
                    else if (debugCount > 0) uiTabControl1.SelectedTab = tabPageDebug;
                }
            }

            string5UserControlNoun.Enabled = true;
            string5UserControlText.Enabled = true;
            string5UserControlDebug.Enabled = true;

            saveToolStripMenuItem.Enabled = true;

            // A file is now loaded, so the CRC32 finder can be used against its Texts/Nouns/TextsDebug entries
            cRC32FinderToolStripMenuItem.Enabled = true;
        }

        #endregion

        #region Events

        private void UiPanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFileName = Interaction.InputBox("Enter text:");

            if (newFileName != "")
            {
                T2bþFileOpened = new T2bþ();

                DrawTreeView(newFileName);

                saveToolStripMenuItem.Enabled = true;
                openFileDialog1.FileName = newFileName;

                // A file now exists in memory, so the CRC32 finder can be used against its (currently empty) collections
                cRC32FinderToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "All Supported Files|*.bin;*.txt;*.xml|Level 5 Bin files (*.bin)|*.bin|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog1.FileName);
            }
        }

        private void NyankoWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string dragPath = Path.GetFullPath(files[0]);
            string dragExt = Path.GetExtension(files[0]);

            if (files.Length > 1) return;
            if (dragExt != ".bin" & dragExt != ".txt" & dragExt != ".xml") return;

            openFileDialog1.FileName = dragPath;
            OpenFile(openFileDialog1.FileName);
        }

        private void NyankoWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Drop any key from the shared Keys dictionary that no longer has a matching entry before saving
            CleanOrphanKeys();

            SaveFileDialogWithEncoding saveFileDialog = new SaveFileDialogWithEncoding();

            saveFileDialog.FileName = Path.GetFileName(openFileDialog1.FileName);
            saveFileDialog.Title = "Save .cfg.bin file";
            saveFileDialog.Filter = "Level 5 Bin files (*.bin)|*.bin|Level 5 Bin (With Text Config) files (*.bin)|*.bin|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);

            if (T2bþFileOpened.GetEncoding() == 0x0)
            {
                saveFileDialog.EncodingType = EncodingType.ShiftJIS;
            }
            else
            {
                saveFileDialog.EncodingType = EncodingType.UTF8;
            }

            // Initialize the save dialog from the previously saved user settings
            // saveType is stored as a 0-based combobox index, the native FilterIndex is 1-based
            saveFileDialog.FilterIndex = Properties.Settings.Default.saveType + 1;
            saveFileDialog.EncodingType = (EncodingType)Properties.Settings.Default.saveEncoding;
            saveFileDialog.VarianceKeySupport = Properties.Settings.Default.saveVarianceKey;
            saveFileDialog.SaveKeysList = Properties.Settings.Default.saveKeys;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;

                if (saveFileDialog.EncodingType == EncodingType.ShiftJIS)
                {
                    T2bþFileOpened.Encoding = Encoding.GetEncoding("Shift-JIS");
                }
                else
                {
                    T2bþFileOpened.Encoding = Encoding.UTF8;
                }

                // Persist the chosen save options as user settings before actually writing the file,
                // so the save dialog is pre-filled with these values next time it's shown
                Properties.Settings.Default.saveType = saveFileDialog.FilterIndex - 1;
                Properties.Settings.Default.saveEncoding = (int)saveFileDialog.EncodingType;
                Properties.Settings.Default.saveVarianceKey = saveFileDialog.VarianceKeySupport;
                Properties.Settings.Default.saveKeys = saveFileDialog.SaveKeysList;
                Properties.Settings.Default.Save();

                if (saveFileDialog.FilterIndex == 1)
                {
                    T2bþFileOpened.Save(saveFileName, false, saveFileDialog.VarianceKeySupport, saveFileDialog.SaveKeysList);
                }
                else if (saveFileDialog.FilterIndex == 2)
                {
                    T2bþFileOpened.Save(saveFileName, true, saveFileDialog.VarianceKeySupport, saveFileDialog.SaveKeysList);
                }
                else if (saveFileDialog.FilterIndex == 3)
                {
                    File.WriteAllLines(saveFileName, T2bþFileOpened.ExportToTxt());
                }
                else if (saveFileDialog.FilterIndex == 4)
                {
                    File.WriteAllLines(saveFileName, T2bþFileOpened.ExportToXML());
                }

                MessageBox.Show("Saved!");
            }
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_searchWindowInstance == null || _searchWindowInstance.IsDisposed)
            {
                _searchWindowInstance = new SearchWindow(this);
                _searchWindowInstance.Show();
            }
            else
            {
                _searchWindowInstance.BringToFront();
                _searchWindowInstance.Focus();
            }
        }

        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveTreeView()?.ExpandAll();
        }

        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveTreeView()?.CollapseAll();
        }

        private void TxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BulkConverter(".txt", new string[] { ".bin", ".xml" }, null);
        }

        private void XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BulkConverter(".xml", new string[] { ".bin", ".txt" }, null);
        }

        private void CfgBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you want to use UTF-8 encoding? If you choose No, Shift-JIS encoding will be used.",
                "Encoding Selection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            var encoding = result == DialogResult.Yes ? System.Text.Encoding.UTF8 : System.Text.Encoding.GetEncoding("Shift-JIS");

            BulkConverter("cfg.bin", new string[] { ".txt", ".xml" }, encoding);
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
            this.Close();
        }

        private void CRC32FinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (T2bþFileOpened == null) return;

            using (GenerateCRC32Window generateWindow = new GenerateCRC32Window())
            {
                if (generateWindow.ShowDialog() == DialogResult.OK)
                {
                    int addedCount = 0;

                    foreach (KeyValuePair<int, string> generatedKey in generateWindow.GeneratedKeys)
                    {
                        // Skip if this crc32 is already registered in the shared Keys dictionary
                        if (Keys.ContainsKey(generatedKey.Key)) continue;

                        // Only register the key if it actually matches an existing entry in Texts, Nouns or TextsDebug
                        bool matchesExistingEntry = T2bþFileOpened.Texts.ContainsKey(generatedKey.Key) ||
                                                     T2bþFileOpened.Nouns.ContainsKey(generatedKey.Key) ||
                                                     T2bþFileOpened.TextsDebug.ContainsKey(generatedKey.Key);

                        if (!matchesExistingEntry) continue;

                        Keys[generatedKey.Key] = generatedKey.Value;
                        addedCount++;
                    }

                    // Only refresh the tree views if at least one new key was actually added
                    if (addedCount > 0)
                    {
                        RefreshTreeViewsKeepingSelection();
                    }
                }
            }
        }

        #endregion
    }
}