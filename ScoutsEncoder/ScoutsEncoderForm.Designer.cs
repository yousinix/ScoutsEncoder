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
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.FillShapes = new System.Windows.Forms.CheckBox();
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
            this.WebsiteButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DropdownPanel = new System.Windows.Forms.Panel();
            this.SetCipherButton = new System.Windows.Forms.Button();
            this.UpperBorder = new System.Windows.Forms.Panel();
            this.MiddleBorder = new System.Windows.Forms.Panel();
            this.BottomBorder = new System.Windows.Forms.Panel();
            this.RightBorder = new System.Windows.Forms.Panel();
            this.LeftBorder = new System.Windows.Forms.Panel();
            this.CiphersComboBox = new System.Windows.Forms.ComboBox();
            this.KeysComboBox = new System.Windows.Forms.ComboBox();
            this.GitHubButton = new System.Windows.Forms.Button();
            this.DocsButton = new System.Windows.Forms.Button();
            this.ThemeButton = new System.Windows.Forms.Button();
            this.DropdownTimer = new System.Windows.Forms.Timer(this.components);
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            this.ExportAudio = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.InputTools.SuspendLayout();
            this.OutputTools.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.Title.SuspendLayout();
            this.SideMenu.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.DropdownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputClear
            // 
            this.InputClear.BackColor = System.Drawing.Color.Transparent;
            this.InputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            resources.ApplyResources(this.InputClear, "InputClear");
            this.InputClear.FlatAppearance.BorderSize = 0;
            this.InputClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputClear.Name = "InputClear";
            this.Tips.SetToolTip(this.InputClear, resources.GetString("InputClear.ToolTip"));
            this.InputClear.UseVisualStyleBackColor = false;
            this.InputClear.Click += new System.EventHandler(this.InputClear_Click);
            // 
            // InputPaste
            // 
            this.InputPaste.BackColor = System.Drawing.Color.Transparent;
            this.InputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Paste;
            resources.ApplyResources(this.InputPaste, "InputPaste");
            this.InputPaste.FlatAppearance.BorderSize = 0;
            this.InputPaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputPaste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputPaste.Name = "InputPaste";
            this.Tips.SetToolTip(this.InputPaste, resources.GetString("InputPaste.ToolTip"));
            this.InputPaste.UseVisualStyleBackColor = false;
            this.InputPaste.Click += new System.EventHandler(this.InputPaste_Click);
            // 
            // InputCut
            // 
            this.InputCut.BackColor = System.Drawing.Color.Transparent;
            this.InputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Cut;
            resources.ApplyResources(this.InputCut, "InputCut");
            this.InputCut.FlatAppearance.BorderSize = 0;
            this.InputCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputCut.Name = "InputCut";
            this.Tips.SetToolTip(this.InputCut, resources.GetString("InputCut.ToolTip"));
            this.InputCut.UseVisualStyleBackColor = false;
            this.InputCut.Click += new System.EventHandler(this.InputCut_Click);
            // 
            // InputCopy
            // 
            this.InputCopy.BackColor = System.Drawing.Color.Transparent;
            this.InputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Copy;
            resources.ApplyResources(this.InputCopy, "InputCopy");
            this.InputCopy.FlatAppearance.BorderSize = 0;
            this.InputCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.InputCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.InputCopy.Name = "InputCopy";
            this.Tips.SetToolTip(this.InputCopy, resources.GetString("InputCopy.ToolTip"));
            this.InputCopy.UseVisualStyleBackColor = false;
            this.InputCopy.Click += new System.EventHandler(this.InputCopy_Click);
            // 
            // InputTools
            // 
            this.InputTools.Controls.Add(this.InputCopy);
            this.InputTools.Controls.Add(this.InputCut);
            this.InputTools.Controls.Add(this.InputPaste);
            this.InputTools.Controls.Add(this.InputClear);
            resources.ApplyResources(this.InputTools, "InputTools");
            this.InputTools.Name = "InputTools";
            // 
            // OutputTools
            // 
            this.OutputTools.Controls.Add(this.OutputCopy);
            this.OutputTools.Controls.Add(this.OutputCut);
            this.OutputTools.Controls.Add(this.OutputPaste);
            this.OutputTools.Controls.Add(this.OutputClear);
            resources.ApplyResources(this.OutputTools, "OutputTools");
            this.OutputTools.Name = "OutputTools";
            // 
            // OutputCopy
            // 
            this.OutputCopy.BackColor = System.Drawing.Color.Transparent;
            this.OutputCopy.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Copy;
            resources.ApplyResources(this.OutputCopy, "OutputCopy");
            this.OutputCopy.FlatAppearance.BorderSize = 0;
            this.OutputCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputCopy.Name = "OutputCopy";
            this.Tips.SetToolTip(this.OutputCopy, resources.GetString("OutputCopy.ToolTip"));
            this.OutputCopy.UseVisualStyleBackColor = false;
            this.OutputCopy.Click += new System.EventHandler(this.OutputCopy_Click);
            // 
            // OutputCut
            // 
            this.OutputCut.BackColor = System.Drawing.Color.Transparent;
            this.OutputCut.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Cut;
            resources.ApplyResources(this.OutputCut, "OutputCut");
            this.OutputCut.FlatAppearance.BorderSize = 0;
            this.OutputCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputCut.Name = "OutputCut";
            this.Tips.SetToolTip(this.OutputCut, resources.GetString("OutputCut.ToolTip"));
            this.OutputCut.UseVisualStyleBackColor = false;
            this.OutputCut.Click += new System.EventHandler(this.OutputCut_Click);
            // 
            // OutputPaste
            // 
            this.OutputPaste.BackColor = System.Drawing.Color.Transparent;
            this.OutputPaste.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Paste;
            resources.ApplyResources(this.OutputPaste, "OutputPaste");
            this.OutputPaste.FlatAppearance.BorderSize = 0;
            this.OutputPaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputPaste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputPaste.Name = "OutputPaste";
            this.Tips.SetToolTip(this.OutputPaste, resources.GetString("OutputPaste.ToolTip"));
            this.OutputPaste.UseVisualStyleBackColor = false;
            this.OutputPaste.Click += new System.EventHandler(this.OutputPaste_Click);
            // 
            // OutputClear
            // 
            this.OutputClear.BackColor = System.Drawing.Color.Transparent;
            this.OutputClear.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            resources.ApplyResources(this.OutputClear, "OutputClear");
            this.OutputClear.FlatAppearance.BorderSize = 0;
            this.OutputClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.OutputClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputClear.Name = "OutputClear";
            this.Tips.SetToolTip(this.OutputClear, resources.GetString("OutputClear.ToolTip"));
            this.OutputClear.UseVisualStyleBackColor = false;
            this.OutputClear.Click += new System.EventHandler(this.OutputClear_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReportButton.FlatAppearance.BorderSize = 0;
            this.ReportButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.ReportButton, "ReportButton");
            this.ReportButton.ForeColor = System.Drawing.Color.Black;
            this.ReportButton.Name = "ReportButton";
            this.Tips.SetToolTip(this.ReportButton, resources.GetString("ReportButton.ToolTip"));
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.LightGray;
            this.OptionsPanel.Controls.Add(this.FillShapes);
            this.OptionsPanel.Controls.Add(this.OutputOptions);
            this.OptionsPanel.Controls.Add(this.WordsSpacing);
            this.OptionsPanel.Controls.Add(this.CharsSpacing);
            this.OptionsPanel.Controls.Add(this.Slashes);
            this.OptionsPanel.Controls.Add(this.Dashes);
            resources.ApplyResources(this.OptionsPanel, "OptionsPanel");
            this.OptionsPanel.Name = "OptionsPanel";
            // 
            // FillShapes
            // 
            resources.ApplyResources(this.FillShapes, "FillShapes");
            this.FillShapes.BackColor = System.Drawing.Color.Transparent;
            this.FillShapes.Checked = true;
            this.FillShapes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FillShapes.ForeColor = System.Drawing.Color.Black;
            this.FillShapes.Name = "FillShapes";
            this.Tips.SetToolTip(this.FillShapes, resources.GetString("FillShapes.ToolTip"));
            this.FillShapes.UseVisualStyleBackColor = false;
            this.FillShapes.CheckedChanged += new System.EventHandler(this.FillShapes_CheckedChanged);
            // 
            // OutputOptions
            // 
            resources.ApplyResources(this.OutputOptions, "OutputOptions");
            this.OutputOptions.BackColor = System.Drawing.Color.Transparent;
            this.OutputOptions.ForeColor = System.Drawing.Color.Black;
            this.OutputOptions.Name = "OutputOptions";
            // 
            // WordsSpacing
            // 
            resources.ApplyResources(this.WordsSpacing, "WordsSpacing");
            this.WordsSpacing.BackColor = System.Drawing.Color.Transparent;
            this.WordsSpacing.Checked = true;
            this.WordsSpacing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordsSpacing.ForeColor = System.Drawing.Color.Black;
            this.WordsSpacing.Name = "WordsSpacing";
            this.Tips.SetToolTip(this.WordsSpacing, resources.GetString("WordsSpacing.ToolTip"));
            this.WordsSpacing.UseVisualStyleBackColor = false;
            this.WordsSpacing.CheckedChanged += new System.EventHandler(this.WordsSpacing_CheckedChanged);
            // 
            // CharsSpacing
            // 
            resources.ApplyResources(this.CharsSpacing, "CharsSpacing");
            this.CharsSpacing.BackColor = System.Drawing.Color.Transparent;
            this.CharsSpacing.Checked = true;
            this.CharsSpacing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CharsSpacing.ForeColor = System.Drawing.Color.Black;
            this.CharsSpacing.Name = "CharsSpacing";
            this.Tips.SetToolTip(this.CharsSpacing, resources.GetString("CharsSpacing.ToolTip"));
            this.CharsSpacing.UseVisualStyleBackColor = false;
            this.CharsSpacing.CheckedChanged += new System.EventHandler(this.CharsSpacing_CheckedChanged);
            // 
            // Slashes
            // 
            resources.ApplyResources(this.Slashes, "Slashes");
            this.Slashes.BackColor = System.Drawing.Color.Transparent;
            this.Slashes.Checked = true;
            this.Slashes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Slashes.ForeColor = System.Drawing.Color.Black;
            this.Slashes.Name = "Slashes";
            this.Tips.SetToolTip(this.Slashes, resources.GetString("Slashes.ToolTip"));
            this.Slashes.UseVisualStyleBackColor = false;
            this.Slashes.CheckedChanged += new System.EventHandler(this.Slashes_CheckedChanged);
            // 
            // Dashes
            // 
            resources.ApplyResources(this.Dashes, "Dashes");
            this.Dashes.BackColor = System.Drawing.Color.Transparent;
            this.Dashes.Checked = true;
            this.Dashes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Dashes.ForeColor = System.Drawing.Color.Black;
            this.Dashes.Name = "Dashes";
            this.Tips.SetToolTip(this.Dashes, resources.GetString("Dashes.ToolTip"));
            this.Dashes.UseVisualStyleBackColor = false;
            this.Dashes.CheckedChanged += new System.EventHandler(this.Dashes_CheckedChanged);
            // 
            // ShowKeyButton
            // 
            this.ShowKeyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ShowKeyButton.FlatAppearance.BorderSize = 0;
            this.ShowKeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ShowKeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.ShowKeyButton, "ShowKeyButton");
            this.ShowKeyButton.ForeColor = System.Drawing.Color.Black;
            this.ShowKeyButton.Name = "ShowKeyButton";
            this.Tips.SetToolTip(this.ShowKeyButton, resources.GetString("ShowKeyButton.ToolTip"));
            this.ShowKeyButton.UseVisualStyleBackColor = false;
            this.ShowKeyButton.Click += new System.EventHandler(this.ShowKeyButton_Click);
            // 
            // EncodeButton
            // 
            this.EncodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EncodeButton.FlatAppearance.BorderSize = 0;
            this.EncodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EncodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.EncodeButton, "EncodeButton");
            this.EncodeButton.ForeColor = System.Drawing.Color.Black;
            this.EncodeButton.Name = "EncodeButton";
            this.Tips.SetToolTip(this.EncodeButton, resources.GetString("EncodeButton.ToolTip"));
            this.EncodeButton.UseVisualStyleBackColor = false;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.LightGray;
            this.Title.Controls.Add(this.Version);
            this.Title.Controls.Add(this.ScoutsEncoder);
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            // 
            // Version
            // 
            resources.ApplyResources(this.Version, "Version");
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.ForeColor = System.Drawing.Color.Black;
            this.Version.Name = "Version";
            // 
            // ScoutsEncoder
            // 
            this.ScoutsEncoder.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ScoutsEncoder, "ScoutsEncoder");
            this.ScoutsEncoder.ForeColor = System.Drawing.Color.Black;
            this.ScoutsEncoder.Name = "ScoutsEncoder";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_Clear;
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ExitButton.Name = "ExitButton";
            this.Tips.SetToolTip(this.ExitButton, resources.GetString("ExitButton.ToolTip"));
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SideMenu
            // 
            this.SideMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.SideMenu.Controls.Add(this.WebsiteButton);
            this.SideMenu.Controls.Add(this.HelpButton);
            this.SideMenu.Controls.Add(this.ExitButton);
            this.SideMenu.Controls.Add(this.Title);
            this.SideMenu.Controls.Add(this.ButtonsPanel);
            this.SideMenu.Controls.Add(this.GitHubButton);
            this.SideMenu.Controls.Add(this.DocsButton);
            this.SideMenu.Controls.Add(this.ThemeButton);
            this.SideMenu.Controls.Add(this.ReportButton);
            resources.ApplyResources(this.SideMenu, "SideMenu");
            this.SideMenu.Name = "SideMenu";
            // 
            // WebsiteButton
            // 
            this.WebsiteButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.WebsiteButton, "WebsiteButton");
            this.WebsiteButton.FlatAppearance.BorderSize = 0;
            this.WebsiteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.WebsiteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.WebsiteButton.ForeColor = System.Drawing.Color.Black;
            this.WebsiteButton.Name = "WebsiteButton";
            this.Tips.SetToolTip(this.WebsiteButton, resources.GetString("WebsiteButton.ToolTip"));
            this.WebsiteButton.UseVisualStyleBackColor = false;
            this.WebsiteButton.Click += new System.EventHandler(this.WebsiteButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.HelpButton, "HelpButton");
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HelpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HelpButton.ForeColor = System.Drawing.Color.Black;
            this.HelpButton.Name = "HelpButton";
            this.Tips.SetToolTip(this.HelpButton, resources.GetString("HelpButton.ToolTip"));
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonsPanel.Controls.Add(this.DropdownPanel);
            this.ButtonsPanel.Controls.Add(this.EncodeButton);
            this.ButtonsPanel.Controls.Add(this.ShowKeyButton);
            this.ButtonsPanel.Controls.Add(this.OptionsPanel);
            resources.ApplyResources(this.ButtonsPanel, "ButtonsPanel");
            this.ButtonsPanel.Name = "ButtonsPanel";
            // 
            // DropdownPanel
            // 
            this.DropdownPanel.Controls.Add(this.SetCipherButton);
            this.DropdownPanel.Controls.Add(this.UpperBorder);
            this.DropdownPanel.Controls.Add(this.MiddleBorder);
            this.DropdownPanel.Controls.Add(this.BottomBorder);
            this.DropdownPanel.Controls.Add(this.RightBorder);
            this.DropdownPanel.Controls.Add(this.LeftBorder);
            this.DropdownPanel.Controls.Add(this.CiphersComboBox);
            this.DropdownPanel.Controls.Add(this.KeysComboBox);
            resources.ApplyResources(this.DropdownPanel, "DropdownPanel");
            this.DropdownPanel.Name = "DropdownPanel";
            // 
            // SetCipherButton
            // 
            this.SetCipherButton.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.SetCipherButton, "SetCipherButton");
            this.SetCipherButton.FlatAppearance.BorderSize = 0;
            this.SetCipherButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SetCipherButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.SetCipherButton.ForeColor = System.Drawing.Color.Black;
            this.SetCipherButton.Name = "SetCipherButton";
            this.Tips.SetToolTip(this.SetCipherButton, resources.GetString("SetCipherButton.ToolTip"));
            this.SetCipherButton.UseVisualStyleBackColor = false;
            this.SetCipherButton.Click += new System.EventHandler(this.SetCipherButton_Click);
            // 
            // UpperBorder
            // 
            resources.ApplyResources(this.UpperBorder, "UpperBorder");
            this.UpperBorder.Name = "UpperBorder";
            // 
            // MiddleBorder
            // 
            resources.ApplyResources(this.MiddleBorder, "MiddleBorder");
            this.MiddleBorder.Name = "MiddleBorder";
            // 
            // BottomBorder
            // 
            resources.ApplyResources(this.BottomBorder, "BottomBorder");
            this.BottomBorder.Name = "BottomBorder";
            // 
            // RightBorder
            // 
            resources.ApplyResources(this.RightBorder, "RightBorder");
            this.RightBorder.Name = "RightBorder";
            // 
            // LeftBorder
            // 
            resources.ApplyResources(this.LeftBorder, "LeftBorder");
            this.LeftBorder.Name = "LeftBorder";
            // 
            // CiphersComboBox
            // 
            resources.ApplyResources(this.CiphersComboBox, "CiphersComboBox");
            this.CiphersComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CiphersComboBox.ForeColor = System.Drawing.Color.Black;
            this.CiphersComboBox.FormattingEnabled = true;
            this.CiphersComboBox.Name = "CiphersComboBox";
            this.CiphersComboBox.SelectedIndexChanged += new System.EventHandler(this.CiphersComboBox_SelectedIndexChanged);
            this.CiphersComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CiphersComboBox_MouseClick);
            // 
            // KeysComboBox
            // 
            resources.ApplyResources(this.KeysComboBox, "KeysComboBox");
            this.KeysComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.KeysComboBox.ForeColor = System.Drawing.Color.Black;
            this.KeysComboBox.FormattingEnabled = true;
            this.KeysComboBox.Name = "KeysComboBox";
            this.KeysComboBox.SelectedIndexChanged += new System.EventHandler(this.KeysComboBox_SelectedIndexChanged);
            this.KeysComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KeysComboBox_MouseClick);
            // 
            // GitHubButton
            // 
            this.GitHubButton.BackColor = System.Drawing.Color.Transparent;
            this.GitHubButton.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_github;
            resources.ApplyResources(this.GitHubButton, "GitHubButton");
            this.GitHubButton.FlatAppearance.BorderSize = 0;
            this.GitHubButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GitHubButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GitHubButton.ForeColor = System.Drawing.Color.Black;
            this.GitHubButton.Name = "GitHubButton";
            this.Tips.SetToolTip(this.GitHubButton, resources.GetString("GitHubButton.ToolTip"));
            this.GitHubButton.UseVisualStyleBackColor = false;
            this.GitHubButton.Click += new System.EventHandler(this.GitHubButton_Click);
            // 
            // DocsButton
            // 
            this.DocsButton.BackColor = System.Drawing.Color.Transparent;
            this.DocsButton.BackgroundImage = global::ScoutsEncoder.Properties.Resources.Icon_docs;
            resources.ApplyResources(this.DocsButton, "DocsButton");
            this.DocsButton.FlatAppearance.BorderSize = 0;
            this.DocsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DocsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DocsButton.ForeColor = System.Drawing.Color.Black;
            this.DocsButton.Name = "DocsButton";
            this.Tips.SetToolTip(this.DocsButton, resources.GetString("DocsButton.ToolTip"));
            this.DocsButton.UseVisualStyleBackColor = false;
            this.DocsButton.Click += new System.EventHandler(this.DocsButton_Click);
            // 
            // ThemeButton
            // 
            this.ThemeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ThemeButton.FlatAppearance.BorderSize = 0;
            this.ThemeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ThemeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.ThemeButton, "ThemeButton");
            this.ThemeButton.ForeColor = System.Drawing.Color.White;
            this.ThemeButton.Name = "ThemeButton";
            this.Tips.SetToolTip(this.ThemeButton, resources.GetString("ThemeButton.ToolTip"));
            this.ThemeButton.UseVisualStyleBackColor = false;
            this.ThemeButton.Click += new System.EventHandler(this.ThemeButton_Click);
            // 
            // DropdownTimer
            // 
            this.DropdownTimer.Enabled = true;
            this.DropdownTimer.Interval = 15;
            this.DropdownTimer.Tick += new System.EventHandler(this.DropdownTimer_Tick);
            // 
            // Tips
            // 
            this.Tips.AutoPopDelay = 5000;
            this.Tips.InitialDelay = 1000;
            this.Tips.IsBalloon = true;
            this.Tips.ReshowDelay = 100;
            // 
            // ExportAudio
            // 
            this.ExportAudio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExportAudio.BackgroundImage = global::ScoutsEncoder.Properties.Resources.DarkIcon_ExportAudio;
            resources.ApplyResources(this.ExportAudio, "ExportAudio");
            this.ExportAudio.FlatAppearance.BorderSize = 0;
            this.ExportAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.ExportAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.ExportAudio.Name = "ExportAudio";
            this.Tips.SetToolTip(this.ExportAudio, resources.GetString("ExportAudio.ToolTip"));
            this.ExportAudio.UseVisualStyleBackColor = false;
            this.ExportAudio.Click += new System.EventHandler(this.ExportAudio_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.AllowDrop = true;
            this.InputTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.InputTextBox, "InputTextBox");
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this.InputTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.OutputTextBox, "OutputTextBox");
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            // 
            // ScoutsEncoderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ExportAudio);
            this.Controls.Add(this.SideMenu);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InputTools);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.OutputTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScoutsEncoderForm";
            this.InputTools.ResumeLayout(false);
            this.OutputTools.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.SideMenu.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.DropdownPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Panel OptionsPanel;
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
        private System.Windows.Forms.Button SetCipherButton;
        private System.Windows.Forms.ComboBox CiphersComboBox;
        private System.Windows.Forms.ComboBox KeysComboBox;
        private System.Windows.Forms.Timer DropdownTimer;
        private System.Windows.Forms.Panel RightBorder;
        private System.Windows.Forms.Panel UpperBorder;
        private System.Windows.Forms.Panel BottomBorder;
        private System.Windows.Forms.Panel MiddleBorder;
        private System.Windows.Forms.Panel LeftBorder;
        private System.Windows.Forms.Button ThemeButton;
        private System.Windows.Forms.ToolTip Tips;
        private System.Windows.Forms.CheckBox FillShapes;
        private System.Windows.Forms.Button GitHubButton;
        private System.Windows.Forms.Button DocsButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button ExportAudio;
        private System.Windows.Forms.Button WebsiteButton;
        private System.Windows.Forms.Button HelpButton;
    }
}

