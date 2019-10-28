namespace SignInApp
{
    partial class UpdatePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePasswordForm));
            this.updateButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.confirmNewPasswordBox = new System.Windows.Forms.TextBox();
            this.confirmNewLabel = new System.Windows.Forms.Label();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.formLabel = new System.Windows.Forms.Label();
            this.oldPasswordBox = new System.Windows.Forms.TextBox();
            this.oldPasswordLabel = new System.Windows.Forms.Label();
            this.errorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(268, 135);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(116, 24);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(15, 173);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 16;
            this.errorLabel.Visible = false;
            // 
            // confirmNewPasswordBox
            // 
            this.confirmNewPasswordBox.Location = new System.Drawing.Point(15, 137);
            this.confirmNewPasswordBox.Name = "confirmNewPasswordBox";
            this.confirmNewPasswordBox.PasswordChar = '*';
            this.confirmNewPasswordBox.Size = new System.Drawing.Size(247, 20);
            this.confirmNewPasswordBox.TabIndex = 15;
            // 
            // confirmNewLabel
            // 
            this.confirmNewLabel.AutoSize = true;
            this.confirmNewLabel.Location = new System.Drawing.Point(12, 120);
            this.confirmNewLabel.Name = "confirmNewLabel";
            this.confirmNewLabel.Size = new System.Drawing.Size(122, 13);
            this.confirmNewLabel.TabIndex = 14;
            this.confirmNewLabel.Text = "Confirm New Password: ";
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(15, 97);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.PasswordChar = '*';
            this.newPasswordBox.Size = new System.Drawing.Size(370, 20);
            this.newPasswordBox.TabIndex = 13;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(12, 80);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(84, 13);
            this.newPasswordLabel.TabIndex = 12;
            this.newPasswordLabel.Text = "New Password: ";
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabel.Location = new System.Drawing.Point(12, 9);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(162, 24);
            this.formLabel.TabIndex = 11;
            this.formLabel.Text = "Update Password:";
            // 
            // oldPasswordBox
            // 
            this.oldPasswordBox.Location = new System.Drawing.Point(15, 57);
            this.oldPasswordBox.Name = "oldPasswordBox";
            this.oldPasswordBox.PasswordChar = '*';
            this.oldPasswordBox.Size = new System.Drawing.Size(370, 20);
            this.oldPasswordBox.TabIndex = 10;
            // 
            // oldPasswordLabel
            // 
            this.oldPasswordLabel.AutoSize = true;
            this.oldPasswordLabel.Location = new System.Drawing.Point(12, 40);
            this.oldPasswordLabel.Name = "oldPasswordLabel";
            this.oldPasswordLabel.Size = new System.Drawing.Size(78, 13);
            this.oldPasswordLabel.TabIndex = 9;
            this.oldPasswordLabel.Text = "Old Password: ";
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(15, 172);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 13);
            this.errorMessage.TabIndex = 18;
            this.errorMessage.Visible = false;
            // 
            // UpdatePasswordForm
            // 
            this.AcceptButton = this.updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 197);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.confirmNewPasswordBox);
            this.Controls.Add(this.confirmNewLabel);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.formLabel);
            this.Controls.Add(this.oldPasswordBox);
            this.Controls.Add(this.oldPasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdatePasswordForm";
            this.Text = "Update Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox confirmNewPasswordBox;
        private System.Windows.Forms.Label confirmNewLabel;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.TextBox oldPasswordBox;
        private System.Windows.Forms.Label oldPasswordLabel;
        private System.Windows.Forms.Label errorMessage;
    }
}