using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Sunny.UI;

namespace Nyanko.Forms
{
    public partial class GenerateCRC32Window : UIForm
    {
        public Dictionary<int, string> GeneratedKeys { get; private set; }

        public GenerateCRC32Window()
        {
            InitializeComponent();
            GeneratedKeys = new Dictionary<int, string>();


            if (this.uiPanelHeader != null)
            {
                this.uiPanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UiPanelHeader_MouseDown);
            }
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

        private void GenerateKeys()
        {
            GeneratedKeys.Clear();

            // Safely parse textbox strings to integer values
            if (!int.TryParse(uiUpDownTextBoxMin.Text, out int min) ||
                !int.TryParse(uiUpDownTextBoxMax.Text, out int max) ||
                !int.TryParse(uiUpDownTextBoxStep.Text, out int step) ||
                !int.TryParse(uiUpDownTextBoxPadding.Text, out int padding))
            {
                UIMessageBox.ShowError("Please ensure all numeric fields contain valid integers.");
                return;
            }

            // Prevent infinite loops if step is configured incorrectly
            if (step <= 0)
            {
                UIMessageBox.ShowError("Step value must be greater than zero.");
                return;
            }

            string prefix = uiTextBoxPrefix.Text ?? string.Empty;
            string suffix = uiTextBoxSuffix.Text ?? string.Empty;

            for (int id = min; id <= max; id += step)
            {
                // Format the ID with the specified padding (e.g., D4 for 0001)
                string formattedId = id.ToString("D" + padding);
                string combinedText = prefix + formattedId + suffix;

                // Compute CRC32 hash value
                byte[] textBytes = Encoding.UTF8.GetBytes(combinedText);
                int crc32Key = unchecked((int)StudioElevenLib.Tools.Crc32.Compute(textBytes));

                // Add the computed CRC32 and the generated text to the dictionary
                GeneratedKeys[crc32Key] = combinedText;
            }
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

        private void UiSymbolButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UiButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UiButtonConfirm_Click(object sender, EventArgs e)
        {
            GenerateKeys();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}