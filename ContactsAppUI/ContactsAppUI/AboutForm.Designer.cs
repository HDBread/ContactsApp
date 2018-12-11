namespace ContactsApp
{
    partial class AboutForm
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
            this.ContactsLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AutorLabel = new System.Windows.Forms.Label();
            this.GitLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.CopyRightLabel = new System.Windows.Forms.Label();
            this.EmailLink = new System.Windows.Forms.LinkLabel();
            this.GitLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ContactsLabel
            // 
            this.ContactsLabel.AutoSize = true;
            this.ContactsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactsLabel.Location = new System.Drawing.Point(12, 31);
            this.ContactsLabel.Name = "ContactsLabel";
            this.ContactsLabel.Size = new System.Drawing.Size(160, 29);
            this.ContactsLabel.TabIndex = 0;
            this.ContactsLabel.Text = "ContactsApp";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VersionLabel.Location = new System.Drawing.Point(14, 75);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(48, 16);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v. 1.0.0";
            // 
            // AutorLabel
            // 
            this.AutorLabel.AutoSize = true;
            this.AutorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutorLabel.Location = new System.Drawing.Point(14, 138);
            this.AutorLabel.Name = "AutorLabel";
            this.AutorLabel.Size = new System.Drawing.Size(151, 16);
            this.AutorLabel.TabIndex = 2;
            this.AutorLabel.Text = "Autor: Roman Moskalev";
            // 
            // GitLabel
            // 
            this.GitLabel.AutoSize = true;
            this.GitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GitLabel.Location = new System.Drawing.Point(14, 213);
            this.GitLabel.Name = "GitLabel";
            this.GitLabel.Size = new System.Drawing.Size(52, 16);
            this.GitLabel.TabIndex = 3;
            this.GitLabel.Text = "GitHub:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.Location = new System.Drawing.Point(14, 188);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(126, 16);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "e-mail for feedback:";
            // 
            // CopyRightLabel
            // 
            this.CopyRightLabel.AutoSize = true;
            this.CopyRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CopyRightLabel.Location = new System.Drawing.Point(12, 336);
            this.CopyRightLabel.Name = "CopyRightLabel";
            this.CopyRightLabel.Size = new System.Drawing.Size(156, 16);
            this.CopyRightLabel.TabIndex = 5;
            this.CopyRightLabel.Text = "2018 Roman Moskalev ©";
            // 
            // EmailLink
            // 
            this.EmailLink.AutoSize = true;
            this.EmailLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLink.Location = new System.Drawing.Point(136, 188);
            this.EmailLink.Name = "EmailLink";
            this.EmailLink.Size = new System.Drawing.Size(144, 16);
            this.EmailLink.TabIndex = 6;
            this.EmailLink.TabStop = true;
            this.EmailLink.Text = "moslik123@gmail.com";
            // 
            // GitLink
            // 
            this.GitLink.AutoSize = true;
            this.GitLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GitLink.Location = new System.Drawing.Point(63, 213);
            this.GitLink.Name = "GitLink";
            this.GitLink.Size = new System.Drawing.Size(146, 16);
            this.GitLink.TabIndex = 6;
            this.GitLink.TabStop = true;
            this.GitLink.Text = "HDBread/ContactsApp";
            this.GitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitLink_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.GitLink);
            this.Controls.Add(this.EmailLink);
            this.Controls.Add(this.CopyRightLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.GitLabel);
            this.Controls.Add(this.AutorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ContactsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContactsLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AutorLabel;
        private System.Windows.Forms.Label GitLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label CopyRightLabel;
        private System.Windows.Forms.LinkLabel EmailLink;
        private System.Windows.Forms.LinkLabel GitLink;
    }
}