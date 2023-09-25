using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nyanko
{
    public partial class NyankoEditEntry : Form
    {
        public string EntryName { get; set; }

        public int SelectedEntryConfig { get; set; }

        public NyankoEditEntry(List<string> enntryConfigName, int index)
        {
            InitializeComponent();

            comboBox1.Items.AddRange(enntryConfigName.ToArray());
            comboBox1.SelectedIndex = index;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please put a name for the entry");
            }
            else
            {
                EntryName = textBox1.Text;
                SelectedEntryConfig = comboBox1.SelectedIndex;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
