namespace SignInApp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainWindowTabs = new System.Windows.Forms.TabControl();
            this.signIn = new System.Windows.Forms.TabPage();
            this.signInContents = new System.Windows.Forms.SplitContainer();
            this.signInInfoSplit = new System.Windows.Forms.SplitContainer();
            this.startScanningButton = new System.Windows.Forms.Button();
            this.signInButton = new System.Windows.Forms.Button();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.signInLabel = new System.Windows.Forms.Label();
            this.signedInList = new System.Windows.Forms.ListView();
            this.numberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeInColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allMembers = new System.Windows.Forms.TabPage();
            this.allMembersList = new System.Windows.Forms.ListView();
            this.allMembersNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allMembersFirstNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allMembersLastNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allMembersHoursColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuBar = new System.Windows.Forms.MainMenu(this.components);
            this.fileHeader = new System.Windows.Forms.MenuItem();
            this.exportHoursMenuItem = new System.Windows.Forms.MenuItem();
            this.csvExport = new System.Windows.Forms.MenuItem();
            this.jsonExport = new System.Windows.Forms.MenuItem();
            this.exportTeamInfoMenuItem = new System.Windows.Forms.MenuItem();
            this.exportTeamCSV = new System.Windows.Forms.MenuItem();
            this.exportTeamJSON = new System.Windows.Forms.MenuItem();
            this.editHeader = new System.Windows.Forms.MenuItem();
            this.changePasswordMenuItem = new System.Windows.Forms.MenuItem();
            this.usersHeader = new System.Windows.Forms.MenuItem();
            this.registerUserMenuItem = new System.Windows.Forms.MenuItem();
            this.deleteUserMenuItem = new System.Windows.Forms.MenuItem();
            this.mainWindowTabs.SuspendLayout();
            this.signIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signInContents)).BeginInit();
            this.signInContents.Panel1.SuspendLayout();
            this.signInContents.Panel2.SuspendLayout();
            this.signInContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signInInfoSplit)).BeginInit();
            this.signInInfoSplit.Panel1.SuspendLayout();
            this.signInInfoSplit.Panel2.SuspendLayout();
            this.signInInfoSplit.SuspendLayout();
            this.allMembers.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWindowTabs
            // 
            this.mainWindowTabs.Controls.Add(this.signIn);
            this.mainWindowTabs.Controls.Add(this.allMembers);
            this.mainWindowTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowTabs.Location = new System.Drawing.Point(0, 0);
            this.mainWindowTabs.Name = "mainWindowTabs";
            this.mainWindowTabs.SelectedIndex = 0;
            this.mainWindowTabs.Size = new System.Drawing.Size(784, 561);
            this.mainWindowTabs.TabIndex = 0;
            // 
            // signIn
            // 
            this.signIn.Controls.Add(this.signInContents);
            this.signIn.Location = new System.Drawing.Point(4, 22);
            this.signIn.Name = "signIn";
            this.signIn.Padding = new System.Windows.Forms.Padding(3);
            this.signIn.Size = new System.Drawing.Size(776, 535);
            this.signIn.TabIndex = 0;
            this.signIn.Text = "Sign In/Out";
            this.signIn.UseVisualStyleBackColor = true;
            // 
            // signInContents
            // 
            this.signInContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signInContents.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.signInContents.Location = new System.Drawing.Point(3, 3);
            this.signInContents.Name = "signInContents";
            // 
            // signInContents.Panel1
            // 
            this.signInContents.Panel1.Controls.Add(this.signInInfoSplit);
            // 
            // signInContents.Panel2
            // 
            this.signInContents.Panel2.AutoScroll = true;
            this.signInContents.Panel2.Controls.Add(this.signedInList);
            this.signInContents.Size = new System.Drawing.Size(770, 529);
            this.signInContents.SplitterDistance = 371;
            this.signInContents.TabIndex = 0;
            // 
            // signInInfoSplit
            // 
            this.signInInfoSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signInInfoSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.signInInfoSplit.Location = new System.Drawing.Point(0, 0);
            this.signInInfoSplit.Name = "signInInfoSplit";
            this.signInInfoSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // signInInfoSplit.Panel1
            // 
            this.signInInfoSplit.Panel1.Controls.Add(this.startScanningButton);
            this.signInInfoSplit.Panel1.Controls.Add(this.signInButton);
            this.signInInfoSplit.Panel1.Controls.Add(this.numberBox);
            this.signInInfoSplit.Panel1.Controls.Add(this.numberLabel);
            this.signInInfoSplit.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // signInInfoSplit.Panel2
            // 
            this.signInInfoSplit.Panel2.Controls.Add(this.signInLabel);
            this.signInInfoSplit.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.signInInfoSplit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.signInInfoSplit.Size = new System.Drawing.Size(371, 529);
            this.signInInfoSplit.SplitterDistance = 277;
            this.signInInfoSplit.TabIndex = 0;
            // 
            // startScanningButton
            // 
            this.startScanningButton.Location = new System.Drawing.Point(4, 50);
            this.startScanningButton.Name = "startScanningButton";
            this.startScanningButton.Size = new System.Drawing.Size(356, 23);
            this.startScanningButton.TabIndex = 3;
            this.startScanningButton.Text = "Start Scanning";
            this.startScanningButton.UseVisualStyleBackColor = true;
            this.startScanningButton.Click += new System.EventHandler(this.startScanningButton_Click);
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(278, 22);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(82, 24);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(3, 24);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(269, 20);
            this.numberBox.TabIndex = 1;
            this.numberBox.WordWrap = false;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.Location = new System.Drawing.Point(0, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(134, 20);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "Student Number: ";
            // 
            // signInLabel
            // 
            this.signInLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signInLabel.AutoSize = true;
            this.signInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInLabel.Location = new System.Drawing.Point(5, 0);
            this.signInLabel.Name = "signInLabel";
            this.signInLabel.Size = new System.Drawing.Size(0, 31);
            this.signInLabel.TabIndex = 0;
            this.signInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signedInList
            // 
            this.signedInList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.signedInList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.firstNameColumn,
            this.lastNameColumn,
            this.timeInColumn});
            this.signedInList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signedInList.FullRowSelect = true;
            this.signedInList.GridLines = true;
            this.signedInList.Location = new System.Drawing.Point(0, 0);
            this.signedInList.MultiSelect = false;
            this.signedInList.Name = "signedInList";
            this.signedInList.Size = new System.Drawing.Size(395, 529);
            this.signedInList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.signedInList.TabIndex = 0;
            this.signedInList.UseCompatibleStateImageBehavior = false;
            this.signedInList.View = System.Windows.Forms.View.Details;
            this.signedInList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.signedInList_ColumnClick);
            // 
            // numberColumn
            // 
            this.numberColumn.Text = "Number";
            this.numberColumn.Width = 143;
            // 
            // firstNameColumn
            // 
            this.firstNameColumn.Text = "First Name";
            // 
            // lastNameColumn
            // 
            this.lastNameColumn.Text = "Last Name";
            // 
            // timeInColumn
            // 
            this.timeInColumn.Text = "Time In";
            // 
            // allMembers
            // 
            this.allMembers.Controls.Add(this.allMembersList);
            this.allMembers.Location = new System.Drawing.Point(4, 22);
            this.allMembers.Name = "allMembers";
            this.allMembers.Padding = new System.Windows.Forms.Padding(3);
            this.allMembers.Size = new System.Drawing.Size(776, 535);
            this.allMembers.TabIndex = 1;
            this.allMembers.Text = "All Members";
            this.allMembers.UseVisualStyleBackColor = true;
            // 
            // allMembersList
            // 
            this.allMembersList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.allMembersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.allMembersNumberColumn,
            this.allMembersFirstNameColumn,
            this.allMembersLastNameColumn,
            this.allMembersHoursColumn});
            this.allMembersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allMembersList.FullRowSelect = true;
            this.allMembersList.GridLines = true;
            this.allMembersList.Location = new System.Drawing.Point(3, 3);
            this.allMembersList.MultiSelect = false;
            this.allMembersList.Name = "allMembersList";
            this.allMembersList.Size = new System.Drawing.Size(770, 529);
            this.allMembersList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.allMembersList.TabIndex = 1;
            this.allMembersList.UseCompatibleStateImageBehavior = false;
            this.allMembersList.View = System.Windows.Forms.View.Details;
            this.allMembersList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.allMembersList_ColumnClick);
            this.allMembersList.ItemActivate += new System.EventHandler(this.memberList_DoubleClick);
            // 
            // allMembersNumberColumn
            // 
            this.allMembersNumberColumn.Text = "Number";
            this.allMembersNumberColumn.Width = 143;
            // 
            // allMembersFirstNameColumn
            // 
            this.allMembersFirstNameColumn.Text = "First Name";
            // 
            // allMembersLastNameColumn
            // 
            this.allMembersLastNameColumn.Text = "Last Name";
            // 
            // allMembersHoursColumn
            // 
            this.allMembersHoursColumn.Text = "Hours";
            // 
            // menuBar
            // 
            this.menuBar.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileHeader,
            this.editHeader,
            this.usersHeader});
            // 
            // fileHeader
            // 
            this.fileHeader.Index = 0;
            this.fileHeader.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.exportHoursMenuItem,
            this.exportTeamInfoMenuItem});
            this.fileHeader.Text = "File";
            // 
            // exportHoursMenuItem
            // 
            this.exportHoursMenuItem.Index = 0;
            this.exportHoursMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.csvExport,
            this.jsonExport});
            this.exportHoursMenuItem.Text = "Export Hours";
            // 
            // csvExport
            // 
            this.csvExport.Index = 0;
            this.csvExport.Text = "CSV";
            this.csvExport.Click += new System.EventHandler(this.csvExport_Click);
            // 
            // jsonExport
            // 
            this.jsonExport.Index = 1;
            this.jsonExport.Text = "JSON";
            this.jsonExport.Click += new System.EventHandler(this.jsonExport_Click);
            // 
            // exportTeamInfoMenuItem
            // 
            this.exportTeamInfoMenuItem.Index = 1;
            this.exportTeamInfoMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.exportTeamCSV,
            this.exportTeamJSON});
            this.exportTeamInfoMenuItem.Text = "Export Team Info";
            // 
            // exportTeamCSV
            // 
            this.exportTeamCSV.Index = 0;
            this.exportTeamCSV.Text = "CSV";
            this.exportTeamCSV.Click += new System.EventHandler(this.exportTeamCSV_Click);
            // 
            // exportTeamJSON
            // 
            this.exportTeamJSON.Index = 1;
            this.exportTeamJSON.Text = "JSON";
            this.exportTeamJSON.Click += new System.EventHandler(this.exportTeamJSON_Click);
            // 
            // editHeader
            // 
            this.editHeader.Index = 1;
            this.editHeader.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.changePasswordMenuItem});
            this.editHeader.Text = "Edit";
            // 
            // changePasswordMenuItem
            // 
            this.changePasswordMenuItem.Index = 0;
            this.changePasswordMenuItem.Text = "Change Password";
            this.changePasswordMenuItem.Click += new System.EventHandler(this.changePasswordMenuItem_Click);
            // 
            // usersHeader
            // 
            this.usersHeader.Index = 2;
            this.usersHeader.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.registerUserMenuItem,
            this.deleteUserMenuItem});
            this.usersHeader.Text = "Users";
            // 
            // registerUserMenuItem
            // 
            this.registerUserMenuItem.Index = 0;
            this.registerUserMenuItem.Text = "Register User";
            this.registerUserMenuItem.Click += new System.EventHandler(this.registerUser_Click);
            // 
            // deleteUserMenuItem
            // 
            this.deleteUserMenuItem.Index = 1;
            this.deleteUserMenuItem.Text = "Delete User";
            this.deleteUserMenuItem.Click += new System.EventHandler(this.deleteUserMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.signInButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainWindowTabs);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Sign In App";
            this.mainWindowTabs.ResumeLayout(false);
            this.signIn.ResumeLayout(false);
            this.signInContents.Panel1.ResumeLayout(false);
            this.signInContents.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.signInContents)).EndInit();
            this.signInContents.ResumeLayout(false);
            this.signInInfoSplit.Panel1.ResumeLayout(false);
            this.signInInfoSplit.Panel1.PerformLayout();
            this.signInInfoSplit.Panel2.ResumeLayout(false);
            this.signInInfoSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signInInfoSplit)).EndInit();
            this.signInInfoSplit.ResumeLayout(false);
            this.allMembers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage signIn;
        private System.Windows.Forms.TabPage allMembers;
        private System.Windows.Forms.SplitContainer signInContents;
        private System.Windows.Forms.SplitContainer signInInfoSplit;
        private System.Windows.Forms.Label signInLabel;
        private System.Windows.Forms.ListView signedInList;
        private System.Windows.Forms.ColumnHeader numberColumn;
        private System.Windows.Forms.ColumnHeader firstNameColumn;
        private System.Windows.Forms.ColumnHeader lastNameColumn;
        private System.Windows.Forms.ColumnHeader timeInColumn;
        private System.Windows.Forms.MainMenu menuBar;
        private System.Windows.Forms.MenuItem fileHeader;
        private System.Windows.Forms.MenuItem exportHoursMenuItem;
        private System.Windows.Forms.MenuItem editHeader;
        private System.Windows.Forms.MenuItem changePasswordMenuItem;
        private System.Windows.Forms.MenuItem usersHeader;
        private System.Windows.Forms.MenuItem registerUserMenuItem;
        private System.Windows.Forms.MenuItem deleteUserMenuItem;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.ListView allMembersList;
        private System.Windows.Forms.ColumnHeader allMembersNumberColumn;
        private System.Windows.Forms.ColumnHeader allMembersFirstNameColumn;
        private System.Windows.Forms.ColumnHeader allMembersLastNameColumn;
        private System.Windows.Forms.ColumnHeader allMembersHoursColumn;
        private System.Windows.Forms.TabControl mainWindowTabs;
        private System.Windows.Forms.MenuItem csvExport;
        private System.Windows.Forms.MenuItem jsonExport;
        private System.Windows.Forms.MenuItem exportTeamInfoMenuItem;
        private System.Windows.Forms.MenuItem exportTeamCSV;
        private System.Windows.Forms.MenuItem exportTeamJSON;
        private System.Windows.Forms.Button startScanningButton;
    }
}

