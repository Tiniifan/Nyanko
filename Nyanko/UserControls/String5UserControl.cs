using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Sunny.UI;
using StudioElevenLib.Level5.Text.Logic;
using Nyanko.Common;

namespace Nyanko.UserControls
{
    public partial class String5UserControl : UserControl
    {
        private Dictionary<int, TextConfig> Texts;
        private Dictionary<int, string> Keys;
        private List<CharacterInfo> Characters;

        private TreeNode SelectedRightClickTreeNode;
        private EntryType _entryType;

        public UITreeView TreeViewText => uiTreeViewText;

        public String5UserControl()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void SetEntryType(EntryType entryType)
        {
            _entryType = entryType;

            if (uiGroupBoxAttachCharacter != null)
            {
                // The character attachment group is only relevant for dialog-based entries, not for nouns
                uiGroupBoxAttachCharacter.Visible = (_entryType != EntryType.Noun);
            }
        }

        public void SetTexts(Dictionary<int, TextConfig> texts)
        {
            Texts = texts;
            UpdateTabPageHeader();
        }

        public void SetKeys(Dictionary<int, string> keys)
        {
            Keys = keys;
        }

        public void SetCharacters(List<CharacterInfo> characters)
        {
            Characters = characters;
        }

        public void DrawTreeView(string filterText)
        {
            if (Texts == null) return;

            uiTreeViewText.BeginUpdate();
            uiTreeViewText.Nodes.Clear();

            string sectionName = _entryType.ToString();
            TreeNode rootNode = CreateNode(sectionName, sectionName, null);
            bool rootHasMatches = false;

            string keyTag = GetKeyTag();
            string itemTag = GetItemTag();
            int occurrencesCount = 0;

            foreach (KeyValuePair<int, TextConfig> item in Texts)
            {
                string keyHex = item.Key.ToString("X8");

                // Use the friendly name from the shared Keys dictionary if one exists for this crc32, otherwise fall back to the hex representation
                string keyDisplayName = (Keys != null && Keys.ContainsKey(item.Key)) ? Keys[item.Key] : keyHex;

                // The node's Name always stores the hex crc32 so the real key can be retrieved even when Text shows a friendly name
                TreeNode keyNode = CreateNode(keyDisplayName, keyTag, textKeyContextMenuStrip, keyHex);
                bool keyHasMatches = false;

                // Group item nodes by TextNumber to display variances as sub-nodes of their base node
                Dictionary<int, TreeNode> parentNodesByTextNumber = new Dictionary<int, TreeNode>();

                foreach (StringLevel5 stringLevel5 in item.Value.Strings)
                {
                    if (IsMatch(stringLevel5.Text, filterText))
                    {
                        TreeNode nounValueNode = CreateNode(CleanTextForNode(stringLevel5.Text), itemTag, textItemContextMenuStrip, null, stringLevel5);

                        if (!parentNodesByTextNumber.ContainsKey(stringLevel5.TextNumber))
                        {
                            keyNode.Nodes.Add(nounValueNode);
                            parentNodesByTextNumber[stringLevel5.TextNumber] = nounValueNode;
                        }
                        else
                        {
                            parentNodesByTextNumber[stringLevel5.TextNumber].Nodes.Add(nounValueNode);
                        }

                        keyHasMatches = true;
                        occurrencesCount++;
                    }
                }

                bool keyNameMatches = IsMatch(keyDisplayName, filterText) || IsMatch(keyHex, filterText);

                if (keyHasMatches || keyNameMatches)
                {
                    rootNode.Nodes.Add(keyNode);
                    rootHasMatches = true;
                }
            }

            if (rootHasMatches || string.IsNullOrEmpty(filterText))
            {
                uiTreeViewText.Nodes.Add(rootNode);
                rootNode.ExpandAll();
            }

            uiTreeViewText.EndUpdate();

            if (uiLabelResult != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    uiLabelResult.Visible = false;
                }
                else
                {
                    uiLabelResult.Text = $"{occurrencesCount} occurrence(s) found";
                    uiLabelResult.Visible = true;
                }
            }
        }

        #endregion

        #region Private Methods

