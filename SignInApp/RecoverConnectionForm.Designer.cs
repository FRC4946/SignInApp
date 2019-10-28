namespace SignInApp
{
    partial class RecoverConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverConnectionForm));
            this.noConnectionLabel = new System.Windows.Forms.Label();
            this.retryLabel = new System.Windows.Forms.Label();
            this.retryButton = new System.Windows.Forms.Button();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noConnectionLabel
            // 
            this.noConnectionLabel.AutoSize = true;
            this.noConnectionLabel.Location = new System.Drawing.Point(13, 13);
            this.noConnectionLabel.Name = "noConnectionLabel";
            this.noConnectionLabel.Size = new System.Drawing.Size(164, 13);
            this.noConnectionLabel.TabIndex = 0;
            this.noConnectionLabel.Text = "No Internet Connection Detected";
            // 
            // retryLabel
            // 
            this.retryLabel.AutoSize = true;
            this.retryLabel.Location = new System.Drawing.Point(13, 26);
            this.retryLabel.Name = "retryLabel";
            this.retryLabel.Size = new System.Drawing.Size(145, 13);
            this.retryLabel.TabIndex = 1;
            this.retryLabel.Text = "Please Reconnect And Retry";
            // 
            // retryButton
            // 
            this.retryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.retryButton.Location = new System.Drawing.Point(16, 46);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(175, 23);
            this.retryButton.TabIndex = 2;
            this.retryButton.Text = "Retry";
            this.retryButton.UseVisualStyleBackColor = true;
            this.retryButton.Click += new System.EventHandler(this.retryButton_Click);
            // 
            // closeAppButton
            // 
            this.closeAppButton.Location = new System.Drawing.Point(197, 46);
            this.closeAppButton.Name = "closeAppButton";
            this.closeAppButton.Size = new System.Drawing.Size(75, 23);
            this.closeAppButton.TabIndex = 3;
            this.closeAppButton.Text = "Close App";
            this.closeAppButton.UseVisualStyleBackColor = true;
            this.closeAppButton.Click += new System.EventHandler(this.closeAppButton_Click);
            // 
            // RecoverConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.closeAppButton);
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.retryLabel);
            this.Controls.Add(this.noConnectionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RecoverConnectionForm";
            this.Text = "No Internet Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noConnectionLabel;
        private System.Windows.Forms.Label retryLabel;
        private System.Windows.Forms.Button retryButton;
        private System.Windows.Forms.Button closeAppButton;
    }
}