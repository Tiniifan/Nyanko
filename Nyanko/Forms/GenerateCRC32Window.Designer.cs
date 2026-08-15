namespace Nyanko.Forms
{
    partial class GenerateCRC32Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanelHeader = new Sunny.UI.UIPanel();
            this.uiSymbolButtonClose = new Sunny.UI.UISymbolButton();
            this.uiPanelContent = new Sunny.UI.UIPanel();
            this.uiPanelStep = new Sunny.UI.UIPanel();
            this.uiLabelStep = new Sunny.UI.UILabel();
            this.uiLabelPadding = new Sunny.UI.UILabel();
            this.uiUpDownTextBoxPadding = new Sunny.UI.UIUpDownTextBox();
            this.uiUpDownTextBoxStep = new Sunny.UI.UIUpDownTextBox();
            this.uiPanelBottom = new Sunny.UI.UIPanel();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiButtonConfirm = new Sunny.UI.UIButton();
            this.uiPanelRange = new Sunny.UI.UIPanel();
            this.uiUpDownTextBoxMax = new Sunny.UI.UIUpDownTextBox();
            this.uiLabelMax = new Sunny.UI.UILabel();
            this.uiUpDownTextBoxMin = new Sunny.UI.UIUpDownTextBox();
            this.uiLabelMin = new Sunny.UI.UILabel();
            this.uiPanelSuffix = new Sunny.UI.UIPanel();
            this.uiTextBoxSuffix = new Sunny.UI.UITextBox();
            this.uiLabelSuffix = new Sunny.UI.UILabel();
            this.uiPanelPrefix = new Sunny.UI.UIPanel();
            this.uiTextBoxPrefix = new Sunny.UI.UITextBox();
            this.uiLabelPrefix = new Sunny.UI.UILabel();
            this.uiPanelHeader.SuspendLayout();
            this.uiPanelContent.SuspendLayout();
            this.uiPanelStep.SuspendLayout();
            this.uiPanelBottom.SuspendLayout();
            this.uiPanelRange.SuspendLayout();
            this.uiPanelSuffix.SuspendLayout();
            this.uiPanelPrefix.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelHeader
            // 
            this.uiPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.uiPanelHeader.Controls.Add(this.uiSymbolButtonClose);
            this.uiPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.uiPanelHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiPanelHeader.ForeColor = System.Drawing.Color.Black;
            this.uiPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.uiPanelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelHeader.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelHeader.Name = "uiPanelHeader";
            this.uiPanelHeader.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelHeader.Size = new System.Drawing.Size(504, 40);
            this.uiPanelHeader.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanelHeader.TabIndex = 10;
            this.uiPanelHeader.Text = "Generate CRC32";
            this.uiPanelHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButtonClose
            // 
            this.uiSymbolButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButtonClose.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolButtonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiSymbolButtonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiSymbolButtonClose.ForeHoverColor = System.Drawing.Color.Red;
            this.uiSymbolButtonClose.Location = new System.Drawing.Point(464, 0);
            this.uiSymbolButtonClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonClose.Name = "uiSymbolButtonClose";
            this.uiSymbolButtonClose.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButtonClose.Size = new System.Drawing.Size(40, 40);
            this.uiSymbolButtonClose.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonClose.Symbol = 0;
            this.uiSymbolButtonClose.TabIndex = 1;
            this.uiSymbolButtonClose.Text = "X";
            this.uiSymbolButtonClose.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButtonClose.Click += new System.EventHandler(this.UiSymbolButtonClose_Click);
            // 
            // uiPanelContent
            // 
            this.uiPanelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelContent.Controls.Add(this.uiPanelStep);
            this.uiPanelContent.Controls.Add(this.uiPanelBottom);
            this.uiPanelContent.Controls.Add(this.uiPanelRange);
            this.uiPanelContent.Controls.Add(this.uiPanelSuffix);
            this.uiPanelContent.Controls.Add(this.uiPanelPrefix);
            this.uiPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelContent.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelContent.Location = new System.Drawing.Point(0, 40);
            this.uiPanelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelContent.Name = "uiPanelContent";
            this.uiPanelContent.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelContent.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelContent.Size = new System.Drawing.Size(504, 205);
            this.uiPanelContent.TabIndex = 13;
            this.uiPanelContent.Text = null;
            this.uiPanelContent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelStep
            // 
            this.uiPanelStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelStep.Controls.Add(this.uiLabelStep);
            this.uiPanelStep.Controls.Add(this.uiLabelPadding);
            this.uiPanelStep.Controls.Add(this.uiUpDownTextBoxPadding);
            this.uiPanelStep.Controls.Add(this.uiUpDownTextBoxStep);
            this.uiPanelStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelStep.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelStep.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelStep.Location = new System.Drawing.Point(0, 120);
            this.uiPanelStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelStep.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelStep.Name = "uiPanelStep";
            this.uiPanelStep.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelStep.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelStep.Size = new System.Drawing.Size(504, 40);
            this.uiPanelStep.TabIndex = 17;
            this.uiPanelStep.Text = null;
            this.uiPanelStep.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabelStep
            // 
            this.uiLabelStep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelStep.Location = new System.Drawing.Point(12, 5);
            this.uiLabelStep.Name = "uiLabelStep";
            this.uiLabelStep.Size = new System.Drawing.Size(61, 23);
            this.uiLabelStep.TabIndex = 7;
            this.uiLabelStep.Text = "Step";
            // 
            // uiLabelPadding
            // 
            this.uiLabelPadding.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelPadding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelPadding.Location = new System.Drawing.Point(259, 5);
            this.uiLabelPadding.Name = "uiLabelPadding";
            this.uiLabelPadding.Size = new System.Drawing.Size(62, 23);
            this.uiLabelPadding.TabIndex = 9;
            this.uiLabelPadding.Text = "Padding";
            // 
            // uiUpDownTextBoxPadding
            // 
            this.uiUpDownTextBoxPadding.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiUpDownTextBoxPadding.DoubleStep = 1D;
            this.uiUpDownTextBoxPadding.DoubleValue = 1D;
            this.uiUpDownTextBoxPadding.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiUpDownTextBoxPadding.IntValue = 1;
            this.uiUpDownTextBoxPadding.Location = new System.Drawing.Point(328, 2);
            this.uiUpDownTextBoxPadding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiUpDownTextBoxPadding.Maximum = 10D;
            this.uiUpDownTextBoxPadding.Minimum = 1D;
            this.uiUpDownTextBoxPadding.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiUpDownTextBoxPadding.Name = "uiUpDownTextBoxPadding";
            this.uiUpDownTextBoxPadding.Padding = new System.Windows.Forms.Padding(5);
            this.uiUpDownTextBoxPadding.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiUpDownTextBoxPadding.ShowText = false;
            this.uiUpDownTextBoxPadding.Size = new System.Drawing.Size(160, 26);
            this.uiUpDownTextBoxPadding.TabIndex = 10;
            this.uiUpDownTextBoxPadding.Text = "1";
            this.uiUpDownTextBoxPadding.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiUpDownTextBoxPadding.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiUpDownTextBoxPadding.Watermark = "";
            // 
            // uiUpDownTextBoxStep
            // 
            this.uiUpDownTextBoxStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiUpDownTextBoxStep.DoubleStep = 1D;
            this.uiUpDownTextBoxStep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiUpDownTextBoxStep.Location = new System.Drawing.Point(80, 2);
            this.uiUpDownTextBoxStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiUpDownTextBoxStep.Minimum = 0D;
            this.uiUpDownTextBoxStep.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiUpDownTextBoxStep.Name = "uiUpDownTextBoxStep";
            this.uiUpDownTextBoxStep.Padding = new System.Windows.Forms.Padding(5);
            this.uiUpDownTextBoxStep.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiUpDownTextBoxStep.ShowText = false;
            this.uiUpDownTextBoxStep.Size = new System.Drawing.Size(160, 26);
            this.uiUpDownTextBoxStep.TabIndex = 8;
            this.uiUpDownTextBoxStep.Text = "0";
            this.uiUpDownTextBoxStep.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiUpDownTextBoxStep.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiUpDownTextBoxStep.Watermark = "";
            // 
            // uiPanelBottom
            // 
            this.uiPanelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelBottom.Controls.Add(this.uiButtonCancel);
            this.uiPanelBottom.Controls.Add(this.uiButtonConfirm);
            this.uiPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanelBottom.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelBottom.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelBottom.Location = new System.Drawing.Point(0, 165);
            this.uiPanelBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelBottom.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelBottom.Name = "uiPanelBottom";
            this.uiPanelBottom.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelBottom.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelBottom.Size = new System.Drawing.Size(504, 40);
            this.uiPanelBottom.TabIndex = 16;
            this.uiPanelBottom.Text = null;
            this.uiPanelBottom.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FillColor = System.Drawing.Color.White;
            this.uiButtonCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiButtonCancel.ForeColor = System.Drawing.Color.Black;
            this.uiButtonCancel.Location = new System.Drawing.Point(134, 6);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.uiButtonCancel.Size = new System.Drawing.Size(100, 26);
            this.uiButtonCancel.TabIndex = 1;
            this.uiButtonCancel.Text = "Cancel";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButtonCancel.Click += new System.EventHandler(this.UiButtonCancel_Click);
            // 
            // uiButtonConfirm
            // 
            this.uiButtonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiButtonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonConfirm.FillColor = System.Drawing.Color.White;
            this.uiButtonConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiButtonConfirm.ForeColor = System.Drawing.Color.Black;
            this.uiButtonConfirm.Location = new System.Drawing.Point(16, 6);
            this.uiButtonConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonConfirm.Name = "uiButtonConfirm";
            this.uiButtonConfirm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.uiButtonConfirm.Size = new System.Drawing.Size(100, 26);
            this.uiButtonConfirm.TabIndex = 0;
            this.uiButtonConfirm.Text = "Generate";
            this.uiButtonConfirm.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButtonConfirm.Click += new System.EventHandler(this.UiButtonConfirm_Click);
            // 
            // uiPanelRange
            // 
            this.uiPanelRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelRange.Controls.Add(this.uiUpDownTextBoxMax);
            this.uiPanelRange.Controls.Add(this.uiLabelMax);
            this.uiPanelRange.Controls.Add(this.uiUpDownTextBoxMin);
            this.uiPanelRange.Controls.Add(this.uiLabelMin);
            this.uiPanelRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelRange.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelRange.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelRange.Location = new System.Drawing.Point(0, 80);
            this.uiPanelRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelRange.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelRange.Name = "uiPanelRange";
            this.uiPanelRange.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelRange.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelRange.Size = new System.Drawing.Size(504, 40);
            this.uiPanelRange.TabIndex = 15;
            this.uiPanelRange.Text = null;
            this.uiPanelRange.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiUpDownTextBoxMax
            // 
            this.uiUpDownTextBoxMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiUpDownTextBoxMax.DoubleStep = 1D;
            this.uiUpDownTextBoxMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiUpDownTextBoxMax.Location = new System.Drawing.Point(328, 3);
            this.uiUpDownTextBoxMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiUpDownTextBoxMax.Minimum = 0D;
            this.uiUpDownTextBoxMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiUpDownTextBoxMax.Name = "uiUpDownTextBoxMax";
            this.uiUpDownTextBoxMax.Padding = new System.Windows.Forms.Padding(5);
            this.uiUpDownTextBoxMax.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiUpDownTextBoxMax.ShowText = false;
            this.uiUpDownTextBoxMax.Size = new System.Drawing.Size(160, 26);
            this.uiUpDownTextBoxMax.TabIndex = 6;
            this.uiUpDownTextBoxMax.Text = "0";
            this.uiUpDownTextBoxMax.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiUpDownTextBoxMax.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiUpDownTextBoxMax.Watermark = "";
            // 
            // uiLabelMax
            // 
            this.uiLabelMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelMax.Location = new System.Drawing.Point(259, 5);
            this.uiLabelMax.Name = "uiLabelMax";
            this.uiLabelMax.Size = new System.Drawing.Size(61, 23);
            this.uiLabelMax.TabIndex = 5;
            this.uiLabelMax.Text = "Max";
            // 
            // uiUpDownTextBoxMin
            // 
            this.uiUpDownTextBoxMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiUpDownTextBoxMin.DoubleStep = 1D;
            this.uiUpDownTextBoxMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiUpDownTextBoxMin.Location = new System.Drawing.Point(80, 3);
            this.uiUpDownTextBoxMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiUpDownTextBoxMin.Minimum = 0D;
            this.uiUpDownTextBoxMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiUpDownTextBoxMin.Name = "uiUpDownTextBoxMin";
            this.uiUpDownTextBoxMin.Padding = new System.Windows.Forms.Padding(5);
            this.uiUpDownTextBoxMin.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiUpDownTextBoxMin.ShowText = false;
            this.uiUpDownTextBoxMin.Size = new System.Drawing.Size(160, 26);
            this.uiUpDownTextBoxMin.TabIndex = 4;
            this.uiUpDownTextBoxMin.Text = "0";
            this.uiUpDownTextBoxMin.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiUpDownTextBoxMin.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiUpDownTextBoxMin.Watermark = "";
            // 
            // uiLabelMin
            // 
            this.uiLabelMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelMin.Location = new System.Drawing.Point(12, 5);
            this.uiLabelMin.Name = "uiLabelMin";
            this.uiLabelMin.Size = new System.Drawing.Size(61, 23);
            this.uiLabelMin.TabIndex = 0;
            this.uiLabelMin.Text = "Min";
            // 
            // uiPanelSuffix
            // 
            this.uiPanelSuffix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelSuffix.Controls.Add(this.uiTextBoxSuffix);
            this.uiPanelSuffix.Controls.Add(this.uiLabelSuffix);
            this.uiPanelSuffix.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelSuffix.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelSuffix.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelSuffix.Location = new System.Drawing.Point(0, 40);
            this.uiPanelSuffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelSuffix.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelSuffix.Name = "uiPanelSuffix";
            this.uiPanelSuffix.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelSuffix.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelSuffix.Size = new System.Drawing.Size(504, 40);
            this.uiPanelSuffix.TabIndex = 14;
            this.uiPanelSuffix.Text = null;
            this.uiPanelSuffix.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBoxSuffix
            // 
            this.uiTextBoxSuffix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxSuffix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxSuffix.Location = new System.Drawing.Point(80, 7);
            this.uiTextBoxSuffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxSuffix.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxSuffix.Name = "uiTextBoxSuffix";
            this.uiTextBoxSuffix.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxSuffix.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiTextBoxSuffix.ShowText = false;
            this.uiTextBoxSuffix.Size = new System.Drawing.Size(408, 26);
            this.uiTextBoxSuffix.TabIndex = 1;
            this.uiTextBoxSuffix.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxSuffix.Watermark = "";
            // 
            // uiLabelSuffix
            // 
            this.uiLabelSuffix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelSuffix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelSuffix.Location = new System.Drawing.Point(12, 11);
            this.uiLabelSuffix.Name = "uiLabelSuffix";
            this.uiLabelSuffix.Size = new System.Drawing.Size(61, 23);
            this.uiLabelSuffix.TabIndex = 0;
            this.uiLabelSuffix.Text = "Suffix";
            // 
            // uiPanelPrefix
            // 
            this.uiPanelPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiPanelPrefix.Controls.Add(this.uiTextBoxPrefix);
            this.uiPanelPrefix.Controls.Add(this.uiLabelPrefix);
            this.uiPanelPrefix.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelPrefix.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelPrefix.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.uiPanelPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanelPrefix.Location = new System.Drawing.Point(0, 0);
            this.uiPanelPrefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelPrefix.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelPrefix.Name = "uiPanelPrefix";
            this.uiPanelPrefix.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelPrefix.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanelPrefix.Size = new System.Drawing.Size(504, 40);
            this.uiPanelPrefix.TabIndex = 13;
            this.uiPanelPrefix.Text = null;
            this.uiPanelPrefix.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBoxPrefix
            // 
            this.uiTextBoxPrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxPrefix.Location = new System.Drawing.Point(80, 7);
            this.uiTextBoxPrefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxPrefix.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxPrefix.Name = "uiTextBoxPrefix";
            this.uiTextBoxPrefix.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxPrefix.RectColor = System.Drawing.SystemColors.ControlDark;
            this.uiTextBoxPrefix.ShowText = false;
            this.uiTextBoxPrefix.Size = new System.Drawing.Size(408, 26);
            this.uiTextBoxPrefix.TabIndex = 1;
            this.uiTextBoxPrefix.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxPrefix.Watermark = "";
            // 
            // uiLabelPrefix
            // 
            this.uiLabelPrefix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabelPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelPrefix.Location = new System.Drawing.Point(12, 11);
            this.uiLabelPrefix.Name = "uiLabelPrefix";
            this.uiLabelPrefix.Size = new System.Drawing.Size(61, 23);
            this.uiLabelPrefix.TabIndex = 0;
            this.uiLabelPrefix.Text = "Prefix";
            // 
            // GenerateCRC32Window
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(504, 245);
            this.Controls.Add(this.uiPanelContent);
            this.Controls.Add(this.uiPanelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "GenerateCRC32Window";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ShowInTaskbar = false;
            this.ShowTitle = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "GenerateCRC32Window";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.uiPanelHeader.ResumeLayout(false);
            this.uiPanelContent.ResumeLayout(false);
            this.uiPanelStep.ResumeLayout(false);
            this.uiPanelBottom.ResumeLayout(false);
            this.uiPanelRange.ResumeLayout(false);
            this.uiPanelSuffix.ResumeLayout(false);
            this.uiPanelPrefix.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanelHeader;
        private Sunny.UI.UISymbolButton uiSymbolButtonClose;
        private Sunny.UI.UIPanel uiPanelContent;
        private Sunny.UI.UIPanel uiPanelSuffix;
        private Sunny.UI.UITextBox uiTextBoxSuffix;
        private Sunny.UI.UILabel uiLabelSuffix;
        private Sunny.UI.UIPanel uiPanelPrefix;
        private Sunny.UI.UITextBox uiTextBoxPrefix;
        private Sunny.UI.UILabel uiLabelPrefix;
        private Sunny.UI.UIPanel uiPanelRange;
        private Sunny.UI.UILabel uiLabelMin;
        private Sunny.UI.UIUpDownTextBox uiUpDownTextBoxMin;
        private Sunny.UI.UIUpDownTextBox uiUpDownTextBoxStep;
        private Sunny.UI.UILabel uiLabelStep;
        private Sunny.UI.UIUpDownTextBox uiUpDownTextBoxMax;
        private Sunny.UI.UILabel uiLabelMax;
        private Sunny.UI.UIPanel uiPanelBottom;
        private Sunny.UI.UIButton uiButtonConfirm;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UIUpDownTextBox uiUpDownTextBoxPadding;
        private Sunny.UI.UILabel uiLabelPadding;
        private Sunny.UI.UIPanel uiPanelStep;
    }
}