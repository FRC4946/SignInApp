namespace SignInApp
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.infoSplit = new System.Windows.Forms.SplitContainer();
            this.hoursSpace = new System.Windows.Forms.Label();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.numberSpace = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.lastNameSpace = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameSpace = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.eventList = new System.Windows.Forms.ListView();
            this.eventListDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventListTimeInColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventListTimeOutColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventListHoursColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.infoSplit)).BeginInit();
            this.infoSplit.Panel1.SuspendLayout();
            this.infoSplit.Panel2.SuspendLayout();
            this.infoSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoSplit
            // 
            this.infoSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.infoSplit.Location = new System.Drawing.Point(0, 0);
            this.infoSplit.Name = "infoSplit";
            // 
            // infoSplit.Panel1
            // 
            this.infoSplit.Panel1.Controls.Add(this.hoursSpace);
            this.infoSplit.Panel1.Controls.Add(this.hoursLabel);
            this.infoSplit.Panel1.Controls.Add(this.numberSpace);
            this.infoSplit.Panel1.Controls.Add(this.numberLabel);
            this.infoSplit.Panel1.Controls.Add(this.lastNameSpace);
            this.infoSplit.Panel1.Controls.Add(this.lastNameLabel);
            this.infoSplit.Panel1.Controls.Add(this.firstNameSpace);
            this.infoSplit.Panel1.Controls.Add(this.firstNameLabel);
            // 
            // infoSplit.Panel2
            // 
            this.infoSplit.Panel2.Controls.Add(this.eventList);
            this.infoSplit.Size = new System.Drawing.Size(784, 561);
            this.infoSplit.SplitterDistance = 325;
            this.infoSplit.TabIndex = 0;
            // 
            // hoursSpace
            // 
            this.hoursSpace.AutoSize = true;
            this.hoursSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursSpace.Location = new System.Drawing.Point(13, 422);
            this.hoursSpace.Name = "hoursSpace";
            this.hoursSpace.Size = new System.Drawing.Size(0, 24);
            this.hoursSpace.TabIndex = 7;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursLabel.Location = new System.Drawing.Point(13, 398);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(164, 24);
            this.hoursLabel.TabIndex = 6;
            this.hoursLabel.Text = "Hours On Record:";
            // 
            // numberSpace
            // 
            this.numberSpace.AutoSize = true;
            this.numberSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberSpace.Location = new System.Drawing.Point(13, 294);
            this.numberSpace.Name = "numberSpace";
            this.numberSpace.Size = new System.Drawing.Size(0, 24);
            this.numberSpace.TabIndex = 5;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.Location = new System.Drawing.Point(13, 270);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(84, 24);
            this.numberLabel.TabIndex = 4;
            this.numberLabel.Text = "Number:";
            // 
            // lastNameSpace
            // 
            this.lastNameSpace.AutoSize = true;
            this.lastNameSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameSpace.Location = new System.Drawing.Point(13, 154);
            this.lastNameSpace.Name = "lastNameSpace";
            this.lastNameSpace.Size = new System.Drawing.Size(0, 24);
            this.lastNameSpace.TabIndex = 3;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(13, 130);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(104, 24);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // firstNameSpace
            // 
            this.firstNameSpace.AutoSize = true;
            this.firstNameSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameSpace.Location = new System.Drawing.Point(13, 37);
            this.firstNameSpace.Name = "firstNameSpace";
            this.firstNameSpace.Size = new System.Drawing.Size(0, 24);
            this.firstNameSpace.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(13, 13);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(106, 24);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name:";
            // 
            // eventList
            // 
            this.eventList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.eventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.eventListDateColumn,
            this.eventListTimeInColumn,
            this.eventListTimeOutColumn,
            this.eventListHoursColumn});
            this.eventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventList.FullRowSelect = true;
            this.eventList.GridLines = true;
            this.eventList.Location = new System.Drawing.Point(0, 0);
            this.eventList.MultiSelect = false;
            this.eventList.Name = "eventList";
            this.eventList.Size = new System.Drawing.Size(455, 561);
            this.eventList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.eventList.TabIndex = 2;
            this.eventList.UseCompatibleStateImageBehavior = false;
            this.eventList.View = System.Windows.Forms.View.Details;
            this.eventList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.eventList_ColumnClick);
            // 
            // eventListDateColumn
            // 
            this.eventListDateColumn.Text = "Date";
            this.eventListDateColumn.Width = 143;
            // 
            // eventListTimeInColumn
            // 
            this.eventListTimeInColumn.Text = "Time In";
            // 
            // eventListTimeOutColumn
            // 
            this.eventListTimeOutColumn.Text = "Time Out";
            // 
            // eventListHoursColumn
            // 
            this.eventListHoursColumn.Text = "Hours";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.infoSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "InfoForm";
            this.Text = "Info";
            this.infoSplit.Panel1.ResumeLayout(false);
            this.infoSplit.Panel1.PerformLayout();
            this.infoSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoSplit)).EndInit();
            this.infoSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer infoSplit;
        private System.Windows.Forms.ListView eventList;
        private System.Windows.Forms.ColumnHeader eventListDateColumn;
        private System.Windows.Forms.ColumnHeader eventListTimeInColumn;
        private System.Windows.Forms.ColumnHeader eventListTimeOutColumn;
        private System.Windows.Forms.ColumnHeader eventListHoursColumn;
        private System.Windows.Forms.Label hoursSpace;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label numberSpace;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label lastNameSpace;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameSpace;
        private System.Windows.Forms.Label firstNameLabel;
    }
}