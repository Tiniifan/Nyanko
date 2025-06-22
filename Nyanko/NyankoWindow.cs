using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Nyanko.Tools;
using Nyanko.Level5.Binary;
using Nyanko.Level5.T2bþ;
using Nyanko.Level5.Binary.Logic;
using Nyanko.Common;
using Nyanko.UserControls;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Nyanko
{
    public partial class NyankoWindow : Form
    {
        private T2bþ T2bþFileOpened;
        private TreeNode SelectedRightClickTreeNode;

        public NyankoWindow()
        {
            InitializeComponent();

            // Load character data from file
            LoadCharacterData();

            // Bind resource
            faceComboBox.DataSource = new BindingSource(Faces.IEGO, null);
            faceComboBox.ValueMember = "Key";
            faceComboBox.DisplayMember = "Value";
            faceComboBox.SelectedIndex = -1;
        }

        private void LoadCharacterData()
        {
            string filePath = "characters.txt";

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadLines(filePath).Skip(1))  // Skip header line
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

        private void ModelComboBox_SelectedIndex(ComboBox combobox, uint keyToFind)
        {
            BindingSource bindingSource = (combobox.DataSource as BindingSource);
            Dictionary<uint, string> source = bindingSource.DataSource as Dictionary<uint, string>;
            combobox.SelectedIndex = source.Keys.ToList().IndexOf(keyToFind);
            combobox.SelectedItem = keyToFind;
        }

        private void DrawTreeView(string name)
        {
            TreeNode rootNode = new TreeNode(name);

            // Create Text section with DialogBox structure
            TreeNode textNode = new TreeNode("Text");
            textNode.Tag = "TextType";
            textNode.ContextMenuStrip = textTypeContextMenuStrip;

            foreach (KeyValuePair<int, TextConfig> text in T2bþFileOpened.Texts)
            {
                TreeNode subTextNode = new TreeNode(text.Key.ToString("X8"));
                subTextNode.Tag = "TextKey";
                subTextNode.ContextMenuStrip = textKeyContextMenuStrip;

                // Group strings by DialogBox (assuming TextNumber represents DialogBox ID)
                var dialogBoxGroups = text.Value.Strings.GroupBy(s => s.TextNumber).OrderBy(g => g.Key);

                foreach (var dialogBoxGroup in dialogBoxGroups)
                {
                    TreeNode dialogBoxNode = new TreeNode($"DialogBox {dialogBoxGroup.Key}");
                    dialogBoxNode.Tag = "DialogBox";
                    dialogBoxNode.ContextMenuStrip = dialogBoxContextMenuStrip;

                    foreach (StringLevel5 stringLevel5 in dialogBoxGroup.OrderBy(s => s.VarianceText))
                    {
                        TreeNode textValueNode = new TreeNode(stringLevel5.Text);
                        textValueNode.Tag = "TextItem";
                        textValueNode.ContextMenuStrip = textItemContextMenuStrip;
                        dialogBoxNode.Nodes.Add(textValueNode);
                    }

                    subTextNode.Nodes.Add(dialogBoxNode);
                }

                textNode.Nodes.Add(subTextNode);
            }

            // Create Noun section
            TreeNode nounNode = new TreeNode("Noun");
            nounNode.Tag = "NounType";
            nounNode.ContextMenuStrip = textTypeContextMenuStrip;

            foreach (KeyValuePair<int, TextConfig> noun in T2bþFileOpened.Nouns)
            {
                TreeNode subNounNode = new TreeNode(noun.Key.ToString("X8"));
                subNounNode.Tag = "NounKey";
                subNounNode.ContextMenuStrip = textKeyContextMenuStrip;

                foreach (StringLevel5 stringLevel5 in noun.Value.Strings)
                {
                    TreeNode nounValueNode = new TreeNode(stringLevel5.Text);
                    nounValueNode.Tag = "NounItem";
                    nounValueNode.ContextMenuStrip = textItemContextMenuStrip;
                    subNounNode.Nodes.Add(nounValueNode);
                }

                nounNode.Nodes.Add(subNounNode);
            }

            rootNode.Nodes.Add(textNode);
            rootNode.Nodes.Add(nounNode);
            rootNode.Expand();

            textTreeView.Nodes.Clear();
            textTreeView.Nodes.Add(rootNode);

            if (textTreeView.Nodes.Count > 0)
            {
                textTreeView.SelectedNode = textTreeView.Nodes[0];
            }
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
                                            myFile.Save(outputPath, false);
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

        private int HexToInt(string hexString)
        {
            try
            {
                int intValue = int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
                return intValue;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid hexadecimal string.");
                return -1;
            }
        }

        private StringLevel5 GetStringLevel5FromNode(TreeNode node)
        {
            if (node.Tag?.ToString() != "TextItem" && node.Tag?.ToString() != "NounItem")
                return null;

            bool isNoun = node.Tag?.ToString() == "NounItem";
            TreeNode keyNode;
            int dialogBoxIndex;
            int textIndex = node.Index;

            if (isNoun)
            {
                // For nouns: direct structure Noun -> Key
                keyNode = node.Parent;
                dialogBoxIndex = 1;
            }
            else
            {
                // For texts: structure Text -> DialogBox -> Key  
                TreeNode dialogBoxNode = node.Parent;
                keyNode = dialogBoxNode?.Parent;

                if (dialogBoxNode == null || keyNode == null) return null;

                // Extract dialogbox index
                string dialogBoxText = dialogBoxNode.Text;
                if (!dialogBoxText.StartsWith("DialogBox ")) return null;

                if (!int.TryParse(dialogBoxText.Replace("DialogBox ", ""), out dialogBoxIndex))
                    return null;
            }

            if (keyNode == null) return null;

            int keyIndex = HexToInt(keyNode.Text);

            // Get appropriate configuration
            var textConfig = isNoun ?
                T2bþFileOpened.Nouns[keyIndex] :
                T2bþFileOpened.Texts[keyIndex];

            // Filter and sort items
            var stringItems = textConfig.Strings
                .Where(s => s.TextNumber == dialogBoxIndex)
                //.OrderBy(s => s.VarianceText)
                .ToList();

            return textIndex < stringItems.Count ? stringItems[textIndex] : null;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFileName = Interaction.InputBox("Enter text:");

            if (newFileName != "")
            {
                T2bþFileOpened = new T2bþ();

                DrawTreeView(newFileName);

                attachFaceGroupBox.Enabled = true;
                varianceKeyGroupBox.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                openFileDialog1.FileName = newFileName;
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

            attachFaceGroupBox.Enabled = true;
            varianceKeyGroupBox.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
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

                if (saveFileDialog.FilterIndex == 1)
                {
                    T2bþFileOpened.Save(saveFileName, false);
                }
                else if (saveFileDialog.FilterIndex == 2)
                {
                    T2bþFileOpened.Save(saveFileName, true);
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

        private void TextTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            var nodeTag = node.Tag?.ToString();
            var isValidNode = nodeTag == "TextItem" || nodeTag == "NounItem";

            if (nodeTag == "TextType" || nodeTag == "NounType" || nodeTag == "TextKey" || nodeTag == "NounKey" || nodeTag == "DialogBox")
            {
                if (!node.IsExpanded)
                {
                    node.Expand();
                }
            }

            // Disable all controls if node is not valid for editing
            if (!isValidNode)
            {
                faceLabel.Enabled = false;
                faceComboBox.Enabled = false;
                varianceKeyLabel.Enabled = false;
                varianceKeyNumericUpDown.Enabled = false;
                textTextBox.Enabled = false;
                textTextBox.Clear();
                return;
            }

            // Enable and configure text
            textTextBox.Enabled = true;
            textTextBox.Text = node.Text;

            // Get StringLevel5 object
            var stringLevel5 = GetStringLevel5FromNode(node);
            if (stringLevel5 == null) return;

            // Get text configuration based on node type
            TreeNode keyNode = nodeTag == "TextItem" ? node.Parent.Parent : node.Parent;
            var parentIndex = HexToInt(keyNode.Text);
            var textConfig = nodeTag == "TextItem" ? T2bþFileOpened.Texts[parentIndex] : T2bþFileOpened.Nouns[parentIndex];

            // Configure face controls (only for TextItem)
            var isFaceEnabled = nodeTag == "TextItem";
            faceLabel.Enabled = isFaceEnabled;
            faceComboBox.Enabled = isFaceEnabled;

            if (isFaceEnabled)
            {
                if (textConfig.WashaID != -1)
                {
                    ModelComboBox_SelectedIndex(faceComboBox, (uint)textConfig.WashaID);
                }
                else
                {
                    faceComboBox.SelectedIndex = 0;
                }
            }

            // Configure variance controls
            varianceKeyLabel.Enabled = true;
            varianceKeyNumericUpDown.Enabled = true;
            varianceKeyNumericUpDown.Value = stringLevel5.VarianceText;

            Focus();
            groupBox1.Focus();
        }

        private void TextTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedRightClickTreeNode = e.Node;
            }
        }

        private void TextTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!textTextBox.Focused || textTreeView.SelectedNode == null) return;

            TreeNode selectedNode = textTreeView.SelectedNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (nodeTag != "TextItem" && nodeTag != "NounItem") return;

            selectedNode.Text = textTextBox.Text;

            // Get StringLevel5 object and update it
            var stringLevel5 = GetStringLevel5FromNode(selectedNode);
            if (stringLevel5 != null)
            {
                stringLevel5.Text = selectedNode.Text;
            }
        }

        private void RemoveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (nodeTag == "TextItem" || nodeTag == "NounItem")
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this text entry?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    SelectedRightClickTreeNode = null;
                    return;
                }

                var stringLevel5 = GetStringLevel5FromNode(selectedNode);
                if (stringLevel5 != null)
                {
                    TreeNode keyNode = nodeTag == "TextItem" ? selectedNode.Parent.Parent : selectedNode.Parent;
                    var parentIndex = HexToInt(keyNode.Text);
                    var textConfig = nodeTag == "TextItem" ? T2bþFileOpened.Texts[parentIndex] : T2bþFileOpened.Nouns[parentIndex];

                    textConfig.Strings.Remove(stringLevel5);
                    selectedNode.Remove();
                }
            }

            SelectedRightClickTreeNode = null;
        }

        private void AddTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string entryType = selectedNode.Tag.ToString();
            string newText = Interaction.InputBox("Enter text:");

            if (entryType == "DialogBox")
            {
                TreeNode keyNode = selectedNode.Parent;
                int dialogBoxNumber = int.Parse(selectedNode.Text.Replace("DialogBox ", ""));
                int parentIndex = HexToInt(keyNode.Text);

                // Find next available variance key for this dialog box
                var existingVariances = T2bþFileOpened.Texts[parentIndex].Strings
                    .Where(s => s.TextNumber == dialogBoxNumber)
                    .Select(s => s.VarianceText)
                    .ToList();

                int nextVariance = existingVariances.Any() ? existingVariances.Max() + 1 : 0;

                T2bþFileOpened.Texts[parentIndex].Strings.Add(new StringLevel5(dialogBoxNumber, newText, nextVariance));

                TreeNode newTreeNode = new TreeNode(newText);
                newTreeNode.Tag = "TextItem";
                newTreeNode.ContextMenuStrip = textItemContextMenuStrip;
                selectedNode.Nodes.Add(newTreeNode);
            }
            else if (entryType == "TextKey" || entryType == "NounKey")
            {
                // Handle traditional add for noun or when adding to key directly
                if (entryType == "TextKey")
                {
                    T2bþFileOpened.Texts[HexToInt(selectedNode.Text)].Strings.Add(new StringLevel5(0, newText));
                    entryType = "TextItem";
                }
                else
                {
                    T2bþFileOpened.Nouns[HexToInt(selectedNode.Text)].Strings.Add(new StringLevel5(selectedNode.Nodes.Count, newText));
                    entryType = "NounItem";
                }

                TreeNode newTreeNode = new TreeNode(newText);
                newTreeNode.Tag = entryType;
                newTreeNode.ContextMenuStrip = textItemContextMenuStrip;
                selectedNode.Nodes.Add(newTreeNode);
            }

            SelectedRightClickTreeNode = null;
        }

        private void RenameKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string entryType = selectedNode.Tag.ToString();

            string keyName = Interaction.InputBox("Enter new key name:");
            int crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));

            if (!T2bþFileOpened.Texts.ContainsKey(crc32) && !T2bþFileOpened.Nouns.ContainsKey(crc32))
            {
                if (entryType == "TextKey")
                {
                    TextConfig entries = T2bþFileOpened.Texts[HexToInt(selectedNode.Text)];
                    T2bþFileOpened.Texts.Remove(HexToInt(selectedNode.Text));
                    T2bþFileOpened.Texts.Add(crc32, entries);
                }
                else
                {
                    TextConfig entries = T2bþFileOpened.Nouns[HexToInt(selectedNode.Text)];
                    T2bþFileOpened.Nouns.Remove(HexToInt(selectedNode.Text));
                    T2bþFileOpened.Nouns.Add(crc32, entries);
                }
            }
            else
            {
                MessageBox.Show("The given key already exists");
                return;
            }

            selectedNode.Text = crc32.ToString("X8");
            SelectedRightClickTreeNode = null;
        }

        private void RemoveKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string entryType = selectedNode.Tag.ToString();

            string keyType = entryType == "TextKey" ? "text key" : "noun key";
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this {keyType} and all its entries?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            if (entryType == "TextKey")
            {
                T2bþFileOpened.Texts.Remove(HexToInt(selectedNode.Text));
            }
            else
            {
                T2bþFileOpened.Nouns.Remove(HexToInt(selectedNode.Text));
            }

            selectedNode.Remove();
            SelectedRightClickTreeNode = null;
        }

        private void AddKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string entryType = selectedNode.Tag.ToString();

            string keyName = Interaction.InputBox("Enter key name:");
            int crc32 = 0;

            if (keyName.Length == 8)
            {
                try
                {
                    crc32 = Convert.ToInt32(keyName, 16);
                }
                catch
                {
                    crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
                }
            }
            else
            {
                crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
            }

            if (crc32 == 0)
            {
                return;
            }

            if (!T2bþFileOpened.Texts.ContainsKey(crc32) && !T2bþFileOpened.Nouns.ContainsKey(crc32))
            {
                if (entryType == "TextType")
                {
                    T2bþFileOpened.Texts.Add(crc32, new TextConfig(new List<StringLevel5>()));
                    entryType = "TextKey";
                }
                else
                {
                    T2bþFileOpened.Nouns.Add(crc32, new TextConfig(new List<StringLevel5>()));
                    entryType = "NounKey";
                }
            }
            else
            {
                MessageBox.Show("The given key already exists");
                return;
            }

            TreeNode newTreeNode = new TreeNode(crc32.ToString("X8"));
            newTreeNode.Tag = entryType;
            newTreeNode.ContextMenuStrip = textKeyContextMenuStrip;
            selectedNode.Nodes.Add(newTreeNode);

            SelectedRightClickTreeNode = null;
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(textTreeView);
            searchWindow.Show();
        }

        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textTreeView.ExpandAll();
        }

        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textTreeView.CollapseAll();
        }

        private void FaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!faceComboBox.Focused || faceComboBox.SelectedIndex == -1) return;

            TreeNode selectedNode = textTreeView.SelectedNode;
            if (selectedNode.Tag?.ToString() != "TextItem") return;

            TreeNode keyNode = selectedNode.Parent.Parent; // DialogBox -> TextKey
            TextConfig textConfig = T2bþFileOpened.Texts[HexToInt(keyNode.Text)];

            if (faceComboBox.SelectedIndex == 0)
            {
                textConfig.WashaID = -1;
            }
            else
            {
                if (faceComboBox.SelectedItem is KeyValuePair<uint, string> selectedWashaID)
                {
                    textConfig.WashaID = (int)selectedWashaID.Key;
                }
                else
                {
                    textConfig.WashaID = -1;
                }
            }
        }

        private void VarianceKeyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!varianceKeyNumericUpDown.Focused || textTreeView.SelectedNode == null) return;

            TreeNode selectedNode = textTreeView.SelectedNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (nodeTag != "TextItem" && nodeTag != "NounItem") return;

            // Get StringLevel5 object
            var stringLevel5 = GetStringLevel5FromNode(selectedNode);
            if (stringLevel5 != null)
            {
                stringLevel5.VarianceText = Convert.ToInt32(varianceKeyNumericUpDown.Value);
            }
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

        private void TextKeyContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            string nodeTag = SelectedRightClickTreeNode.Tag?.ToString();

            if (nodeTag == "NounKey")
            {
                addTextToolStripMenuItem.Visible = true;
                addDialogboxToolStripMenuItem.Visible = false;
            }
            else if (nodeTag == "TextKey")
            {
                addTextToolStripMenuItem.Visible = false;
                addDialogboxToolStripMenuItem.Visible = true;
            }
            else
            {
                addTextToolStripMenuItem.Visible = false;
                addDialogboxToolStripMenuItem.Visible = false;
            }
        }

        private void AddDialogboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag?.ToString();

            // Only allow adding dialog box to TextKey nodes
            if (nodeTag != "TextKey")
            {
                MessageBox.Show("Dialog boxes can only be added to Text keys.");
                return;
            }

            int parentIndex = HexToInt(selectedNode.Text);

            // Find the next available dialog box number
            var existingDialogBoxNumbers = T2bþFileOpened.Texts[parentIndex].Strings
                .Select(s => s.TextNumber)
                .Distinct()
                .OrderBy(n => n)
                .ToList();

            int nextDialogBoxNumber = 0;
            if (existingDialogBoxNumbers.Any())
            {
                // Find the first gap in the sequence or add to the end
                for (int i = 0; i < existingDialogBoxNumbers.Count; i++)
                {
                    if (existingDialogBoxNumbers[i] != i)
                    {
                        nextDialogBoxNumber = i;
                        break;
                    }
                }

                // If no gap found, use the next number after the last one
                if (nextDialogBoxNumber == 0 && existingDialogBoxNumbers.Last() >= 0)
                {
                    nextDialogBoxNumber = existingDialogBoxNumbers.Last() + 1;
                }
            }

            // Create the dialog box node
            TreeNode dialogBoxNode = new TreeNode($"DialogBox {nextDialogBoxNumber}");
            dialogBoxNode.Tag = "DialogBox";
            dialogBoxNode.ContextMenuStrip = dialogBoxContextMenuStrip;

            // Add the dialog box node to the text key node
            selectedNode.Nodes.Add(dialogBoxNode);

            // Aadd a default text item to the new dialog box
            string defaultText = Interaction.InputBox("Enter initial text for the dialog box (optional):");

            if (!string.IsNullOrEmpty(defaultText))
            {
                // Add the string to the data structure
                T2bþFileOpened.Texts[parentIndex].Strings.Add(new StringLevel5(nextDialogBoxNumber, defaultText, 0));

                // Create the text node in the tree
                TreeNode textNode = new TreeNode(defaultText);
                textNode.Tag = "TextItem";
                textNode.ContextMenuStrip = textItemContextMenuStrip;
                dialogBoxNode.Nodes.Add(textNode);
            }

            // Expand the parent node to show the new dialog box
            selectedNode.Expand();

            SelectedRightClickTreeNode = null;
        }

        // Function from dialogboxcontextmenu strip
        private void AddTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag?.ToString();

            // Only allow adding text to DialogBox nodes
            if (nodeTag != "DialogBox")
            {
                MessageBox.Show("Text can only be added to Dialog Box nodes.");
                return;
            }

            string newText = Interaction.InputBox("Enter text:");

            if (string.IsNullOrEmpty(newText))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            // Get the dialog box number and parent text key
            int dialogBoxNumber = int.Parse(selectedNode.Text.Replace("DialogBox ", ""));
            TreeNode keyNode = selectedNode.Parent;
            int parentIndex = HexToInt(keyNode.Text);

            // Find next available variance key for this dialog box
            var existingVariances = T2bþFileOpened.Texts[parentIndex].Strings
                .Where(s => s.TextNumber == dialogBoxNumber)
                .Select(s => s.VarianceText)
                .ToList();

            int nextVariance = existingVariances.Any() ? existingVariances.Max() + 1 : 0;

            // Add the string to the data structure
            T2bþFileOpened.Texts[parentIndex].Strings.Add(new StringLevel5(dialogBoxNumber, newText, nextVariance));

            // Create the tree node
            TreeNode newTreeNode = new TreeNode(newText);
            newTreeNode.Tag = "TextItem";
            newTreeNode.ContextMenuStrip = textItemContextMenuStrip;
            selectedNode.Nodes.Add(newTreeNode);

            // Expand the dialog box to show the new text
            selectedNode.Expand();

            SelectedRightClickTreeNode = null;
        }

        // Function from dialogboxcontextmenu strip
        private void DeleteDialogboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag?.ToString();

            // Only allow deleting DialogBox nodes
            if (nodeTag != "DialogBox")
            {
                MessageBox.Show("Only Dialog Box nodes can be deleted.");
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this dialog box and all its text entries?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            // Get the dialog box number and parent text key
            int dialogBoxNumber = int.Parse(selectedNode.Text.Replace("DialogBox ", ""));
            TreeNode keyNode = selectedNode.Parent;
            int parentIndex = HexToInt(keyNode.Text);

            // Remove all strings associated with this dialog box from data structure
            var stringsToRemove = T2bþFileOpened.Texts[parentIndex].Strings
                .Where(s => s.TextNumber == dialogBoxNumber)
                .ToList();

            foreach (var stringToRemove in stringsToRemove)
            {
                T2bþFileOpened.Texts[parentIndex].Strings.Remove(stringToRemove);
            }

            // Remove the dialog box node from the tree
            selectedNode.Remove();

            SelectedRightClickTreeNode = null;
        }
    }
}