        private void UpdateTabPageHeader()
        {
            Control parent = this.Parent;
            while (parent != null && !(parent is TabPage))
            {
                parent = parent.Parent;
            }

            if (parent is TabPage tabPage)
            {
                int keyCount = Texts != null ? Texts.Count : 0;
                string currentText = tabPage.Text;
                int index = currentText.IndexOf(" (");
                if (index != -1)
                {
                    currentText = currentText.Substring(0, index);
                }
                tabPage.Text = $"{currentText} ({keyCount})";
            }
        }

        private string CleanTextForNode(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            // Tree node labels can't display multi-line text properly, so collapse line breaks into spaces
            return text.Replace("\r", "").Replace("\n", " ");
        }

        private void PopulateCharacterComboBox()
        {
            // Populates the character combo box from the shared Characters list (loaded from characters.txt).
            // The combo box is only enabled when at least one character is available.

            if (uiComboBoxCharacter.Items.Count == 0)
            {
                uiComboBoxCharacter.Items.Clear();

                if (Characters != null && Characters.Count > 0)
                {
                    // First entry represents "no character attached", real characters start at index 1
                    uiComboBoxCharacter.Items.Add("No Character attached");
                    foreach (var character in Characters)
                    {
                        uiComboBoxCharacter.Items.Add(character);
                    }
                }
            }

            uiComboBoxCharacter.Enabled = Characters != null && Characters.Count > 0;
        }

        private void ModelComboBox_SelectedIndex(UIComboBox combobox, int keyToFind)
        {
            PopulateCharacterComboBox();

            // Start at index 1 to skip the "No Character attached" placeholder entry
            for (int i = 1; i < combobox.Items.Count; i++)
            {
                if (combobox.Items[i] is CharacterInfo character && character.Id == keyToFind)
                {
                    combobox.SelectedIndex = i;
                    return;
                }
            }

            if (combobox.Items.Count > 0)
            {
                combobox.SelectedIndex = 0;
            }
        }

        private string GetKeyTag()
        {
            switch (_entryType)
            {
                case EntryType.Noun: return "NounKey";
                case EntryType.DebugText: return "DebugTextKey";
                case EntryType.Text:
                default:
                    return "TextKey";
            }
        }

        private string GetItemTag()
        {
            switch (_entryType)
            {
                case EntryType.Noun: return "NounItem";
                case EntryType.DebugText: return "DebugTextItem";
                case EntryType.Text:
                default:
                    return "TextItem";
            }
        }

        private string GetItemTagFromKeyTag(string keyTag)
        {
            if (keyTag == "NounKey") return "NounItem";
            if (keyTag == "DebugTextKey") return "DebugTextItem";
            return "TextItem";
        }

        private bool IsItemNode(string tag)
        {
            return tag == "TextItem" || tag == "NounItem" || tag == "DebugTextItem";
        }

        private bool IsContainerNode(string tag)
        {
            return tag == "TextType" || tag == "NounType" || tag == "DebugTextType" ||
                   tag == "Text" || tag == "Noun" || tag == "DebugText" ||
                   tag == "TextKey" || tag == "NounKey" || tag == "DebugTextKey";
        }

        private bool IsKeyNode(string tag)
        {
            return tag == "TextKey" || tag == "NounKey" || tag == "DebugTextKey";
        }

