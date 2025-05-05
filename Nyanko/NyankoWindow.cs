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

namespace Nyanko
{
    public partial class NyankoWindow : Form
    {
        private T2bþ T2bþFileOpened;

        private TreeNode SelectedRightClickTreeNode;

        public NyankoWindow()
        {
            InitializeComponent();

            // Bind ressource
            faceComboBox.DataSource = new BindingSource(Faces.IEGO, null);
            faceComboBox.ValueMember = "Key";
            faceComboBox.DisplayMember = "Value";
            faceComboBox.SelectedIndex = -1;
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

            TreeNode textNode = new TreeNode("Text");
            textNode.Tag = "TextType";
            textNode.ContextMenuStrip = textTypeContextMenuStrip;

            foreach (KeyValuePair<int, TextConfig> text in T2bþFileOpened.Texts)
            {
                TreeNode subTextNode = new TreeNode(text.Key.ToString("X8"));
                subTextNode.Tag = "TextKey";
                subTextNode.ContextMenuStrip = textKeyContextMenuStrip;

                foreach (StringLevel5 stringLevel5 in text.Value.Strings)
                {
                    TreeNode textValueNode = new TreeNode(stringLevel5.Text);
                    textValueNode.Tag = "TextItem";
                    textValueNode.ContextMenuStrip = textItemContextMenuStrip;
                    subTextNode.Nodes.Add(textValueNode);
                }

                textNode.Nodes.Add(subTextNode);
            }

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
            // Open a folder selection dialog
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to search for files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;

                    // Recursively search for files with the specified extensions
                    var files = Directory.GetFiles(selectedFolder, "*.*", SearchOption.AllDirectories)
                                         .Where(file => searchExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                                         .ToList();

                    // Display the found files
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                T2bþ myFile = null;

                                // Initialize myFile based on file extension
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
                                    // you should use this
                                    if (Path.GetExtension(file) == ".bin" && myFile.Strings.Count == 0)
                                    {
                                        continue;
                                    }

                                    // Determine output path
                                    string outputPath = Path.Combine(
                                        Path.GetDirectoryName(file) ?? string.Empty,
                                        RemoveAllExtensionsWithRegex(Path.GetFileName(file)) + outputExtension);

                                    // Handle output based on extension
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
                MessageBox.Show("La chaîne hexadécimale n'est pas valide.");
                return -1;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFileName = Interaction.InputBox("Enter text:");

            if (newFileName != "")
            {
                T2bþFileOpened = new T2bþ();

                DrawTreeView(newFileName);

                attachFaceGroupBox.Enabled = true;
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
            } else
            {
                saveFileDialog.EncodingType = EncodingType.UTF8;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;

                if (saveFileDialog.EncodingType == EncodingType.ShiftJIS)
                {
                    T2bþFileOpened.Encoding = Encoding.GetEncoding("Shift-JIS");
                } else
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
            if (e.Node.Tag != null && (e.Node.Tag.ToString() == "TextItem" || e.Node.Tag.ToString() == "NounItem"))
            {
                textTextBox.Enabled = true;
                textTextBox.Text = e.Node.Text;

                if (e.Node.Tag.ToString() == "TextItem") 
                {
                    TreeNode parentNode = e.Node.Parent;
                    TextConfig textConfig = T2bþFileOpened.Texts[HexToInt(parentNode.Text)];

                    if (textConfig.WashaID != -1)
                    {
                        ModelComboBox_SelectedIndex(faceComboBox, (uint)textConfig.WashaID);
                    } else
                    {
                        faceComboBox.SelectedIndex = 0;
                    }

                    faceComboBox.Enabled = true;
                }
            }
            else
            {
                textTextBox.Enabled = false;
                faceComboBox.Enabled = false;
                textTextBox.Clear();
            }
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
            TreeNode parentNode = selectedNode.Parent;

            if (parentNode != null)
            {
                selectedNode.Text = textTextBox.Text;

                string entryType = parentNode.Tag.ToString();
                int selectedIndex = parentNode.Nodes.IndexOf(selectedNode);

                if (entryType == "TextKey")
                {
                    T2bþFileOpened.Texts[HexToInt(parentNode.Text)].Strings[selectedIndex].Text = selectedNode.Text;
                }
                else
                {
                    T2bþFileOpened.Nouns[HexToInt(parentNode.Text)].Strings[selectedIndex].Text = selectedNode.Text;
                }
            }
        }

        private void RemoveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            TreeNode parentNode = selectedNode.Parent;

            if (parentNode != null)
            {
                string entryType = parentNode.Tag.ToString();
                int selectedIndex = parentNode.Nodes.IndexOf(selectedNode);

                if (entryType == "TextKey")
                {
                    T2bþFileOpened.Texts[HexToInt(parentNode.Text)].Strings.RemoveAt(selectedIndex);
                }
                else
                {
                    T2bþFileOpened.Nouns[HexToInt(parentNode.Text)].Strings.RemoveAt(selectedIndex);
                }

                selectedNode.Remove();
                SelectedRightClickTreeNode = null;
            }
        }

        private void AddTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;

            string entryType = selectedNode.Tag.ToString();
            string newText = Interaction.InputBox("Enter text:");

            if (entryType == "TextKey")
            {
                T2bþFileOpened.Texts[HexToInt(selectedNode.Text)].Strings.Add(new StringLevel5(selectedNode.Nodes.Count, newText));
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
                } else
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
            TreeNode parentNode = selectedNode.Parent;
            TextConfig textConfig = T2bþFileOpened.Texts[HexToInt(parentNode.Text)];

            if (faceComboBox.SelectedIndex == 0)
            {
                textConfig.WashaID = -1;
            } else
            {
                if (faceComboBox.SelectedItem is KeyValuePair<uint, string> selectedWashaID)
                {
                    textConfig.WashaID = (int)selectedWashaID.Key;
                } else
                {
                    textConfig.WashaID = -1;
                }            
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
            // Display a message box to the user
            DialogResult result = MessageBox.Show(
                "Do you want to use UTF-8 encoding? If you choose No, Shift-JIS encoding will be used.",
                "Encoding Selection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Determine the encoding based on the user's choice
            var encoding = result == DialogResult.Yes ? System.Text.Encoding.UTF8 : System.Text.Encoding.GetEncoding("Shift-JIS");

            // Pass the encoding to the bulk converter or use it as needed
            BulkConverter("cfg.bin", new string[] { ".txt", ".xml" }, encoding);
        }
    }
}
