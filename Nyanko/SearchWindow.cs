using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nyanko
{
    public partial class SearchWindow : Form
    {
        public TreeView NyankoTreeView;

        public SearchWindow(TreeView treeview)
        {
            InitializeComponent();

            NyankoTreeView = treeview;
        }

        private void SearchTreeView(TreeNodeCollection nodes, string searchText)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.ToLower().Contains(searchText) && (node.Tag as string).Contains("Item"))
                {
                    foundListBox.Items.Add(new NodeFound(node));
                }

                if (node.Nodes.Count > 0)
                {
                    SearchTreeView(node.Nodes, searchText);
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchedText = searchedTextBox.Text.ToLower();
            foundListBox.Items.Clear();

            SearchTreeView(NyankoTreeView.Nodes, searchedText);
        }

        private void SearchedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchedText = searchedTextBox.Text.ToLower();
                foundListBox.Items.Clear();

                SearchTreeView(NyankoTreeView.Nodes, searchedText);
            }
        }

        private void FoundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode selectedNode = (foundListBox.SelectedItem as NodeFound).Node;

            if (selectedNode != null)
            {
                selectedNode.EnsureVisible();
                NyankoTreeView.SelectedNode = selectedNode;
            }
        }
    }

    public class NodeFound
    {
        public TreeNode Node { get; set; }

        public NodeFound(TreeNode node)
        {
            Node = node;
        }

        public override string ToString()
        {
            string type;

            if ((Node.Tag as string) == "NounItem")
            {
                type = "Noun";
            }
            else
            {
                type = "Text";
            }

            return $"{type} - {Node.Text}";
        }
    }
}