        private bool IsMatch(string source, string filterText)
        {
            return string.IsNullOrEmpty(filterText) ||
                   source.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private TreeNode CreateNode(string text, string tag, ContextMenuStrip contextMenu, string name = null, StringLevel5 stringRef = null)
        {
            return new TreeNode(text)
            {
                Name = name ?? text,
                Tag = new NodeTagInfo(tag, stringRef),
                ContextMenuStrip = null
            };
        }

        private int HexToInt(string hexString)
        {
            try
            {
                return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid hexadecimal string.");
                return -1;
            }
        }

        private void ReorganizeTextNumbers(int keyIndex)
        {
            // Reorganizes TextNumber properties sequentially while keeping variance structures intact

            if (Texts.ContainsKey(keyIndex))
            {
                var strings = Texts[keyIndex].Strings;
                var oldToNewMap = new Dictionary<int, int>();
                int nextTextNumber = 0;
                foreach (var s in strings)
                {
                    if (!oldToNewMap.ContainsKey(s.TextNumber))
                    {
                        oldToNewMap[s.TextNumber] = nextTextNumber++;
                    }
                    s.TextNumber = oldToNewMap[s.TextNumber];
                }
            }
        }

        private StringLevel5 GetStringLevel5FromNode(TreeNode node)
        {
            if (node == null) return null;
            if (node.Tag is NodeTagInfo info)
            {
                return info.StringRef;
            }
            return null;
        }

        private TreeNode GetRootNode(TreeNode node)
        {
            if (node == null) return null;
            TreeNode current = node;
            while (current.Parent != null)
            {
                current = current.Parent;
            }
            return current;
        }


        private TreeNode FindKeyNode(TreeNode node)
        {
            // Traverse up to find the key node of any given node

            TreeNode current = node;

            while (current != null)
            {
                if (IsKeyNode(current.Tag?.ToString()))
                {
                    return current;
                }
                current = current.Parent;
            }

            return null;
        }

        private ContextMenuStrip GetContextMenuForNode(TreeNode node)
        {
            if (node == null) return null;
            string tag = node.Tag?.ToString();

            if (tag == "Text" || tag == "Noun" || tag == "DebugText")
            {
                return textTypeContextMenuStrip;
            }
            if (tag == "TextKey" || tag == "NounKey" || tag == "DebugTextKey")
            {
                return textKeyContextMenuStrip;
            }
            if (IsItemNode(tag))
            {
                // If the item represents a variance entry (VarianceKey > 0), show the variance specific context menu
                var stringLevel5 = GetStringLevel5FromNode(node);
                if (stringLevel5 != null && stringLevel5.VarianceKey > 0)
                {
                    return varianceTextContextMenuStrip;
                }

                return textItemContextMenuStrip;
            }
            return null;
        }

        private void PopulateSpeakerComboBox()
        {
            if (uiComboBoxSpeaker != null && uiComboBoxSpeaker.Items.Count == 0)
            {
                uiComboBoxSpeaker.Items.Clear();
                uiComboBoxSpeaker.Items.Add(new SpeakerInfo(SpeakerType.None, "None"));
                uiComboBoxSpeaker.Items.Add(new SpeakerInfo(SpeakerType.Female, "Female"));
                uiComboBoxSpeaker.Items.Add(new SpeakerInfo(SpeakerType.Male, "Male"));
                uiComboBoxSpeaker.Items.Add(new SpeakerInfo(SpeakerType.Narrator, "Narrator"));
                uiComboBoxSpeaker.DisplayMember = "Name";
            }
        }

        private void UpdateSpeakerSelectionFromText(string text)
        {
            if (uiComboBoxSpeaker == null) return;

            SpeakerType detectedType = SpeakerType.None;
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Contains("<O9>"))
                    detectedType = SpeakerType.Female;
                else if (text.Contains("<O8>"))
                    detectedType = SpeakerType.Male;
                else if (text.Contains("<O6>"))
                    detectedType = SpeakerType.Narrator;
            }

