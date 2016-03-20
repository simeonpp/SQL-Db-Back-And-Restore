namespace SqlDbBackAndRestore.WindowsFormsClient
{
    partial class JobServiceApplication
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
            this.gbSqlServerDb = new System.Windows.Forms.GroupBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.gbDatabaseBackup = new System.Windows.Forms.GroupBox();
            this.labelDbBackupLocation = new System.Windows.Forms.Label();
            this.tbDbBackupLocation = new System.Windows.Forms.TextBox();
            this.btnDbBackupBrowse = new System.Windows.Forms.Button();
            this.btnDbBackup = new System.Windows.Forms.Button();
            this.gbDatabaseRestore = new System.Windows.Forms.GroupBox();
            this.labelDbRestoreBackupPath = new System.Windows.Forms.Label();
            this.tbBackupPath = new System.Windows.Forms.TextBox();
            this.btnDbRestoreBrowse = new System.Windows.Forms.Button();
            this.btnDbRestore = new System.Windows.Forms.Button();
            this.gbSqlServerDb.SuspendLayout();
            this.gbDatabaseBackup.SuspendLayout();
            this.gbDatabaseRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSqlServerDb
            // 
            this.gbSqlServerDb.Controls.Add(this.tbConnectionString);
            this.gbSqlServerDb.Controls.Add(this.labelConnectionString);
            this.gbSqlServerDb.Location = new System.Drawing.Point(12, 12);
            this.gbSqlServerDb.Name = "gbSqlServerDb";
            this.gbSqlServerDb.Size = new System.Drawing.Size(391, 60);
            this.gbSqlServerDb.TabIndex = 0;
            this.gbSqlServerDb.TabStop = false;
            this.gbSqlServerDb.Text = "SQL Server Database";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(6, 29);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(89, 13);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection string";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(94, 26);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(283, 20);
            this.tbConnectionString.TabIndex = 1;
            this.tbConnectionString.TextChanged += new System.EventHandler(this.tbDatabaseName_TextChanged);
            // 
            // gbDatabaseBackup
            // 
            this.gbDatabaseBackup.Controls.Add(this.btnDbBackup);
            this.gbDatabaseBackup.Controls.Add(this.btnDbBackupBrowse);
            this.gbDatabaseBackup.Controls.Add(this.tbDbBackupLocation);
            this.gbDatabaseBackup.Controls.Add(this.labelDbBackupLocation);
            this.gbDatabaseBackup.Location = new System.Drawing.Point(12, 88);
            this.gbDatabaseBackup.Name = "gbDatabaseBackup";
            this.gbDatabaseBackup.Size = new System.Drawing.Size(391, 112);
            this.gbDatabaseBackup.TabIndex = 1;
            this.gbDatabaseBackup.TabStop = false;
            this.gbDatabaseBackup.Text = "Database Backup";
            // 
            // labelDbBackupLocation
            // 
            this.labelDbBackupLocation.AutoSize = true;
            this.labelDbBackupLocation.Location = new System.Drawing.Point(9, 34);
            this.labelDbBackupLocation.Name = "labelDbBackupLocation";
            this.labelDbBackupLocation.Size = new System.Drawing.Size(48, 13);
            this.labelDbBackupLocation.TabIndex = 0;
            this.labelDbBackupLocation.Text = "Location";
            // 
            // tbDbBackupLocation
            // 
            this.tbDbBackupLocation.Location = new System.Drawing.Point(12, 50);
            this.tbDbBackupLocation.Name = "tbDbBackupLocation";
            this.tbDbBackupLocation.Size = new System.Drawing.Size(283, 20);
            this.tbDbBackupLocation.TabIndex = 1;
            // 
            // btnDbBackupBrowse
            // 
            this.btnDbBackupBrowse.Location = new System.Drawing.Point(301, 50);
            this.btnDbBackupBrowse.Name = "btnDbBackupBrowse";
            this.btnDbBackupBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDbBackupBrowse.TabIndex = 2;
            this.btnDbBackupBrowse.Text = "Browse";
            this.btnDbBackupBrowse.UseVisualStyleBackColor = true;
            this.btnDbBackupBrowse.Click += new System.EventHandler(this.btnDbBackupBrowse_Click);
            // 
            // btnDbBackup
            // 
            this.btnDbBackup.Location = new System.Drawing.Point(301, 79);
            this.btnDbBackup.Name = "btnDbBackup";
            this.btnDbBackup.Size = new System.Drawing.Size(75, 23);
            this.btnDbBackup.TabIndex = 3;
            this.btnDbBackup.Text = "Backup";
            this.btnDbBackup.UseVisualStyleBackColor = true;
            this.btnDbBackup.Click += new System.EventHandler(this.btnDbBackup_Click);
            // 
            // gbDatabaseRestore
            // 
            this.gbDatabaseRestore.Controls.Add(this.btnDbRestore);
            this.gbDatabaseRestore.Controls.Add(this.btnDbRestoreBrowse);
            this.gbDatabaseRestore.Controls.Add(this.tbBackupPath);
            this.gbDatabaseRestore.Controls.Add(this.labelDbRestoreBackupPath);
            this.gbDatabaseRestore.Location = new System.Drawing.Point(13, 232);
            this.gbDatabaseRestore.Name = "gbDatabaseRestore";
            this.gbDatabaseRestore.Size = new System.Drawing.Size(390, 107);
            this.gbDatabaseRestore.TabIndex = 2;
            this.gbDatabaseRestore.TabStop = false;
            this.gbDatabaseRestore.Text = "Database Restore";
            // 
            // labelDbRestoreBackupPath
            // 
            this.labelDbRestoreBackupPath.AutoSize = true;
            this.labelDbRestoreBackupPath.Location = new System.Drawing.Point(8, 32);
            this.labelDbRestoreBackupPath.Name = "labelDbRestoreBackupPath";
            this.labelDbRestoreBackupPath.Size = new System.Drawing.Size(69, 13);
            this.labelDbRestoreBackupPath.TabIndex = 0;
            this.labelDbRestoreBackupPath.Text = "Backup Path";
            // 
            // tbBackupPath
            // 
            this.tbBackupPath.Location = new System.Drawing.Point(11, 48);
            this.tbBackupPath.Name = "tbBackupPath";
            this.tbBackupPath.Size = new System.Drawing.Size(283, 20);
            this.tbBackupPath.TabIndex = 1;
            // 
            // btnDbRestoreBrowse
            // 
            this.btnDbRestoreBrowse.Location = new System.Drawing.Point(300, 48);
            this.btnDbRestoreBrowse.Name = "btnDbRestoreBrowse";
            this.btnDbRestoreBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDbRestoreBrowse.TabIndex = 2;
            this.btnDbRestoreBrowse.Text = "Browse";
            this.btnDbRestoreBrowse.UseVisualStyleBackColor = true;
            this.btnDbRestoreBrowse.Click += new System.EventHandler(this.btnDbRestoreBrowse_Click);
            // 
            // btnDbRestore
            // 
            this.btnDbRestore.Location = new System.Drawing.Point(300, 77);
            this.btnDbRestore.Name = "btnDbRestore";
            this.btnDbRestore.Size = new System.Drawing.Size(75, 23);
            this.btnDbRestore.TabIndex = 3;
            this.btnDbRestore.Text = "Restore";
            this.btnDbRestore.UseVisualStyleBackColor = true;
            this.btnDbRestore.Click += new System.EventHandler(this.btnDbRestore_Click);
            // 
            // JobServiceApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 364);
            this.Controls.Add(this.gbDatabaseRestore);
            this.Controls.Add(this.gbDatabaseBackup);
            this.Controls.Add(this.gbSqlServerDb);
            this.Name = "JobServiceApplication";
            this.Text = "Job Service Application - SQL Back and Restore";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSqlServerDb.ResumeLayout(false);
            this.gbSqlServerDb.PerformLayout();
            this.gbDatabaseBackup.ResumeLayout(false);
            this.gbDatabaseBackup.PerformLayout();
            this.gbDatabaseRestore.ResumeLayout(false);
            this.gbDatabaseRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSqlServerDb;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.GroupBox gbDatabaseBackup;
        private System.Windows.Forms.TextBox tbDbBackupLocation;
        private System.Windows.Forms.Label labelDbBackupLocation;
        private System.Windows.Forms.Button btnDbBackup;
        private System.Windows.Forms.Button btnDbBackupBrowse;
        private System.Windows.Forms.GroupBox gbDatabaseRestore;
        private System.Windows.Forms.Label labelDbRestoreBackupPath;
        private System.Windows.Forms.TextBox tbBackupPath;
        private System.Windows.Forms.Button btnDbRestore;
        private System.Windows.Forms.Button btnDbRestoreBrowse;
    }
}

