using System;
using System.Windows.Forms;

namespace Nyanko
{
    public partial class NyankoNewEntry : Form
    {
        public string Key { get; set; }

        public NyankoNewEntry()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please put a name for the key");
            }
            else
            {
                Key = textBox1.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
