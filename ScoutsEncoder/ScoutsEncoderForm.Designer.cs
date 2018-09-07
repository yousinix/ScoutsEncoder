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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoutsEncoderForm));
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.CodesComboBox = new System.Windows.Forms.ComboBox();
            this.ShowKeyButton = new System.Windows.Forms.Button();
            this.DashesCheckBox = new System.Windows.Forms.CheckBox();
            this.KeysComboBox = new System.Windows.Forms.ComboBox();
            this.SlashesCheckBox = new System.Windows.Forms.CheckBox();
            this.CharactersSpacingCheckBox = new System.Windows.Forms.CheckBox();
            this.WordsSpacingCheckBox = new System.Windows.Forms.CheckBox();
            this.SideMenu = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Panel();
            this.Version = new System.Windows.Forms.Label();
            this.ScoutsEncoder = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.Panel();
            this.OutputOptions = new System.Windows.Forms.Label();
            this.ReportButton = new System.Windows.Forms.Button();
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
            this.SideMenu.SuspendLayout();
            this.Title.SuspendLayout();
            this.Options.SuspendLayout();
            this.InputTools.SuspendLayout();
            this.OutputTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.AcceptsReturn = true;
            this.InputTextBox.AllowDrop = true;
            this.InputTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputTextBox.Font = new System.Drawing.Font("Kawkab Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.InputTextBox.Location = new System.Drawing.Point(66, 21);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
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
            this.OutputTextBox.Location = new System.Drawing.Point(66, 371);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(714, 331);
            this.OutputTextBox.TabIndex = 2;
            // 
            // EncodeButton
            // 
            this.EncodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EncodeButton.Enabled = false;
            this.EncodeButton.FlatAppearance.BorderSize = 0;
            this.EncodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.EncodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.EncodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncodeButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodeButton.Location = new System.Drawing.Point(-28, 263);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(303, 40);
            this.EncodeButton.TabIndex = 3;
            this.EncodeButton.Text = "تشفير";
            this.EncodeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EncodeButton.UseVisualStyleBackColor = false;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // CodesComboBox
            // 
            this.CodesComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CodesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CodesComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.CodesComboBox.Location = new System.Drawing.Point(-28, 163);
            this.CodesComboBox.Name = "CodesComboBox";
            this.CodesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CodesComboBox.Size = new System.Drawing.Size(303, 40);
            this.CodesComboBox.TabIndex = 1;
            this.CodesComboBox.Text = "  اختر الشفرة";
            this.CodesComboBox.SelectedIndexChanged += new System.EventHandler(this.CodesComboBox_SelectedIndexChanged);
            this.CodesComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CodesComboBox_MouseClick);
            // 
            // ShowKeyButton
            // 
            this.ShowKeyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ShowKeyButton.Enabled = false;
            this.ShowKeyButton.FlatAppearance.BorderSize = 0;
            this.ShowKeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.ShowKeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.ShowKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowKeyButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowKeyButton.Location = new System.Drawing.Point(-28, 305);
            this.ShowKeyButton.Name = "ShowKeyButton";
            this.ShowKeyButton.Size = new System.Drawing.Size(303, 40);
            this.ShowKeyButton.TabIndex = 4;
            this.ShowKeyButton.Text = "اظهار المفتاح";
            this.ShowKeyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowKeyButton.UseVisualStyleBackColor = false;
            this.ShowKeyButton.Click += new System.EventHandler(this.ShowKeyButton_Click);
            // 
            // DashesCheckBox
            // 
            this.DashesCheckBox.AutoSize = true;
            this.DashesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DashesCheckBox.Checked = true;
            this.DashesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DashesCheckBox.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashesCheckBox.Location = new System.Drawing.Point(18, 33);
            this.DashesCheckBox.Name = "DashesCheckBox";
            this.DashesCheckBox.Size = new System.Drawing.Size(83, 33);
            this.DashesCheckBox.TabIndex = 8;
            this.DashesCheckBox.Text = "Dashes";
            this.DashesCheckBox.UseVisualStyleBackColor = false;
            this.DashesCheckBox.CheckedChanged += new System.EventHandler(this.DashesCheckBox_CheckedChanged);
            // 
            // KeysComboBox
            // 
            this.KeysComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.KeysComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.KeysComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeysComboBox.FormattingEnabled = true;
            this.KeysComboBox.IntegralHeight = false;
            this.KeysComboBox.Location = new System.Drawing.Point(-28, 205);
            this.KeysComboBox.Name = "KeysComboBox";
            this.KeysComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.KeysComboBox.Size = new System.Drawing.Size(303, 40);
            this.KeysComboBox.TabIndex = 2;
            this.KeysComboBox.Text = "  اختر المفتاح";
            this.KeysComboBox.SelectedIndexChanged += new System.EventHandler(this.KeysComboBox_SelectedIndexChanged);
            this.KeysComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KeysComboBox_MouseClick);
            // 
            // SlashesCheckBox
            // 
            this.SlashesCheckBox.AutoSize = true;
            this.SlashesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.SlashesCheckBox.Checked = true;
            this.SlashesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SlashesCheckBox.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlashesCheckBox.Location = new System.Drawing.Point(18, 57);
            this.SlashesCheckBox.Name = "SlashesCheckBox";
            this.SlashesCheckBox.Size = new System.Drawing.Size(85, 33);
            this.SlashesCheckBox.TabIndex = 9;
            this.SlashesCheckBox.Text = "Slashes";
            this.SlashesCheckBox.UseVisualStyleBackColor = false;
            this.SlashesCheckBox.CheckedChanged += new System.EventHandler(this.SlashesCheckBox_CheckedChanged);
            // 
            // CharactersSpacingCheckBox
            // 
            this.CharactersSpacingCheckBox.AutoSize = true;
            this.CharactersSpacingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CharactersSpacingCheckBox.Checked = true;
            this.CharactersSpacingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CharactersSpacingCheckBox.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharactersSpacingCheckBox.Location = new System.Drawing.Point(18, 81);
            this.CharactersSpacingCheckBox.Name = "CharactersSpacingCheckBox";
            this.CharactersSpacingCheckBox.Size = new System.Drawing.Size(160, 33);
            this.CharactersSpacingCheckBox.TabIndex = 10;
            this.CharactersSpacingCheckBox.Text = "Characters Spacing";
            this.CharactersSpacingCheckBox.UseVisualStyleBackColor = false;
            this.CharactersSpacingCheckBox.CheckedChanged += new System.EventHandler(this.CharactersSpacingCheckBox_CheckedChanged);
            // 
            // WordsSpacingCheckBox
            // 
            this.WordsSpacingCheckBox.AutoSize = true;
            this.WordsSpacingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.WordsSpacingCheckBox.Checked = true;
            this.WordsSpacingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordsSpacingCheckBox.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordsSpacingCheckBox.Location = new System.Drawing.Point(18, 105);
            this.WordsSpacingCheckBox.Name = "WordsSpacingCheckBox";
            this.WordsSpacingCheckBox.Size = new System.Drawing.Size(132, 33);
            this.WordsSpacingCheckBox.TabIndex = 11;
            this.WordsSpacingCheckBox.Text = "Words Spacing";
            this.WordsSpacingCheckBox.UseVisualStyleBackColor = false;
            this.WordsSpacingCheckBox.CheckedChanged += new System.EventHandler(this.WordsSpacingCheckBox_CheckedChanged);
            // 
            // SideMenu
            // 
            this.SideMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.SideMenu.Controls.Add(this.ExitButton);
            this.SideMenu.Controls.Add(this.Title);
            this.SideMenu.Controls.Add(this.CodesComboBox);
            this.SideMenu.Controls.Add(this.KeysComboBox);
            this.SideMenu.Controls.Add(this.EncodeButton);
            this.SideMenu.Controls.Add(this.ShowKeyButton);
            this.SideMenu.Controls.Add(this.Options);
            this.SideMenu.Controls.Add(this.ReportButton);
            this.SideMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.SideMenu.Location = new System.Drawing.Point(804, 0);
            this.SideMenu.Name = "SideMenu";
            this.SideMenu.Size = new System.Drawing.Size(287, 723);
            this.SideMenu.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::ScoutsEncoder.Properties.Resources.clear;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(255, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(20, 20);
            this.ExitButton.TabIndex = 21;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.LightGray;
            this.Title.Controls.Add(this.Version);
            this.Title.Controls.Add(this.ScoutsEncoder);
            this.Title.Location = new System.Drawing.Point(-8, 52);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(317, 70);
            this.Title.TabIndex = 23;
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.Location = new System.Drawing.Point(183, 46);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(81, 17);
            this.Version.TabIndex = 18;
            this.Version.Text = "V1.0 - BETA";
            // 
            // ScoutsEncoder
            // 
            this.ScoutsEncoder.BackColor = System.Drawing.Color.Transparent;
            this.ScoutsEncoder.Font = new System.Drawing.Font("Cairo Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoutsEncoder.Location = new System.Drawing.Point(28, 1);
            this.ScoutsEncoder.Name = "ScoutsEncoder";
            this.ScoutsEncoder.Size = new System.Drawing.Size(259, 55);
            this.ScoutsEncoder.TabIndex = 21;
            this.ScoutsEncoder.Text = "ScoutsEncoder";
            this.ScoutsEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.LightGray;
            this.Options.Controls.Add(this.OutputOptions);
            this.Options.Controls.Add(this.WordsSpacingCheckBox);
            this.Options.Controls.Add(this.CharactersSpacingCheckBox);
            this.Options.Controls.Add(this.SlashesCheckBox);
            this.Options.Controls.Add(this.DashesCheckBox);
            this.Options.Location = new System.Drawing.Point(0, 371);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(299, 157);
            this.Options.TabIndex = 22;
            // 
            // OutputOptions
            // 
            this.OutputOptions.AutoSize = true;
            this.OutputOptions.BackColor = System.Drawing.Color.Transparent;
            this.OutputOptions.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.OutputOptions.Location = new System.Drawing.Point(36, 11);
            this.OutputOptions.Name = "OutputOptions";
            this.OutputOptions.Size = new System.Drawing.Size(114, 29);
            this.OutputOptions.TabIndex = 23;
            this.OutputOptions.Text = "Output Options:";
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReportButton.FlatAppearance.BorderSize = 0;
            this.ReportButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.ReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.ReportButton.Location = new System.Drawing.Point(59, 680);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(177, 67);
            this.ReportButton.TabIndex = 20;
            this.ReportButton.Text = "الإبلاغ عن خطأ";
            this.ReportButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // InputClear
            // 
            this.InputClear.BackColor = System.Drawing.Color.Transparent;
            this.InputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.clear;
            this.InputClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputClear.FlatAppearance.BorderSize = 0;
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
            this.InputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.paste;
            this.InputPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputPaste.FlatAppearance.BorderSize = 0;
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
            this.InputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.cut;
            this.InputCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputCut.FlatAppearance.BorderSize = 0;
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
            this.InputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.copy;
            this.InputCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InputCopy.FlatAppearance.BorderSize = 0;
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
            this.InputTools.Location = new System.Drawing.Point(21, 108);
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
            this.OutputTools.Location = new System.Drawing.Point(21, 458);
            this.OutputTools.Name = "OutputTools";
            this.OutputTools.Size = new System.Drawing.Size(48, 156);
            this.OutputTools.TabIndex = 4;
            // 
            // OutputCopy
            // 
            this.OutputCopy.BackColor = System.Drawing.Color.Transparent;
            this.OutputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.copy;
            this.OutputCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputCopy.FlatAppearance.BorderSize = 0;
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
            this.OutputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.cut;
            this.OutputCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputCut.FlatAppearance.BorderSize = 0;
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
            this.OutputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.paste;
            this.OutputPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputPaste.FlatAppearance.BorderSize = 0;
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
            this.OutputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.clear;
            this.OutputClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OutputClear.FlatAppearance.BorderSize = 0;
            this.OutputClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputClear.Location = new System.Drawing.Point(10, 112);
            this.OutputClear.Name = "OutputClear";
            this.OutputClear.Size = new System.Drawing.Size(25, 25);
            this.OutputClear.TabIndex = 16;
            this.OutputClear.UseVisualStyleBackColor = false;
            this.OutputClear.Click += new System.EventHandler(this.OutputClear_Click);
            // 
            // ScoutsEncoderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1091, 723);
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
            this.SideMenu.ResumeLayout(false);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.InputTools.ResumeLayout(false);
            this.OutputTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.ComboBox CodesComboBox;
        private System.Windows.Forms.Button ShowKeyButton;
        private System.Windows.Forms.CheckBox DashesCheckBox;
        private System.Windows.Forms.ComboBox KeysComboBox;
        private System.Windows.Forms.CheckBox SlashesCheckBox;
        private System.Windows.Forms.CheckBox CharactersSpacingCheckBox;
        private System.Windows.Forms.CheckBox WordsSpacingCheckBox;
        private System.Windows.Forms.Panel SideMenu;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label ScoutsEncoder;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button InputClear;
        private System.Windows.Forms.Button InputPaste;
        private System.Windows.Forms.Button InputCut;
        private System.Windows.Forms.Button InputCopy;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Panel InputTools;
        private System.Windows.Forms.Panel OutputTools;
        private System.Windows.Forms.Button OutputClear;
        private System.Windows.Forms.Button OutputPaste;
        private System.Windows.Forms.Button OutputCut;
        private System.Windows.Forms.Button OutputCopy;
        private System.Windows.Forms.Label OutputOptions;
        private System.Windows.Forms.Panel Title;
    }
}

