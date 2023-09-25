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
using Nyanko.Level5.Logic;

namespace Nyanko
{
    public partial class NyankoWindow : Form
    {
        private T2bþ T2bþFileOpened;

        private TreeNode SelectedRightClickTreeNode;

        public NyankoWindow()
        {
            InitializeComponent();
        }

        private void DrawTreeView()
        {
            TreeNode rootNode = new TreeNode(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));

            TreeNode textNode = new TreeNode("Text");
            textNode.Tag = "TextType";
            textNode.ContextMenuStrip = textTypeContextMenuStrip;

            foreach (KeyValuePair<int, List<TextValue>> text in T2bþFileOpened.Texts)
            {
                TreeNode subTextNode = new TreeNode(text.Key.ToString("X8"));
                subTextNode.Tag = "TextKey";
                subTextNode.ContextMenuStrip = textKeyContextMenuStrip;

                foreach (TextValue textValue in text.Value)
                {
                    TreeNode textValueNode = new TreeNode(textValue.Text);
                    textValueNode.Tag = "TextItem";
                    textValueNode.ContextMenuStrip = textItemContextMenuStrip;
                    subTextNode.Nodes.Add(textValueNode);
                }

                textNode.Nodes.Add(subTextNode);
            }

            TreeNode nounNode = new TreeNode("Noun");
            nounNode.Tag = "NounType";
            nounNode.ContextMenuStrip = textTypeContextMenuStrip;

            foreach (var noun in T2bþFileOpened.Nouns)
            {
                TreeNode subNounNode = new TreeNode(noun.Key.ToString("X8"));
                subNounNode.Tag = "NounKey";
                subNounNode.ContextMenuStrip = textKeyContextMenuStrip;

                foreach (TextValue textValue in noun.Value)
                {
                    TreeNode textValueNode = new TreeNode(textValue.Text);
                    textValueNode.Tag = "NounItem";
                    textValueNode.ContextMenuStrip = textItemContextMenuStrip;
                    subNounNode.Nodes.Add(textValueNode);
                }

                nounNode.Nodes.Add(subNounNode);
            }

            rootNode.Nodes.Add(textNode);
            rootNode.Nodes.Add(nounNode);

            textTreeView.Nodes.Clear();
            textTreeView.Nodes.Add(rootNode);

            if (textTreeView.Nodes.Count > 0)
            {
                textTreeView.SelectedNode = textTreeView.Nodes[0];
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

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Level 5 Bin files (*.bin)|*.bin";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                T2bþFileOpened = new T2bþ(new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read));

                DrawTreeView();

                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Path.GetFileName(openFileDialog1.FileName);
            saveFileDialog.Title = "Save .cfg.bin file";
            saveFileDialog.Filter = "Bin files (*.bin)|*.bin|Text (.txt)|*.txt";
            saveFileDialog.InitialDirectory = openFileDialog1.InitialDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;
                
                if (saveFileDialog.FilterIndex == 1)
                {
                    T2bþFileOpened.Save(saveFileName);
                } else
                {
                    MessageBox.Show("Not supported");
                    return;
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
            }
            else
            {
                textTextBox.Enabled = false;
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
                    T2bþFileOpened.Texts[HexToInt(parentNode.Text)][selectedIndex].Text = selectedNode.Text;
                }
                else
                {
                    T2bþFileOpened.Nouns[HexToInt(parentNode.Text)][selectedIndex].Text = selectedNode.Text;
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
                    T2bþFileOpened.Texts[HexToInt(parentNode.Text)].RemoveAt(selectedIndex);
                }
                else
                {
                    T2bþFileOpened.Nouns[HexToInt(parentNode.Text)].RemoveAt(selectedIndex);
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
                T2bþFileOpened.Texts[HexToInt(selectedNode.Text)].Add(new TextValue(selectedNode.Nodes.Count, newText));
                entryType = "TextItem";
            }
            else
            {
                T2bþFileOpened.Nouns[HexToInt(selectedNode.Text)].Add(new TextValue(selectedNode.Nodes.Count, newText));
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
                    List<TextValue> entries = T2bþFileOpened.Texts[HexToInt(selectedNode.Text)];
                    T2bþFileOpened.Texts.Remove(HexToInt(selectedNode.Text));
                    T2bþFileOpened.Texts.Add(crc32, entries);
                } else
                {
                    List<TextValue> entries = T2bþFileOpened.Nouns[HexToInt(selectedNode.Text)];
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
            int crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));

            if (crc32 == 0)
            {
                return;
            }

            if (!T2bþFileOpened.Texts.ContainsKey(crc32) && !T2bþFileOpened.Nouns.ContainsKey(crc32))
            {
                if (entryType == "TextType")
                {
                    T2bþFileOpened.Texts.Add(crc32, new List<TextValue>());
                    entryType = "TextKey";
                }
                else
                {
                    T2bþFileOpened.Nouns.Add(crc32, new List<TextValue>());
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

        }

        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textTreeView.ExpandAll();
        }

        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textTreeView.CollapseAll();
        }
    }
}
