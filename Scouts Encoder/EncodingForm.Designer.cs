namespace Scouts_Encoder
{
    partial class EncodingForm
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.CodesComboBox = new System.Windows.Forms.ComboBox();
            this.ShowKeyButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DashesCheckBox = new System.Windows.Forms.CheckBox();
            this.KeysComboBox = new System.Windows.Forms.ComboBox();
            this.SlashesCheckBox = new System.Windows.Forms.CheckBox();
            this.CharactersSpacingCheckBox = new System.Windows.Forms.CheckBox();
            this.WordsSpacingCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.AcceptsReturn = true;
            this.InputTextBox.AllowDrop = true;
            this.InputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputTextBox.Font = new System.Drawing.Font("Kawkab Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.InputTextBox.Location = new System.Drawing.Point(627, 12);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputTextBox.Size = new System.Drawing.Size(602, 532);
            this.InputTextBox.TabIndex = 7;
            this.InputTextBox.Text = "ادخل الشفرة هنا...";
            this.InputTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this.InputTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.AcceptsReturn = true;
            this.OutputTextBox.AllowDrop = true;
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputTextBox.Font = new System.Drawing.Font("Kawkab Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.Location = new System.Drawing.Point(17, 12);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(602, 532);
            this.OutputTextBox.TabIndex = 8;
            // 
            // EncodeButton
            // 
            this.EncodeButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EncodeButton.Enabled = false;
            this.EncodeButton.FlatAppearance.BorderSize = 0;
            this.EncodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncodeButton.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.EncodeButton.Location = new System.Drawing.Point(435, 572);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(179, 40);
            this.EncodeButton.TabIndex = 4;
            this.EncodeButton.Text = "تشفير";
            this.EncodeButton.UseVisualStyleBackColor = false;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // CodesComboBox
            // 
            this.CodesComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CodesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodesComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodesComboBox.FormattingEnabled = true;
            this.CodesComboBox.Items.AddRange(new object[] {
            "يسوع",
            "رقمية",
            "عكسية",
            "الساعة",
            "الجوال",
            "اكس",
            "المورس",
            "عربي مفرط"});
            this.CodesComboBox.Location = new System.Drawing.Point(1029, 572);
            this.CodesComboBox.Name = "CodesComboBox";
            this.CodesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CodesComboBox.Size = new System.Drawing.Size(179, 40);
            this.CodesComboBox.TabIndex = 1;
            this.CodesComboBox.Text = "اختر الشفرة";
            this.CodesComboBox.SelectedIndexChanged += new System.EventHandler(this.CodesComboBox_SelectedIndexChanged);
            // 
            // ShowKeyButton
            // 
            this.ShowKeyButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ShowKeyButton.Enabled = false;
            this.ShowKeyButton.FlatAppearance.BorderSize = 0;
            this.ShowKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowKeyButton.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.ShowKeyButton.Location = new System.Drawing.Point(633, 572);
            this.ShowKeyButton.Name = "ShowKeyButton";
            this.ShowKeyButton.Size = new System.Drawing.Size(179, 40);
            this.ShowKeyButton.TabIndex = 3;
            this.ShowKeyButton.Text = "اظهار المفتاح";
            this.ShowKeyButton.UseVisualStyleBackColor = false;
            this.ShowKeyButton.Click += new System.EventHandler(this.ShowKeyButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CopyButton.Enabled = false;
            this.CopyButton.FlatAppearance.BorderSize = 0;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButton.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.CopyButton.Location = new System.Drawing.Point(237, 572);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(179, 40);
            this.CopyButton.TabIndex = 5;
            this.CopyButton.Text = "نسخ التشفير";
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearButton.Enabled = false;
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.ClearButton.Location = new System.Drawing.Point(39, 572);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(179, 40);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "مسح";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DashesCheckBox
            // 
            this.DashesCheckBox.AutoSize = true;
            this.DashesCheckBox.Checked = true;
            this.DashesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DashesCheckBox.Location = new System.Drawing.Point(398, 624);
            this.DashesCheckBox.Name = "DashesCheckBox";
            this.DashesCheckBox.Size = new System.Drawing.Size(78, 21);
            this.DashesCheckBox.TabIndex = 8;
            this.DashesCheckBox.Text = "Dashes";
            this.DashesCheckBox.UseVisualStyleBackColor = true;
            this.DashesCheckBox.CheckedChanged += new System.EventHandler(this.DashesCheckBox_CheckedChanged);
            // 
            // KeysComboBox
            // 
            this.KeysComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeysComboBox.Enabled = false;
            this.KeysComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeysComboBox.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeysComboBox.FormattingEnabled = true;
            this.KeysComboBox.Location = new System.Drawing.Point(831, 572);
            this.KeysComboBox.Name = "KeysComboBox";
            this.KeysComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.KeysComboBox.Size = new System.Drawing.Size(179, 40);
            this.KeysComboBox.TabIndex = 2;
            this.KeysComboBox.Text = "اختر المفتاح";
            this.KeysComboBox.SelectedIndexChanged += new System.EventHandler(this.KeysComboBox_SelectedIndexChanged);
            // 
            // SlashesCheckBox
            // 
            this.SlashesCheckBox.AutoSize = true;
            this.SlashesCheckBox.Checked = true;
            this.SlashesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SlashesCheckBox.Location = new System.Drawing.Point(480, 624);
            this.SlashesCheckBox.Name = "SlashesCheckBox";
            this.SlashesCheckBox.Size = new System.Drawing.Size(80, 21);
            this.SlashesCheckBox.TabIndex = 9;
            this.SlashesCheckBox.Text = "Slashes";
            this.SlashesCheckBox.UseVisualStyleBackColor = true;
            this.SlashesCheckBox.CheckedChanged += new System.EventHandler(this.SlashesCheckBox_CheckedChanged);
            // 
            // CharactersSpacingCheckBox
            // 
            this.CharactersSpacingCheckBox.AutoSize = true;
            this.CharactersSpacingCheckBox.Checked = true;
            this.CharactersSpacingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CharactersSpacingCheckBox.Location = new System.Drawing.Point(564, 624);
            this.CharactersSpacingCheckBox.Name = "CharactersSpacingCheckBox";
            this.CharactersSpacingCheckBox.Size = new System.Drawing.Size(154, 21);
            this.CharactersSpacingCheckBox.TabIndex = 10;
            this.CharactersSpacingCheckBox.Text = "Characters Spacing";
            this.CharactersSpacingCheckBox.UseVisualStyleBackColor = true;
            this.CharactersSpacingCheckBox.CheckedChanged += new System.EventHandler(this.CharactersSpacingCheckBox_CheckedChanged);
            // 
            // WordsSpacingCheckBox
            // 
            this.WordsSpacingCheckBox.AutoSize = true;
            this.WordsSpacingCheckBox.Checked = true;
            this.WordsSpacingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordsSpacingCheckBox.Location = new System.Drawing.Point(722, 624);
            this.WordsSpacingCheckBox.Name = "WordsSpacingCheckBox";
            this.WordsSpacingCheckBox.Size = new System.Drawing.Size(126, 21);
            this.WordsSpacingCheckBox.TabIndex = 11;
            this.WordsSpacingCheckBox.Text = "Words Spacing";
            this.WordsSpacingCheckBox.UseVisualStyleBackColor = true;
            this.WordsSpacingCheckBox.CheckedChanged += new System.EventHandler(this.WordsSpacingCheckBox_CheckedChanged);
            // 
            // EncodingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1247, 667);
            this.Controls.Add(this.WordsSpacingCheckBox);
            this.Controls.Add(this.CharactersSpacingCheckBox);
            this.Controls.Add(this.SlashesCheckBox);
            this.Controls.Add(this.DashesCheckBox);
            this.Controls.Add(this.KeysComboBox);
            this.Controls.Add(this.CodesComboBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.ShowKeyButton);
            this.Controls.Add(this.EncodeButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.OutputTextBox);
            this.Name = "EncodingForm";
            this.Text = "Scouts Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.ComboBox CodesComboBox;
        private System.Windows.Forms.Button ShowKeyButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox DashesCheckBox;
        private System.Windows.Forms.ComboBox KeysComboBox;
        private System.Windows.Forms.CheckBox SlashesCheckBox;
        private System.Windows.Forms.CheckBox CharactersSpacingCheckBox;
        private System.Windows.Forms.CheckBox WordsSpacingCheckBox;
    }
}

