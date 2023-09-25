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
using Nyanko.Tools;
using Nyanko.Level_5.Text;
using Nyanko.Level_5.Text.Type;

namespace Nyanko
{
    public partial class Nyanko : Form
    {
        private TextLevel5 FileText;

        private Dictionary<UInt32, string> FileKeys;

        public Nyanko()
        {
            InitializeComponent();
        }

        private UInt32 LittleEndian(string num)
        {
            UInt32 number = Convert.ToUInt32(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";

            foreach (byte b in bytes)
            {
                retval += b.ToString("X2");
            }
                
            return Convert.ToUInt32(retval, 16);
        }

        private void Nyanko_Load(object sender, EventArgs e)
        {
            if (File.Exists("./NyankoKey.txt")) 
            {
                FileKeys = new Dictionary<uint, string>();
                string[] keys = File.ReadAllLines("./NyankoKey.txt");

                for (int i = 0; i < keys.Length; i++)
                {
                    string[] elements = keys[i].Split('|');

                    if (elements[1] == "true")
                    {
                        FileKeys.Add(Convert.ToUInt32(elements[0], 16), elements[2]);
                    } else
                    {
                        FileKeys.Add(LittleEndian(elements[0]), elements[2]);
                    }
                }
            }
        }

        private void PrintFile()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < FileText.Entry.Count; i++)
            {
                string characterName = "";
                EntryConfig entryConfig = FileText.EntryConfig.Find(y => y.Crc32 == FileText.Entry[i].Crc32);
                EntryCharacter entryCharacter = FileText.EntryCharacter.Find(x => x.SubKey == entryConfig.SubKey);

                if (entryConfig != null && entryCharacter != null)
                {
                    if (FileKeys.ContainsKey(entryCharacter.CharacterID))
                    {
                        characterName = FileKeys[entryCharacter.CharacterID];
                    } else
                    {
                        characterName = entryCharacter.CharacterID.ToString("X8");
                    }
                }

                dataGridView1.Rows.Add(i, FileText.Entry[i].Text.Length, FileText.Entry[i].Crc32.ToString("X8"), characterName);
            }

            for (int i = 0; i < FileText.EntryConfig.Count; i++)
            {
                dataGridView2.Rows.Add(i, FileText.EntryConfig[i].Crc32.ToString("X8"), FileText.EntryConfig[i].SubKey.ToString("X8"));
            }

            for (int i = 0; i < FileText.EntryCharacter.Count; i++)
            {
                dataGridView3.Rows.Add(i, FileText.EntryCharacter[i].SubKey.ToString("X8"), FileText.EntryCharacter[i].CharacterID.ToString("X8"));
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Level 5 Text Bin files (*.bin)|*.bin";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileText = new TextLevel5(File.ReadAllBytes(openFileDialog1.FileName));
                PrintFile();
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count == 0) return;

            //listView2.Items.Clear();

            textBox1.Clear();
            textBox1.Enabled = false;

            //for (int i = 0; i < FileLoaded.CountTextWithSameKey(Convert.ToUInt32(listView1.SelectedItems[0].Text, 16)); i++)
            //{
                //listView2.Items.Add("Text " + i, 0);
                //listView2.Items[listView2.Items.Count - 1].ImageIndex = 1;
            //}
        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView2.SelectedItems.Count == 0) return;

            //textBox1.Text = FileLoaded.GetLongText(Convert.ToUInt32(listView1.SelectedItems[0].Text, 16), listView2.Items.IndexOf(listView2.SelectedItems[0]));
            textBox1.Enabled = true;
        }

        private void AddNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new NyankoNewEntry())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UInt32 key = BitConverter.ToUInt32(new Crc32().ComputeHash(Encoding.UTF8.GetBytes(form.Key)), 0);

                    if (FileText.KeyExist(key))
                    {
                        MessageBox.Show("La clef existe déjà");
                    } else
                    {
                        MessageBox.Show("Nouvelle clef ajouté");
                        FileText.AddLongText(key, "");
                        PrintFile();
                    }
                }
            }
        }

        private void AddNewTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count == 0) return;

            //FileLoaded.AddLongText(Convert.ToUInt32(listView1.SelectedItems[0].Text, 16), "");
            PrintFile();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Focused) return;

            //FileLoaded.UpDateLongText(Convert.ToUInt32(listView1.SelectedItems[0].Text, 16), listView2.Items.IndexOf(listView2.SelectedItems[0]), textBox1.Text);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Level 5 Text Bin files (*.bin)|*.bin";
            saveFileDialog.InitialDirectory = openFileDialog1.InitialDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, FileText.Save());
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = FileText.GetEntryByIndex(e.RowIndex).Text.Replace("\\n", Environment.NewLine);
            textBox1.Enabled = true;
        }

        private void EditEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RemoveEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Clear();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
        }

        private void AddNewEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