            for (int i = 0; i < uiComboBoxSpeaker.Items.Count; i++)
            {
                if (uiComboBoxSpeaker.Items[i] is SpeakerInfo info && info.Type == detectedType)
                {
                    uiComboBoxSpeaker.SelectedIndex = i;
                    break;
                }
            }
        }

        private void UpdateTextContentForSpeaker()
        {
            TreeNode selectedNode = uiTreeViewText.SelectedNode;
            if (selectedNode == null) return;

            var stringLevel5 = GetStringLevel5FromNode(selectedNode);
            if (stringLevel5 == null) return;

            string textContent = stringLevel5.Text;
            if (string.IsNullOrEmpty(textContent)) return;

            textContent = System.Text.RegularExpressions.Regex.Replace(textContent, @"<O\d+>", "");
            textContent = textContent.Trim();

            if (uiComboBoxSpeaker.SelectedItem is SpeakerInfo selectedSpeaker)
            {
                if (selectedSpeaker.Type == SpeakerType.Female)
                {
                    textContent = "<O9>" + textContent + "<O9>";
                }
                else if (selectedSpeaker.Type == SpeakerType.Male)
                {
                    textContent = "<O8>" + textContent + "<O8>";
                }
                else if (selectedSpeaker.Type == SpeakerType.Narrator)
                {
                    textContent = "<O6>" + textContent + "<O6>";
                }
            }

            stringLevel5.Text = textContent;

            if (uiRichTextBox1.Text != textContent)
            {
                uiRichTextBox1.Text = textContent;
            }

            selectedNode.Text = CleanTextForNode(textContent);
        }

        #endregion

        #region Events

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            UpdateTabPageHeader();
        }

        private void UiComboBoxCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox activeCombo = sender as ComboBox;

            if (activeCombo == null || !activeCombo.Focused || activeCombo.SelectedIndex == -1) return;

            TreeNode selectedNode = uiTreeViewText.SelectedNode;
            if (selectedNode == null || !IsItemNode(selectedNode.Tag?.ToString())) return;

            TreeNode keyNode = selectedNode.Parent;

            if (keyNode == null) return;

            TextConfig textConfig = Texts[HexToInt(keyNode.Name)];

            if (activeCombo.SelectedIndex == 0)
            {
                // Index 0 is the "No Character attached" placeholder
                textConfig.WashaID = -1;
            }
            else if (activeCombo.SelectedItem is CharacterInfo selectedCharacter)
            {
                textConfig.WashaID = selectedCharacter.Id;
            }
            else
            {
                textConfig.WashaID = -1;
            }
        }

        private void UiUpDownTextBoxVarianceKey_TextChanged(object sender, EventArgs e)
        {
            UIUpDownTextBox activeNum = sender as UIUpDownTextBox;
            if (activeNum == null || !activeNum.Focused || uiTreeViewText.SelectedNode == null) return;

            TreeNode selectedNode = uiTreeViewText.SelectedNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (!IsItemNode(nodeTag)) return;

            var stringLevel5 = GetStringLevel5FromNode(selectedNode);
            if (stringLevel5 != null)
            {
                if (int.TryParse(activeNum.Text, out int newValue))
                {
                    TreeNode keyNode = FindKeyNode(selectedNode);
                    if (keyNode != null)
                    {
                        int keyIndex = HexToInt(keyNode.Name);
                        var existingStrings = Texts[keyIndex].Strings;

                        // Check if the input variance key already exists for this pair of key and text number
                        bool alreadyExists = existingStrings.Any(s => s != stringLevel5 && s.TextNumber == stringLevel5.TextNumber && s.VarianceKey == newValue);
                        if (alreadyExists)
                        {
                            MessageBox.Show("This variance key already exists for this entry.");
                            activeNum.Text = stringLevel5.VarianceKey.ToString();
                            return;
                        }
                    }
                    stringLevel5.VarianceKey = newValue;
                }
            }
        }

        private void UiRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!uiRichTextBox1.Focused || uiTreeViewText.SelectedNode == null) return;

            TreeNode selectedNode = uiTreeViewText.SelectedNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (!IsItemNode(nodeTag)) return;

            selectedNode.Text = CleanTextForNode(uiRichTextBox1.Text);

            var stringLevel5 = GetStringLevel5FromNode(selectedNode);
            if (stringLevel5 != null)
            {
                stringLevel5.Text = uiRichTextBox1.Text;

                // Update the speaker based on the new text typed if applicable
                UpdateSpeakerSelectionFromText(stringLevel5.Text);
            }
        }

        private void AddKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode rootNode = GetRootNode(SelectedRightClickTreeNode);
            if (rootNode == null) return;

            string keyName = Interaction.InputBox("Enter key name:");

            // If the dialog was cancelled (or left empty), abort the key creation entirely
            if (string.IsNullOrEmpty(keyName))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            bool isHex = false;
            int crc32 = 0;

            if (keyName.Length == 8)
            {
                // An 8-character input could be either a hex key or a literal name, try hex first
                try
                {
                    crc32 = Convert.ToInt32(keyName, 16);
                    isHex = true;
                }
                catch
                {
                    crc32 = unchecked((int)StudioElevenLib.Tools.Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
                }
            }
            else
            {
                crc32 = unchecked((int)StudioElevenLib.Tools.Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
            }

            if (crc32 == 0) return;

            if (!Texts.ContainsKey(crc32))
            {
                Texts.Add(crc32, new TextConfig(new List<StringLevel5>()));
                UpdateTabPageHeader();
            }
            else
            {
                MessageBox.Show("The given key already exists");
                return;
            }

            // If the key name isn't a raw hex value, register it in the shared Keys dictionary so its friendly name is displayed and saved
            if (!isHex && Keys != null && !Keys.ContainsKey(crc32))
            {
                Keys[crc32] = keyName;
            }

            string keyDisplayName = (Keys != null && Keys.ContainsKey(crc32)) ? Keys[crc32] : crc32.ToString("X8");
            TreeNode newTreeNode = CreateNode(keyDisplayName, GetKeyTag(), textKeyContextMenuStrip, crc32.ToString("X8"));
            rootNode.Nodes.Add(newTreeNode);

            rootNode.Expand();
            uiTreeViewText.SelectedNode = newTreeNode;

            SelectedRightClickTreeNode = null;
        }

        private void AddKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddKeyToolStripMenuItem_Click(sender, e);
        }

        private void AddTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag?.ToString();

            string newText = Interaction.InputBox("Enter text:");
            if (string.IsNullOrEmpty(newText))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            selectedNode.Expand();
            SelectedRightClickTreeNode = null;
        }

        private void RemoveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (IsItemNode(nodeTag))
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
                    TreeNode keyNode = FindKeyNode(selectedNode);
                    var parentIndex = HexToInt(keyNode.Name);

                    // Deletes the base text entry and all of its variance strings from the underlying config
                    Texts[parentIndex].Strings.RemoveAll(s => s.TextNumber == stringLevel5.TextNumber);
                    ReorganizeTextNumbers(parentIndex);
                    selectedNode.Remove();
                }
            }

            SelectedRightClickTreeNode = null;
        }

        private void AddTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag?.ToString();
            string newText = Interaction.InputBox("Enter text:");

            // If the dialog was cancelled (or left empty), abort the text insertion entirely
            if (string.IsNullOrEmpty(newText))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            if (nodeTag == "TextKey" || nodeTag == "NounKey" || nodeTag == "DebugTextKey")
            {
                string itemTag = GetItemTagFromKeyTag(nodeTag);
                int keyIndex = HexToInt(selectedNode.Name);

                var newString = new StringLevel5(selectedNode.Nodes.Count, newText);
                Texts[keyIndex].Strings.Add(newString);
                ReorganizeTextNumbers(keyIndex);

                TreeNode newTreeNode = CreateNode(CleanTextForNode(newText), itemTag, textItemContextMenuStrip, null, newString);
                selectedNode.Nodes.Add(newTreeNode);

                selectedNode.Expand();
                uiTreeViewText.SelectedNode = newTreeNode;
            }

            SelectedRightClickTreeNode = null;
        }

        private void RenameKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;

            string keyName = Interaction.InputBox("Enter new key name:");

            // If the dialog was cancelled (or left empty), abort the rename entirely
            if (string.IsNullOrEmpty(keyName))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            bool isHex = false;
            int crc32 = 0;

            if (keyName.Length == 8)
            {
                // An 8-character input could be either a hex key or a literal name, try hex first
                try
                {
                    crc32 = Convert.ToInt32(keyName, 16);
                    isHex = true;
                }
                catch
                {
                    crc32 = unchecked((int)StudioElevenLib.Tools.Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
                }
            }
            else
            {
                crc32 = unchecked((int)StudioElevenLib.Tools.Crc32.Compute(Encoding.UTF8.GetBytes(keyName)));
            }

            int oldKeyIndex = HexToInt(selectedNode.Name);

            if (!Texts.ContainsKey(crc32))
            {
                // Move the entries from the old key to the new one, then drop the old key
                TextConfig entries = Texts[oldKeyIndex];
                Texts.Remove(oldKeyIndex);
                Texts.Add(crc32, entries);
            }
            else
            {
                MessageBox.Show("The given key already exists");
                return;
            }

            // If the key name isn't a raw hex value, register it in the shared Keys dictionary so its friendly name is displayed and saved
            if (!isHex && Keys != null && !Keys.ContainsKey(crc32))
            {
                Keys[crc32] = keyName;
            }

            selectedNode.Name = crc32.ToString("X8");
            selectedNode.Text = (Keys != null && Keys.ContainsKey(crc32)) ? Keys[crc32] : crc32.ToString("X8");

            SelectedRightClickTreeNode = null;
        }

        private void RemoveKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            string nodeTag = selectedNode.Tag.ToString();

            string keyType;
            if (nodeTag == "TextKey") keyType = "text key";
            else if (nodeTag == "NounKey") keyType = "noun key";
            else keyType = "debug text key";

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

            // Note: the shared Keys dictionary is NOT touched here on purpose.
            // Orphaned keys are only cleaned up right before saving (see NyankoWindow.CleanOrphanKeys).
            Texts.Remove(HexToInt(selectedNode.Name));
            selectedNode.Remove();
            UpdateTabPageHeader();
            SelectedRightClickTreeNode = null;
        }

        private void UiTreeViewText_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            var nodeTag = node.Tag?.ToString();

            if (IsContainerNode(nodeTag))
            {
                if (!node.IsExpanded)
                {
                    node.Expand();
                }
            }

            var stringLevel5 = GetStringLevel5FromNode(node);
            if (stringLevel5 == null)
            {
                // Disable and clear the editing controls when the selection isn't an editable text entry
                uiRichTextBox1.Enabled = false;
                uiRichTextBox1.Clear();
                uiUpDownTextBoxVarianceKey.Enabled = false;
                uiUpDownTextBoxVarianceKey.Text = "0";
                uiComboBoxCharacter.Enabled = false;

                if (uiPanelSettings != null)
                {
                    uiPanelSettings.Enabled = false;
                }
                return;
            }

            if (uiPanelSettings != null)
            {
                uiPanelSettings.Enabled = true;
            }

            // Enable and populate the editing controls with the selected node's data
            uiRichTextBox1.Enabled = true;
            uiRichTextBox1.Text = stringLevel5.Text;

            uiUpDownTextBoxVarianceKey.Enabled = true;
            uiUpDownTextBoxVarianceKey.Text = stringLevel5.VarianceKey.ToString();

            TreeNode keyNode = FindKeyNode(node);
            var parentIndex = HexToInt(keyNode.Name);
            var textConfig = Texts[parentIndex];

            if (_entryType != EntryType.Noun)
            {
                // Populate first: this also resolves the Enabled state based on whether any character was loaded
                PopulateCharacterComboBox();

                if (textConfig.WashaID != -1)
                {
                    ModelComboBox_SelectedIndex(uiComboBoxCharacter, textConfig.WashaID);
                }
                else if (uiComboBoxCharacter.Items.Count > 0)
                {
                    uiComboBoxCharacter.SelectedIndex = 0;
                }
            }
            else
            {
                uiComboBoxCharacter.Enabled = false;
            }

            PopulateSpeakerComboBox();
            UpdateSpeakerSelectionFromText(stringLevel5.Text);

            Focus();
            if (uiPanelSettings != null)
            {
                uiPanelSettings.Focus();
            }
        }

        private void InsertTextAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (IsItemNode(nodeTag))
            {
                string newText = Interaction.InputBox("Enter text:");
                if (string.IsNullOrEmpty(newText))
                {
                    SelectedRightClickTreeNode = null;
                    return;
                }

                TreeNode keyNode = FindKeyNode(selectedNode);
                if (keyNode != null)
                {
                    int parentIndex = HexToInt(keyNode.Name);

                    // In a nested structure, find the index of the base item node relative to the KeyNode
                    TreeNode topItemNode = selectedNode;
                    while (topItemNode.Parent != null && IsItemNode(topItemNode.Parent.Tag?.ToString()))
                    {
                        topItemNode = topItemNode.Parent;
                    }
                    int insertIndex = topItemNode.Index + 1;

                    var stringLevel5 = new StringLevel5(0, newText);
                    Texts[parentIndex].Strings.Insert(insertIndex, stringLevel5);
                    ReorganizeTextNumbers(parentIndex);

                    TreeNode newTreeNode = CreateNode(CleanTextForNode(newText), nodeTag, textItemContextMenuStrip, null, stringLevel5);
                    keyNode.Nodes.Insert(insertIndex, newTreeNode);
                }
            }

            SelectedRightClickTreeNode = null;
        }

        private void InsertTextBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var nodeTag = selectedNode.Tag?.ToString();

            if (IsItemNode(nodeTag))
            {
                string newText = Interaction.InputBox("Enter text:");
                if (string.IsNullOrEmpty(newText))
                {
                    SelectedRightClickTreeNode = null;
                    return;
                }

                TreeNode keyNode = FindKeyNode(selectedNode);
                if (keyNode != null)
                {
                    int parentIndex = HexToInt(keyNode.Name);

                    // In a nested structure, find the index of the base item node relative to the KeyNode
                    TreeNode topItemNode = selectedNode;
                    while (topItemNode.Parent != null && IsItemNode(topItemNode.Parent.Tag?.ToString()))
                    {
                        topItemNode = topItemNode.Parent;
                    }
                    int insertIndex = topItemNode.Index;

                    var stringLevel5 = new StringLevel5(0, newText);
                    Texts[parentIndex].Strings.Insert(insertIndex, stringLevel5);
                    ReorganizeTextNumbers(parentIndex);

                    TreeNode newTreeNode = CreateNode(CleanTextForNode(newText), nodeTag, textItemContextMenuStrip, null, stringLevel5);
                    keyNode.Nodes.Insert(insertIndex, newTreeNode);
                }
            }

            SelectedRightClickTreeNode = null;
        }

        private void InsertVarianceTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var parentString = GetStringLevel5FromNode(selectedNode);
            if (parentString == null)
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            TreeNode keyNode = FindKeyNode(selectedNode);
            if (keyNode == null)
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            string newText = Interaction.InputBox("Enter text:");
            if (string.IsNullOrEmpty(newText))
            {
                SelectedRightClickTreeNode = null;
                return;
            }

            int keyIndex = HexToInt(keyNode.Name);
            var existingStrings = Texts[keyIndex].Strings;

            // Find the lowest unused variance key strictly higher than the parent node's variance key
            int targetVarianceKey = parentString.VarianceKey + 1;
            while (existingStrings.Any(s => s.TextNumber == parentString.TextNumber && s.VarianceKey == targetVarianceKey))
            {
                targetVarianceKey++;
            }

            var newString = new StringLevel5(parentString.TextNumber, newText, targetVarianceKey);

            // Locate the position in the flat collection list to append the new variance under the same group
            int parentIndexInList = existingStrings.IndexOf(parentString);
            if (parentIndexInList != -1)
            {
                int insertPos = parentIndexInList;
                for (int i = parentIndexInList + 1; i < existingStrings.Count; i++)
                {
                    if (existingStrings[i].TextNumber == parentString.TextNumber)
                    {
                        insertPos = i;
                    }
                }
                existingStrings.Insert(insertPos + 1, newString);
            }
            else
            {
                existingStrings.Add(newString);
            }

            ReorganizeTextNumbers(keyIndex);

            // Locate or determine the base node at the root level of the text items
            TreeNode baseNode = selectedNode;
            while (baseNode.Parent != null && IsItemNode(baseNode.Parent.Tag?.ToString()))
            {
                baseNode = baseNode.Parent;
            }

            string itemTag = GetItemTagFromKeyTag(keyNode.Tag?.ToString());
            TreeNode newTreeNode = CreateNode(CleanTextForNode(newText), itemTag, textItemContextMenuStrip, null, newString);
            baseNode.Nodes.Add(newTreeNode);
            baseNode.Expand();

            SelectedRightClickTreeNode = null;
        }

        private void RemoveVarianceTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;
            var stringLevel5 = GetStringLevel5FromNode(selectedNode);

            if (stringLevel5 != null)
            {
                if (stringLevel5.VarianceKey == 0)
                {
                    MessageBox.Show("This is the base text. To delete it, please use 'Remove Text'.");
                    SelectedRightClickTreeNode = null;
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this variance entry?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    SelectedRightClickTreeNode = null;
                    return;
                }

                TreeNode keyNode = FindKeyNode(selectedNode);
                if (keyNode != null)
                {
                    int parentIndex = HexToInt(keyNode.Name);
                    Texts[parentIndex].Strings.Remove(stringLevel5);
                    ReorganizeTextNumbers(parentIndex);
                    selectedNode.Remove();
                }
            }

            SelectedRightClickTreeNode = null;
        }

        private void UiTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Sunny.UI.UITextBox searchBox = sender as Sunny.UI.UITextBox;
            string filterText = searchBox != null ? searchBox.Text : "";
            DrawTreeView(filterText);
        }

        private void UiComboBoxSpeaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBoxSpeaker == null || !uiComboBoxSpeaker.Focused || uiTreeViewText.SelectedNode == null) return;
            UpdateTextContentForSpeaker();
        }

        private void uiTreeViewText_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode draggedNode = e.Item as TreeNode;

                if (draggedNode != null && IsItemNode(draggedNode.Tag?.ToString()))
                {
                    // Block variance entries from being dragged
                    var stringLevel5 = GetStringLevel5FromNode(draggedNode);
                    if (stringLevel5 != null && stringLevel5.VarianceKey > 0)
                    {
                        return;
                    }

                    DoDragDrop(draggedNode, DragDropEffects.Move);
                }
            }
        }

        private void uiTreeViewText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void uiTreeViewText_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = uiTreeViewText.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = uiTreeViewText.GetNodeAt(targetPoint);

            if (targetNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (draggedNode == null || draggedNode == targetNode)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            string targetTag = targetNode.Tag?.ToString();

            if (IsItemNode(targetTag) || IsKeyNode(targetTag))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void uiTreeViewText_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TreeNode))) return;

            Point targetPoint = uiTreeViewText.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = uiTreeViewText.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (draggedNode == null || targetNode == null || draggedNode == targetNode) return;

            string targetTag = targetNode.Tag?.ToString();
            TreeNode targetKeyNode = null;
            int insertIndex = -1;

            if (IsKeyNode(targetTag))
            {
                targetKeyNode = targetNode;
                insertIndex = targetNode.Nodes.Count;
            }
            else if (IsItemNode(targetTag))
            {
                targetKeyNode = FindKeyNode(targetNode);

                // Resolve insertion relative to the top-level parent base node
                TreeNode topItemNode = targetNode;
                while (topItemNode.Parent != null && IsItemNode(topItemNode.Parent.Tag?.ToString()))
                {
                    topItemNode = topItemNode.Parent;
                }
                insertIndex = topItemNode != null ? topItemNode.Index : 0;
            }

            if (targetKeyNode == null) return;

            TreeNode sourceKeyNode = draggedNode.Parent;
            if (sourceKeyNode == null) return;

            int sourceKeyHex = HexToInt(sourceKeyNode.Name);
            int targetKeyHex = HexToInt(targetKeyNode.Name);

            if (!Texts.ContainsKey(sourceKeyHex) || !Texts.ContainsKey(targetKeyHex)) return;

            int sourceIndex = draggedNode.Index;
            var stringsListSource = Texts[sourceKeyHex].Strings;
            if (sourceIndex >= stringsListSource.Count) return;

            var stringToMove = stringsListSource[sourceIndex];

            if (sourceKeyHex == targetKeyHex)
            {
                if (sourceIndex < insertIndex)
                {
                    insertIndex--;
                }
            }

            stringsListSource.RemoveAt(sourceIndex);

            var stringsListTarget = Texts[targetKeyHex].Strings;
            if (insertIndex < 0) insertIndex = 0;
            if (insertIndex > stringsListTarget.Count) insertIndex = stringsListTarget.Count;

            stringsListTarget.Insert(insertIndex, stringToMove);

            ReorganizeTextNumbers(sourceKeyHex);
            if (sourceKeyHex != targetKeyHex)
            {
                ReorganizeTextNumbers(targetKeyHex);
            }

            draggedNode.Remove();
            targetKeyNode.Nodes.Insert(insertIndex, draggedNode);
            uiTreeViewText.SelectedNode = draggedNode;
        }

        private void UiTreeViewText_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode selectedNode = uiTreeViewText.SelectedNode;

                if (selectedNode != null)
                {
                    SelectedRightClickTreeNode = selectedNode;
                    ContextMenuStrip menu = GetContextMenuForNode(selectedNode);
                    if (menu != null)
                    {
                        menu.Show(uiTreeViewText, e.Location);
                    }
                }
            }
        }

        #endregion
    }
}