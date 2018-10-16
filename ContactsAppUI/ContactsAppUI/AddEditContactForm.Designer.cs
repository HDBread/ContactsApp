namespace ContactsApp
{
    partial class AddEditContactForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditContactForm));
            this.SubnameLabebl = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.SurnameTextbox = new System.Windows.Forms.TextBox();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.VkTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.VkLabel = new System.Windows.Forms.Label();
            this.BirthdayDayTool = new System.Windows.Forms.DateTimePicker();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.errorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // SubnameLabebl
            // 
            resources.ApplyResources(this.SubnameLabebl, "SubnameLabebl");
            this.SubnameLabebl.Name = "SubnameLabebl";
            // 
            // BirthdayLabel
            // 
            resources.ApplyResources(this.BirthdayLabel, "BirthdayLabel");
            this.BirthdayLabel.Name = "BirthdayLabel";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            // 
            // PhoneLabel
            // 
            resources.ApplyResources(this.PhoneLabel, "PhoneLabel");
            this.PhoneLabel.Name = "PhoneLabel";
            // 
            // SurnameTextbox
            // 
            resources.ApplyResources(this.SurnameTextbox, "SurnameTextbox");
            this.SurnameTextbox.Name = "SurnameTextbox";
            this.SurnameTextbox.TextChanged += new System.EventHandler(this.SurnameTextbox_TextChanged);
            // 
            // NameTextbox
            // 
            resources.ApplyResources(this.NameTextbox, "NameTextbox");
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.TextChanged += new System.EventHandler(this.NameTextbox_TextChanged);
            // 
            // PhoneTextbox
            // 
            resources.ApplyResources(this.PhoneTextbox, "PhoneTextbox");
            this.PhoneTextbox.Name = "PhoneTextbox";
            this.PhoneTextbox.TextChanged += new System.EventHandler(this.PhoneTextbox_TextChanged);
            this.PhoneTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneTextbox_KeyPress);
            // 
            // EmailTextbox
            // 
            resources.ApplyResources(this.EmailTextbox, "EmailTextbox");
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.TextChanged += new System.EventHandler(this.EmailTextbox_TextChanged);
            // 
            // VkTextbox
            // 
            resources.ApplyResources(this.VkTextbox, "VkTextbox");
            this.VkTextbox.Name = "VkTextbox";
            this.VkTextbox.TextChanged += new System.EventHandler(this.VkTextbox_TextChanged);
            // 
            // EmailLabel
            // 
            resources.ApplyResources(this.EmailLabel, "EmailLabel");
            this.EmailLabel.Name = "EmailLabel";
            // 
            // VkLabel
            // 
            resources.ApplyResources(this.VkLabel, "VkLabel");
            this.VkLabel.Name = "VkLabel";
            // 
            // BirthdayDayTool
            // 
            resources.ApplyResources(this.BirthdayDayTool, "BirthdayDayTool");
            this.BirthdayDayTool.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthdayDayTool.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.BirthdayDayTool.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BirthdayDayTool.Name = "BirthdayDayTool";
            this.BirthdayDayTool.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.BirthdayDayTool.ValueChanged += new System.EventHandler(this.BirthdayDayTool_ValueChanged);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // errorToolTip
            // 
            this.errorToolTip.AutomaticDelay = 800;
            this.errorToolTip.IsBalloon = true;
            this.errorToolTip.OwnerDraw = true;
            this.errorToolTip.ShowAlways = true;
            this.errorToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // AddEditContactForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.BirthdayDayTool);
            this.Controls.Add(this.VkTextbox);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.PhoneTextbox);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.SurnameTextbox);
            this.Controls.Add(this.VkLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.BirthdayLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SubnameLabebl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddEditContactForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SubnameLabebl;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox SurnameTextbox;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox VkTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label VkLabel;
        private System.Windows.Forms.DateTimePicker BirthdayDayTool;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ToolTip errorToolTip;
    }
}