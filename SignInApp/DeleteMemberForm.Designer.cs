namespace SignInApp
{
    partial class DeleteMemberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMemberForm));
            this.invalidMemberLabel = new System.Windows.Forms.Label();
            this.memberButton = new System.Windows.Forms.Button();
            this.memberBox = new System.Windows.Forms.TextBox();
            this.memberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // invalidMemberLabel
            // 
            this.invalidMemberLabel.AutoSize = true;
            this.invalidMemberLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidMemberLabel.Location = new System.Drawing.Point(19, 64);
            this.invalidMemberLabel.Name = "invalidMemberLabel";
            this.invalidMemberLabel.Size = new System.Drawing.Size(98, 13);
            this.invalidMemberLabel.TabIndex = 7;
            this.invalidMemberLabel.Text = "Member Not Found";
            this.invalidMemberLabel.Visible = false;
            // 
            // memberButton
            // 
            this.memberButton.Location = new System.Drawing.Point(339, 34);
            this.memberButton.Name = "memberButton";
            this.memberButton.Size = new System.Drawing.Size(75, 24);
            this.memberButton.TabIndex = 6;
            this.memberButton.Text = "Delete";
            this.memberButton.UseVisualStyleBackColor = true;
            this.memberButton.Click += new System.EventHandler(this.memberButton_Click);
            // 
            // memberBox
            // 
            this.memberBox.Location = new System.Drawing.Point(19, 36);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(313, 20);
            this.memberBox.TabIndex = 5;
            // 
            // memberLabel
            // 
            this.memberLabel.AutoSize = true;
            this.memberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.memberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberLabel.Location = new System.Drawing.Point(0, 0);
            this.memberLabel.Name = "memberLabel";
            this.memberLabel.Size = new System.Drawing.Size(160, 24);
            this.memberLabel.TabIndex = 4;
            this.memberLabel.Text = "Member Number:";
            // 
            // DeleteMemberForm
            // 
            this.AcceptButton = this.memberButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 84);
            this.Controls.Add(this.invalidMemberLabel);
            this.Controls.Add(this.memberButton);
            this.Controls.Add(this.memberBox);
            this.Controls.Add(this.memberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeleteMemberForm";
            this.Text = "Delete Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label invalidMemberLabel;
        private System.Windows.Forms.Button memberButton;
        private System.Windows.Forms.TextBox memberBox;
        private System.Windows.Forms.Label memberLabel;
    }
}