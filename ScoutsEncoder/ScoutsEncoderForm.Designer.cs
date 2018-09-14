namespace ScoutsEncoder
{
    partial class ScoutsEncoderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoutsEncoderForm));
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.InputClear = new System.Windows.Forms.Button();
            this.InputPaste = new System.Windows.Forms.Button();
            this.InputCut = new System.Windows.Forms.Button();
            this.InputCopy = new System.Windows.Forms.Button();
            this.InputTools = new System.Windows.Forms.Panel();
            this.OutputTools = new System.Windows.Forms.Panel();
            this.OutputCopy = new System.Windows.Forms.Button();
            this.OutputCut = new System.Windows.Forms.Button();
            this.OutputPaste = new System.Windows.Forms.Button();
            this.OutputClear = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.Panel();
            this.OutputOptions = new System.Windows.Forms.Label();
            this.WordsSpacing = new System.Windows.Forms.CheckBox();
            this.CharsSpacing = new System.Windows.Forms.CheckBox();
            this.Slashes = new System.Windows.Forms.CheckBox();
            this.Dashes = new System.Windows.Forms.CheckBox();
            this.ShowKeyButton = new System.Windows.Forms.Button();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Panel();
            this.Version = new System.Windows.Forms.Label();
            this.ScoutsEncoder = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SideMenu = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DropdownPanel = new System.Windows.Forms.Panel();
            this.SetCodeButton = new System.Windows.Forms.Button();
            this.UpperBorder = new System.Windows.Forms.Panel();
            this.MiddleBorder = new System.Windows.Forms.Panel();
            this.BottomBorder = new System.Windows.Forms.Panel();
            this.RightBorder = new System.Windows.Forms.Panel();
            this.LeftBorder = new System.Windows.Forms.Panel();
            this.CodesComboBox = new System.Windows.Forms.ComboBox();
            this.KeysComboBox = new System.Windows.Forms.ComboBox();
            this.ThemeButton = new System.Windows.Forms.Button();
            this.DropdownTimer = new System.Windows.Forms.Timer(this.components);
            this.InputTools.SuspendLayout();
            this.OutputTools.SuspendLayout();
            this.Options.SuspendLayout();
            this.Title.SuspendLayout();
            this.SideMenu.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.DropdownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.AcceptsReturn = true;
            this.InputTextBox.AllowDrop = true;
            this.InputTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputTextBox.Font = new System.Drawing.Font("Kawkab Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.InputTextBox.ForeColor = System.Drawing.Color.Black;
            this.InputTextBox.Location = new System.Drawing.Point(66, 20);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InputTextBox.Size = new System.Drawing.Size(714, 331);
            this.InputTextBox.TabIndex = 1;
            this.InputTextBox.Text = "ادخل الشفرة هنا...";
            this.InputTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this.InputTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.AcceptsReturn = true;
            this.OutputTextBox.AllowDrop = true;
            this.OutputTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputTextBox.Font = new System.Drawing.Font("Kawkab Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OutputTextBox.ForeColor = System.Drawing.Color.Black;
            this.OutputTextBox.Location = new System.Drawing.Point(66, 370);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OutputTextBox.Size = new System.Drawing.Size(714, 331);
            this.OutputTextBox.TabIndex = 2;
            // 
            // InputClear
            // 
            this.InputClear.BackColor = System.Drawing.Color.Transparent;
            this.InputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            this.InputClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputClear.FlatAppearance.BorderSize = 0;
            this.InputClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputClear.Location = new System.Drawing.Point(10, 112);
            this.InputClear.Name = "InputClear";
            this.InputClear.Size = new System.Drawing.Size(25, 25);
            this.InputClear.TabIndex = 16;
            this.InputClear.UseVisualStyleBackColor = false;
            this.InputClear.Click += new System.EventHandler(this.InputClear_Click);
            // 
            // InputPaste
            // 
            this.InputPaste.BackColor = System.Drawing.Color.Transparent;
            this.InputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Paste;
            this.InputPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputPaste.FlatAppearance.BorderSize = 0;
            this.InputPaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputPaste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputPaste.Location = new System.Drawing.Point(10, 79);
            this.InputPaste.Name = "InputPaste";
            this.InputPaste.Size = new System.Drawing.Size(25, 25);
            this.InputPaste.TabIndex = 15;
            this.InputPaste.UseVisualStyleBackColor = false;
            this.InputPaste.Click += new System.EventHandler(this.InputPaste_Click);
            // 
            // InputCut
            // 
            this.InputCut.BackColor = System.Drawing.Color.Transparent;
            this.InputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Cut;
            this.InputCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputCut.FlatAppearance.BorderSize = 0;
            this.InputCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputCut.Location = new System.Drawing.Point(10, 46);
            this.InputCut.Name = "InputCut";
            this.InputCut.Size = new System.Drawing.Size(25, 25);
            this.InputCut.TabIndex = 14;
            this.InputCut.UseVisualStyleBackColor = false;
            this.InputCut.Click += new System.EventHandler(this.InputCut_Click);
            // 
            // InputCopy
            // 
            this.InputCopy.BackColor = System.Drawing.Color.Transparent;
            this.InputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Copy;
            this.InputCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputCopy.FlatAppearance.BorderSize = 0;
            this.InputCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputCopy.Location = new System.Drawing.Point(10, 13);
            this.InputCopy.Name = "InputCopy";
            this.InputCopy.Size = new System.Drawing.Size(25, 25);
            this.InputCopy.TabIndex = 13;
            this.InputCopy.UseVisualStyleBackColor = false;
            this.InputCopy.Click += new System.EventHandler(this.InputCopy_Click);
            // 
            // InputTools
            // 
            this.InputTools.Controls.Add(this.InputCopy);
            this.InputTools.Controls.Add(this.InputCut);
            this.InputTools.Controls.Add(this.InputPaste);
            this.InputTools.Controls.Add(this.InputClear);
            this.InputTools.Location = new System.Drawing.Point(12, 101);
            this.InputTools.Name = "InputTools";
            this.InputTools.Size = new System.Drawing.Size(48, 156);
            this.InputTools.TabIndex = 3;
            // 
            // OutputTools
            // 
            this.OutputTools.Controls.Add(this.OutputCopy);
            this.OutputTools.Controls.Add(this.OutputCut);
            this.OutputTools.Controls.Add(this.OutputPaste);
            this.OutputTools.Controls.Add(this.OutputClear);
            this.OutputTools.Location = new System.Drawing.Point(12, 451);
            this.OutputTools.Name = "OutputTools";
            this.OutputTools.Size = new System.Drawing.Size(48, 156);
            this.OutputTools.TabIndex = 4;
            // 
            // OutputCopy
            // 
            this.OutputCopy.BackColor = System.Drawing.Color.Transparent;
            this.OutputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Copy;
            this.OutputCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputCopy.FlatAppearance.BorderSize = 0;
            this.OutputCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputCopy.Location = new System.Drawing.Point(10, 13);
            this.OutputCopy.Name = "OutputCopy";
            this.OutputCopy.Size = new System.Drawing.Size(25, 25);
            this.OutputCopy.TabIndex = 13;
            this.OutputCopy.UseVisualStyleBackColor = false;
            this.OutputCopy.Click += new System.EventHandler(this.OutputCopy_Click);
            // 
            // OutputCut
            // 
            this.OutputCut.BackColor = System.Drawing.Color.Transparent;
            this.OutputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Cut;
            this.OutputCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputCut.FlatAppearance.BorderSize = 0;
            this.OutputCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputCut.Location = new System.Drawing.Point(10, 46);
            this.OutputCut.Name = "OutputCut";
            this.OutputCut.Size = new System.Drawing.Size(25, 25);
            this.OutputCut.TabIndex = 14;
            this.OutputCut.UseVisualStyleBackColor = false;
            this.OutputCut.Click += new System.EventHandler(this.OutputCut_Click);
            // 
            // OutputPaste
            // 
            this.OutputPaste.BackColor = System.Drawing.Color.Transparent;
            this.OutputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Paste;
            this.OutputPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputPaste.FlatAppearance.BorderSize = 0;
            this.OutputPaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputPaste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputPaste.Location = new System.Drawing.Point(10, 79);
            this.OutputPaste.Name = "OutputPaste";
            this.OutputPaste.Size = new System.Drawing.Size(25, 25);
            this.OutputPaste.TabIndex = 15;
            this.OutputPaste.UseVisualStyleBackColor = false;
            this.OutputPaste.Click += new System.EventHandler(this.OutputPaste_Click);
            // 
            // OutputClear
            // 
            this.OutputClear.BackColor = System.Drawing.Color.Transparent;
            this.OutputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            this.OutputClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputClear.FlatAppearance.BorderSize = 0;
            this.OutputClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputClear.Location = new System.Drawing.Point(10, 112);
            this.OutputClear.Name = "OutputClear";
            this.OutputClear.Size = new System.Drawing.Size(25, 25);
            this.OutputClear.TabIndex = 16;
            this.OutputClear.UseVisualStyleBackColor = false;
            this.OutputClear.Click += new System.EventHandler(this.OutputClear_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReportButton.FlatAppearance.BorderSize = 0;
            this.ReportButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.ReportButton.ForeColor = System.Drawing.Color.Black;
            this.ReportButton.Location = new System.Drawing.Point(50, 680);
            this.ReportButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(180, 60);
            this.ReportButton.TabIndex = 20;
            this.ReportButton.Text = "الإبلاغ عن خطأ";
            this.ReportButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.LightGray;
            this.Options.Controls.Add(this.OutputOptions);
            this.Options.Controls.Add(this.WordsSpacing);
            this.Options.Controls.Add(this.CharsSpacing);
            this.Options.Controls.Add(this.Slashes);
            this.Options.Controls.Add(this.Dashes);
            this.Options.Location = new System.Drawing.Point(0, 371);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(280, 157);
            this.Options.TabIndex = 22;
            // 
            // OutputOptions
            // 
            this.OutputOptions.AutoSize = true;
            this.OutputOptions.BackColor = System.Drawing.Color.Transparent;
            this.OutputOptions.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.OutputOptions.ForeColor = System.Drawing.Color.Black;
            this.OutputOptions.Location = new System.Drawing.Point(36, 11);
            this.OutputOptions.Name = "OutputOptions";
            this.OutputOptions.Size = new System.Drawing.Size(114, 29);
            this.OutputOptions.TabIndex = 23;
            this.OutputOptions.Text = "Output Options:";
            // 
            // WordsSpacing
            // 
            this.WordsSpacing.AutoSize = true;
            this.WordsSpacing.BackColor = System.Drawing.Color.Transparent;
            this.WordsSpacing.Checked = true;
            this.WordsSpacing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordsSpacing.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordsSpacing.ForeColor = System.Drawing.Color.Black;
            this.WordsSpacing.Location = new System.Drawing.Point(18, 105);
            this.WordsSpacing.Name = "WordsSpacing";
            this.WordsSpacing.Size = new System.Drawing.Size(132, 33);
            this.WordsSpacing.TabIndex = 11;
            this.WordsSpacing.Text = "Words Spacing";
            this.WordsSpacing.UseVisualStyleBackColor = false;
            this.WordsSpacing.CheckedChanged += new System.EventHandler(this.WordsSpacing_CheckedChanged);
            // 
            // CharsSpacing
            // 
            this.CharsSpacing.AutoSize = true;
            this.CharsSpacing.BackColor = System.Drawing.Color.Transparent;
            this.CharsSpacing.Checked = true;
            this.CharsSpacing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CharsSpacing.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharsSpacing.ForeColor = System.Drawing.Color.Black;
            this.CharsSpacing.Location = new System.Drawing.Point(18, 81);
            this.CharsSpacing.Name = "CharsSpacing";
            this.CharsSpacing.Size = new System.Drawing.Size(160, 33);
            this.CharsSpacing.TabIndex = 10;
            this.CharsSpacing.Text = "Characters Spacing";
            this.CharsSpacing.UseVisualStyleBackColor = false;
            this.CharsSpacing.CheckedChanged += new System.EventHandler(this.CharsSpacing_CheckedChanged);
            // 
            // Slashes
            // 
            this.Slashes.AutoSize = true;
            this.Slashes.BackColor = System.Drawing.Color.Transparent;
            this.Slashes.Checked = true;
            this.Slashes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Slashes.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slashes.ForeColor = System.Drawing.Color.Black;
            this.Slashes.Location = new System.Drawing.Point(18, 57);
            this.Slashes.Name = "Slashes";
            this.Slashes.Size = new System.Drawing.Size(85, 33);
            this.Slashes.TabIndex = 9;
            this.Slashes.Text = "Slashes";
            this.Slashes.UseVisualStyleBackColor = false;
            this.Slashes.CheckedChanged += new System.EventHandler(this.Slashes_CheckedChanged);
            // 
            // Dashes
            // 
            this.Dashes.AutoSize = true;
            this.Dashes.BackColor = System.Drawing.Color.Transparent;
            this.Dashes.Checked = true;
            this.Dashes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Dashes.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashes.ForeColor = System.Drawing.Color.Black;
            this.Dashes.Location = new System.Drawing.Point(18, 33);
            this.Dashes.Name = "Dashes";
            this.Dashes.Size = new System.Drawing.Size(83, 33);
            this.Dashes.TabIndex = 8;
            this.Dashes.Text = "Dashes";
            this.Dashes.UseVisualStyleBackColor = false;
            this.Dashes.CheckedChanged += new System.EventHandler(this.Dashes_CheckedChanged);
            // 
            // ShowKeyButton
            // 
            this.ShowKeyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ShowKeyButton.FlatAppearance.BorderSize = 0;
            this.ShowKeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ShowKeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.ShowKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowKeyButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowKeyButton.ForeColor = System.Drawing.Color.Black;
            this.ShowKeyButton.Location = new System.Drawing.Point(0, 85);
            this.ShowKeyButton.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.ShowKeyButton.Name = "ShowKeyButton";
            this.ShowKeyButton.Size = new System.Drawing.Size(280, 40);
            this.ShowKeyButton.TabIndex = 4;
            this.ShowKeyButton.Text = "اظهار المفتاح";
            this.ShowKeyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowKeyButton.UseVisualStyleBackColor = false;
            this.ShowKeyButton.Click += new System.EventHandler(this.ShowKeyButton_Click);
            // 
            // EncodeButton
            // 
            this.EncodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EncodeButton.FlatAppearance.BorderSize = 0;
            this.EncodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EncodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.EncodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncodeButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodeButton.ForeColor = System.Drawing.Color.Black;
            this.EncodeButton.Location = new System.Drawing.Point(0, 43);
            this.EncodeButton.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(280, 40);
            this.EncodeButton.TabIndex = 3;
            this.EncodeButton.Text = "تشفير";
            this.EncodeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EncodeButton.UseVisualStyleBackColor = false;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.LightGray;
            this.Title.Controls.Add(this.Version);
            this.Title.Controls.Add(this.ScoutsEncoder);
            this.Title.Location = new System.Drawing.Point(0, 50);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(280, 70);
            this.Title.TabIndex = 23;
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.ForeColor = System.Drawing.Color.Black;
            this.Version.Location = new System.Drawing.Point(175, 46);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(81, 17);
            this.Version.TabIndex = 18;
            this.Version.Text = "V1.1 - BETA";
            // 
            // ScoutsEncoder
            // 
            this.ScoutsEncoder.BackColor = System.Drawing.Color.Transparent;
            this.ScoutsEncoder.Font = new System.Drawing.Font("Cairo Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoutsEncoder.ForeColor = System.Drawing.Color.Black;
            this.ScoutsEncoder.Location = new System.Drawing.Point(20, 1);
            this.ScoutsEncoder.Name = "ScoutsEncoder";
            this.ScoutsEncoder.Size = new System.Drawing.Size(259, 55);
            this.ScoutsEncoder.TabIndex = 21;
            this.ScoutsEncoder.Text = "ScoutsEncoder";
            this.ScoutsEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(249, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(20, 20);
            this.ExitButton.TabIndex = 21;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SideMenu
            // 
            this.SideMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.SideMenu.Controls.Add(this.ExitButton);
            this.SideMenu.Controls.Add(this.Title);
            this.SideMenu.Controls.Add(this.ButtonsPanel);
            this.SideMenu.Controls.Add(this.Options);
            this.SideMenu.Controls.Add(this.ThemeButton);
            this.SideMenu.Controls.Add(this.ReportButton);
            this.SideMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.SideMenu.Location = new System.Drawing.Point(800, 0);
            this.SideMenu.Name = "SideMenu";
            this.SideMenu.Size = new System.Drawing.Size(280, 720);
            this.SideMenu.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonsPanel.Controls.Add(this.DropdownPanel);
            this.ButtonsPanel.Controls.Add(this.EncodeButton);
            this.ButtonsPanel.Controls.Add(this.ShowKeyButton);
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 222);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(280, 129);
            this.ButtonsPanel.TabIndex = 26;
            // 
            // DropdownPanel
            // 
            this.DropdownPanel.Controls.Add(this.SetCodeButton);
            this.DropdownPanel.Controls.Add(this.UpperBorder);
            this.DropdownPanel.Controls.Add(this.MiddleBorder);
            this.DropdownPanel.Controls.Add(this.BottomBorder);
            this.DropdownPanel.Controls.Add(this.RightBorder);
            this.DropdownPanel.Controls.Add(this.LeftBorder);
            this.DropdownPanel.Controls.Add(this.CodesComboBox);
            this.DropdownPanel.Controls.Add(this.KeysComboBox);
            this.DropdownPanel.Location = new System.Drawing.Point(0, 1);
            this.DropdownPanel.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.DropdownPanel.MaximumSize = new System.Drawing.Size(280, 120);
            this.DropdownPanel.MinimumSize = new System.Drawing.Size(280, 40);
            this.DropdownPanel.Name = "DropdownPanel";
            this.DropdownPanel.Size = new System.Drawing.Size(280, 40);
            this.DropdownPanel.TabIndex = 26;
            // 
            // SetCodeButton
            // 
            this.SetCodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SetCodeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SetCodeButton.FlatAppearance.BorderSize = 0;
            this.SetCodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SetCodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.SetCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetCodeButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetCodeButton.ForeColor = System.Drawing.Color.Black;
            this.SetCodeButton.Location = new System.Drawing.Point(0, 0);
            this.SetCodeButton.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SetCodeButton.Name = "SetCodeButton";
            this.SetCodeButton.Size = new System.Drawing.Size(280, 40);
            this.SetCodeButton.TabIndex = 25;
            this.SetCodeButton.Text = "إعدادات الشفرة";
            this.SetCodeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SetCodeButton.UseVisualStyleBackColor = false;
            this.SetCodeButton.Click += new System.EventHandler(this.SetCodeButton_Click);
            // 
            // UpperBorder
            // 
            this.UpperBorder.Location = new System.Drawing.Point(-5, 30);
            this.UpperBorder.Name = "UpperBorder";
            this.UpperBorder.Size = new System.Drawing.Size(294, 15);
            this.UpperBorder.TabIndex = 28;
            // 
            // MiddleBorder
            // 
            this.MiddleBorder.Location = new System.Drawing.Point(-15, 80);
            this.MiddleBorder.Name = "MiddleBorder";
            this.MiddleBorder.Size = new System.Drawing.Size(304, 5);
            this.MiddleBorder.TabIndex = 27;
            // 
            // BottomBorder
            // 
            this.BottomBorder.Location = new System.Drawing.Point(-5, 125);
            this.BottomBorder.Name = "BottomBorder";
            this.BottomBorder.Size = new System.Drawing.Size(294, 10);
            this.BottomBorder.TabIndex = 28;
            // 
            // RightBorder
            // 
            this.RightBorder.Location = new System.Drawing.Point(271, 29);
            this.RightBorder.Name = "RightBorder";
            this.RightBorder.Size = new System.Drawing.Size(31, 101);
            this.RightBorder.TabIndex = 27;
            // 
            // LeftBorder
            // 
            this.LeftBorder.Location = new System.Drawing.Point(-17, 29);
            this.LeftBorder.Name = "LeftBorder";
            this.LeftBorder.Size = new System.Drawing.Size(30, 101);
            this.LeftBorder.TabIndex = 26;
            // 
            // CodesComboBox
            // 
            this.CodesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodesComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CodesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CodesComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodesComboBox.ForeColor = System.Drawing.Color.Black;
            this.CodesComboBox.FormattingEnabled = true;
            this.CodesComboBox.Items.AddRange(new object[] {
            "  يسوع",
            "  رقمية",
            "  عكسية",
            "  الساعة",
            "  الجوال",
            "  اكس",
            "  المورس",
            "  عربي مفرط"});
            this.CodesComboBox.Location = new System.Drawing.Point(-17, 2);
            this.CodesComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodesComboBox.Name = "CodesComboBox";
            this.CodesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CodesComboBox.Size = new System.Drawing.Size(293, 40);
            this.CodesComboBox.TabIndex = 1;
            this.CodesComboBox.Text = "  اختر الشفرة";
            this.CodesComboBox.SelectedIndexChanged += new System.EventHandler(this.CodesComboBox_SelectedIndexChanged);
            this.CodesComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CodesComboBox_MouseClick);
            // 
            // KeysComboBox
            // 
            this.KeysComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeysComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.KeysComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.KeysComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeysComboBox.ForeColor = System.Drawing.Color.Black;
            this.KeysComboBox.FormattingEnabled = true;
            this.KeysComboBox.IntegralHeight = false;
            this.KeysComboBox.Location = new System.Drawing.Point(-17, 41);
            this.KeysComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.KeysComboBox.Name = "KeysComboBox";
            this.KeysComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.KeysComboBox.Size = new System.Drawing.Size(293, 40);
            this.KeysComboBox.TabIndex = 2;
            this.KeysComboBox.Text = "  اختر المفتاح";
            this.KeysComboBox.SelectedIndexChanged += new System.EventHandler(this.KeysComboBox_SelectedIndexChanged);
            this.KeysComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KeysComboBox_MouseClick);
            // 
            // ThemeButton
            // 
            this.ThemeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ThemeButton.FlatAppearance.BorderSize = 0;
            this.ThemeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ThemeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.ThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThemeButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.ThemeButton.ForeColor = System.Drawing.Color.White;
            this.ThemeButton.Location = new System.Drawing.Point(50, 641);
            this.ThemeButton.Margin = new System.Windows.Forms.Padding(0);
            this.ThemeButton.Name = "ThemeButton";
            this.ThemeButton.Size = new System.Drawing.Size(180, 38);
            this.ThemeButton.TabIndex = 27;
            this.ThemeButton.Text = "Dark Theme";
            this.ThemeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ThemeButton.UseVisualStyleBackColor = false;
            this.ThemeButton.Click += new System.EventHandler(this.ThemeButton_Click);
            // 
            // DropdownTimer
            // 
            this.DropdownTimer.Enabled = true;
            this.DropdownTimer.Interval = 15;
            this.DropdownTimer.Tick += new System.EventHandler(this.DropdownTimer_Tick);
            // 
            // ScoutsEncoderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.SideMenu);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InputTools);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.OutputTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScoutsEncoderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scouts Encoder [BETA]";
            this.InputTools.ResumeLayout(false);
            this.OutputTools.ResumeLayout(false);
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.SideMenu.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.DropdownPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button InputClear;
        private System.Windows.Forms.Button InputPaste;
        private System.Windows.Forms.Button InputCut;
        private System.Windows.Forms.Button InputCopy;
        private System.Windows.Forms.Panel InputTools;
        private System.Windows.Forms.Panel OutputTools;
        private System.Windows.Forms.Button OutputClear;
        private System.Windows.Forms.Button OutputPaste;
        private System.Windows.Forms.Button OutputCut;
        private System.Windows.Forms.Button OutputCopy;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Label OutputOptions;
        private System.Windows.Forms.CheckBox WordsSpacing;
        private System.Windows.Forms.CheckBox CharsSpacing;
        private System.Windows.Forms.CheckBox Slashes;
        private System.Windows.Forms.CheckBox Dashes;
        private System.Windows.Forms.Button ShowKeyButton;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.Panel Title;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label ScoutsEncoder;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel SideMenu;
        private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Panel DropdownPanel;
        private System.Windows.Forms.Button SetCodeButton;
        private System.Windows.Forms.ComboBox CodesComboBox;
        private System.Windows.Forms.ComboBox KeysComboBox;
        private System.Windows.Forms.Timer DropdownTimer;
        private System.Windows.Forms.Panel RightBorder;
        private System.Windows.Forms.Panel UpperBorder;
        private System.Windows.Forms.Panel BottomBorder;
        private System.Windows.Forms.Panel MiddleBorder;
        private System.Windows.Forms.Panel LeftBorder;
        private System.Windows.Forms.Button ThemeButton;
    }
}

