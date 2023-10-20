namespace PasswordMaker
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.passwordTag = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.clearPassword = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.seedMaker = new System.Windows.Forms.Button();
            this.seedClear = new System.Windows.Forms.Button();
            this.outputTimer = new System.Windows.Forms.Timer(this.components);
            this.PasswordSettings = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.extraMessage = new System.Windows.Forms.TextBox();
            this.extraTag = new System.Windows.Forms.Label();
            this.passwordLength = new System.Windows.Forms.NumericUpDown();
            this.lengthTag = new System.Windows.Forms.Label();
            this.settingTag = new System.Windows.Forms.Label();
            this.tagName = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.classTag = new System.Windows.Forms.Label();
            this.Symbol = new System.Windows.Forms.CheckBox();
            this.Capital = new System.Windows.Forms.CheckBox();
            this.Digit = new System.Windows.Forms.CheckBox();
            this.Lowcase = new System.Windows.Forms.CheckBox();
            this.keyLengthTip = new System.Windows.Forms.Label();
            this.PasswordSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLength)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTag
            // 
            this.passwordTag.AutoSize = true;
            this.passwordTag.Location = new System.Drawing.Point(16, 81);
            this.passwordTag.Name = "passwordTag";
            this.passwordTag.Size = new System.Drawing.Size(91, 20);
            this.passwordTag.TabIndex = 11;
            this.passwordTag.Text = "密钥(Key)：";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(102, 78);
            this.PasswordInput.MaxLength = 2;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.ShortcutsEnabled = false;
            this.PasswordInput.Size = new System.Drawing.Size(39, 27);
            this.PasswordInput.TabIndex = 1;
            this.PasswordInput.TextChanged += new System.EventHandler(this.PasswordInput_TextChanged);
            // 
            // clearPassword
            // 
            this.clearPassword.Location = new System.Drawing.Point(312, 78);
            this.clearPassword.Name = "clearPassword";
            this.clearPassword.Size = new System.Drawing.Size(86, 27);
            this.clearPassword.TabIndex = 9;
            this.clearPassword.Text = "清空Clear";
            this.clearPassword.UseVisualStyleBackColor = true;
            this.clearPassword.Click += new System.EventHandler(this.clearPassword_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(133, 303);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(147, 39);
            this.outputButton.TabIndex = 8;
            this.outputButton.Text = "输出密码(Output)";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // seedMaker
            // 
            this.seedMaker.Location = new System.Drawing.Point(16, 24);
            this.seedMaker.Name = "seedMaker";
            this.seedMaker.Size = new System.Drawing.Size(180, 32);
            this.seedMaker.TabIndex = 16;
            this.seedMaker.TabStop = false;
            this.seedMaker.Text = "创建种子(Make Seed)";
            this.seedMaker.UseVisualStyleBackColor = true;
            this.seedMaker.Click += new System.EventHandler(this.seedMaker_Click);
            // 
            // seedClear
            // 
            this.seedClear.Enabled = false;
            this.seedClear.Location = new System.Drawing.Point(215, 24);
            this.seedClear.Name = "seedClear";
            this.seedClear.Size = new System.Drawing.Size(180, 32);
            this.seedClear.TabIndex = 17;
            this.seedClear.TabStop = false;
            this.seedClear.Text = "清除种子(Clear Seed)";
            this.seedClear.UseVisualStyleBackColor = true;
            this.seedClear.Click += new System.EventHandler(this.seedClear_Click);
            // 
            // outputTimer
            // 
            this.outputTimer.Interval = 3000;
            this.outputTimer.Tick += new System.EventHandler(this.outputTimer_Tick);
            // 
            // PasswordSettings
            // 
            this.PasswordSettings.Controls.Add(this.deleteButton);
            this.PasswordSettings.Controls.Add(this.extraMessage);
            this.PasswordSettings.Controls.Add(this.extraTag);
            this.PasswordSettings.Controls.Add(this.passwordLength);
            this.PasswordSettings.Controls.Add(this.lengthTag);
            this.PasswordSettings.Controls.Add(this.settingTag);
            this.PasswordSettings.Controls.Add(this.tagName);
            this.PasswordSettings.Controls.Add(this.saveButton);
            this.PasswordSettings.Controls.Add(this.classTag);
            this.PasswordSettings.Controls.Add(this.Symbol);
            this.PasswordSettings.Controls.Add(this.Capital);
            this.PasswordSettings.Controls.Add(this.Digit);
            this.PasswordSettings.Controls.Add(this.Lowcase);
            this.PasswordSettings.Location = new System.Drawing.Point(16, 111);
            this.PasswordSettings.Name = "PasswordSettings";
            this.PasswordSettings.Size = new System.Drawing.Size(396, 186);
            this.PasswordSettings.TabIndex = 2;
            this.PasswordSettings.TabStop = false;
            this.PasswordSettings.Text = "生成选项";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(293, 60);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(86, 27);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "删除Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // extraMessage
            // 
            this.extraMessage.Location = new System.Drawing.Point(100, 93);
            this.extraMessage.Name = "extraMessage";
            this.extraMessage.Size = new System.Drawing.Size(279, 27);
            this.extraMessage.TabIndex = 3;
            // 
            // extraTag
            // 
            this.extraTag.AutoSize = true;
            this.extraTag.Location = new System.Drawing.Point(10, 97);
            this.extraTag.Name = "extraTag";
            this.extraTag.Size = new System.Drawing.Size(84, 20);
            this.extraTag.TabIndex = 18;
            this.extraTag.Text = "附加信息：";
            // 
            // passwordLength
            // 
            this.passwordLength.Location = new System.Drawing.Point(100, 60);
            this.passwordLength.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.passwordLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.passwordLength.Name = "passwordLength";
            this.passwordLength.Size = new System.Drawing.Size(187, 27);
            this.passwordLength.TabIndex = 2;
            this.passwordLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lengthTag
            // 
            this.lengthTag.AutoSize = true;
            this.lengthTag.Location = new System.Drawing.Point(40, 65);
            this.lengthTag.Name = "lengthTag";
            this.lengthTag.Size = new System.Drawing.Size(54, 20);
            this.lengthTag.TabIndex = 16;
            this.lengthTag.Text = "长度：";
            // 
            // settingTag
            // 
            this.settingTag.AutoSize = true;
            this.settingTag.Location = new System.Drawing.Point(40, 29);
            this.settingTag.Name = "settingTag";
            this.settingTag.Size = new System.Drawing.Size(54, 20);
            this.settingTag.TabIndex = 13;
            this.settingTag.Text = "标签：";
            // 
            // tagName
            // 
            this.tagName.DisplayMember = "name";
            this.tagName.FormattingEnabled = true;
            this.tagName.Location = new System.Drawing.Point(100, 26);
            this.tagName.Name = "tagName";
            this.tagName.Size = new System.Drawing.Size(187, 28);
            this.tagName.TabIndex = 1;
            this.tagName.SelectedIndexChanged += new System.EventHandler(this.tagName_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(293, 26);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 27);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "保存Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // classTag
            // 
            this.classTag.AutoSize = true;
            this.classTag.Location = new System.Drawing.Point(25, 129);
            this.classTag.Name = "classTag";
            this.classTag.Size = new System.Drawing.Size(69, 20);
            this.classTag.TabIndex = 15;
            this.classTag.Text = "字符集：";
            // 
            // Symbol
            // 
            this.Symbol.AutoSize = true;
            this.Symbol.Location = new System.Drawing.Point(100, 127);
            this.Symbol.Name = "Symbol";
            this.Symbol.Size = new System.Drawing.Size(124, 24);
            this.Symbol.TabIndex = 4;
            this.Symbol.Text = "符号(symbol)";
            this.Symbol.UseVisualStyleBackColor = true;
            // 
            // Capital
            // 
            this.Capital.AutoSize = true;
            this.Capital.Location = new System.Drawing.Point(255, 156);
            this.Capital.Name = "Capital";
            this.Capital.Size = new System.Drawing.Size(127, 24);
            this.Capital.TabIndex = 7;
            this.Capital.Text = "大写字母(A-Z)";
            this.Capital.UseVisualStyleBackColor = true;
            // 
            // Digit
            // 
            this.Digit.AutoSize = true;
            this.Digit.Location = new System.Drawing.Point(255, 127);
            this.Digit.Name = "Digit";
            this.Digit.Size = new System.Drawing.Size(95, 24);
            this.Digit.TabIndex = 5;
            this.Digit.Text = "数字(0-9)";
            this.Digit.UseVisualStyleBackColor = true;
            // 
            // Lowcase
            // 
            this.Lowcase.AutoSize = true;
            this.Lowcase.Location = new System.Drawing.Point(100, 156);
            this.Lowcase.Name = "Lowcase";
            this.Lowcase.Size = new System.Drawing.Size(122, 24);
            this.Lowcase.TabIndex = 6;
            this.Lowcase.Text = "小写字母(a-z)";
            this.Lowcase.UseVisualStyleBackColor = true;
            // 
            // keyLengthTip
            // 
            this.keyLengthTip.AutoSize = true;
            this.keyLengthTip.Location = new System.Drawing.Point(147, 81);
            this.keyLengthTip.Name = "keyLengthTip";
            this.keyLengthTip.Size = new System.Drawing.Size(78, 20);
            this.keyLengthTip.TabIndex = 18;
            this.keyLengthTip.Text = "已输入0位";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 351);
            this.Controls.Add(this.keyLengthTip);
            this.Controls.Add(this.PasswordSettings);
            this.Controls.Add(this.seedClear);
            this.Controls.Add(this.seedMaker);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.clearPassword);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.passwordTag);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "PasswordMaker";
            this.TopMost = true;
            this.PasswordSettings.ResumeLayout(false);
            this.PasswordSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label passwordTag;
        private TextBox PasswordInput;
        private Button clearPassword;
        private Button outputButton;
        private Button seedMaker;
        private Button seedClear;
        private System.Windows.Forms.Timer outputTimer;
        private GroupBox PasswordSettings;
        private Label classTag;
        private Button saveButton;
        private Label settingTag;
        private Label lengthTag;
        private Button deleteButton;
        private Label extraTag;
        private Label keyLengthTip;
        public CheckBox Lowcase;
        public CheckBox Capital;
        public CheckBox Digit;
        public CheckBox Symbol;
        public ComboBox tagName;
        public NumericUpDown passwordLength;
        public TextBox extraMessage;
    }
}