﻿namespace iTunes_Android_Sync
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
            this.fSync_button = new System.Windows.Forms.Button();
            this.bSync_button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.console = new System.Windows.Forms.RichTextBox();
            this.AndroidSyncDirectory = new System.Windows.Forms.TextBox();
            this.syncPlaylists_checkbox = new System.Windows.Forms.CheckBox();
            this.cleanSync_checkbox = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PCSyncDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.navigateDirectory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.XMLLibraryFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fSync_button
            // 
            this.fSync_button.AccessibleDescription = "";
            this.fSync_button.AccessibleName = "";
            this.fSync_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fSync_button.Location = new System.Drawing.Point(695, 318);
            this.fSync_button.Name = "fSync_button";
            this.fSync_button.Size = new System.Drawing.Size(113, 39);
            this.fSync_button.TabIndex = 0;
            this.fSync_button.Text = "Forward Sync";
            this.toolTip1.SetToolTip(this.fSync_button, "Syncs files from your computer to your Android device.");
            this.fSync_button.UseVisualStyleBackColor = true;
            this.fSync_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // bSync_button
            // 
            this.bSync_button.Enabled = false;
            this.bSync_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSync_button.Location = new System.Drawing.Point(695, 363);
            this.bSync_button.Name = "bSync_button";
            this.bSync_button.Size = new System.Drawing.Size(113, 39);
            this.bSync_button.TabIndex = 1;
            this.bSync_button.Text = "Backward Sync";
            this.toolTip1.SetToolTip(this.bSync_button, "Syncs files from your Android device to your computer.");
            this.bSync_button.UseVisualStyleBackColor = true;
            this.bSync_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(16, 408);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(792, 23);
            this.progressBar.TabIndex = 2;
            this.toolTip1.SetToolTip(this.progressBar, "Shows the progress of the application. This will stop if an error occurs.");
            this.progressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // console
            // 
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.console.DetectUrls = false;
            this.console.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(16, 131);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(673, 271);
            this.console.TabIndex = 4;
            this.console.TabStop = false;
            this.console.Text = "";
            this.toolTip1.SetToolTip(this.console, "This will show both information and errors regarding the application.");
            this.console.WordWrap = false;
            this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
            // 
            // AndroidSyncDirectory
            // 
            this.AndroidSyncDirectory.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AndroidSyncDirectory.Location = new System.Drawing.Point(187, 55);
            this.AndroidSyncDirectory.Name = "AndroidSyncDirectory";
            this.AndroidSyncDirectory.Size = new System.Drawing.Size(459, 20);
            this.AndroidSyncDirectory.TabIndex = 7;
            this.AndroidSyncDirectory.Text = "/sdcard/Music/";
            this.toolTip1.SetToolTip(this.AndroidSyncDirectory, "Do not modify unless you know what you\'re doing!");
            this.AndroidSyncDirectory.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // syncPlaylists_checkbox
            // 
            this.syncPlaylists_checkbox.AutoSize = true;
            this.syncPlaylists_checkbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncPlaylists_checkbox.Location = new System.Drawing.Point(695, 292);
            this.syncPlaylists_checkbox.Name = "syncPlaylists_checkbox";
            this.syncPlaylists_checkbox.Size = new System.Drawing.Size(113, 20);
            this.syncPlaylists_checkbox.TabIndex = 3;
            this.syncPlaylists_checkbox.Text = "Sync playlists";
            this.syncPlaylists_checkbox.UseVisualStyleBackColor = true;
            // 
            // cleanSync_checkbox
            // 
            this.cleanSync_checkbox.AutoSize = true;
            this.cleanSync_checkbox.Enabled = false;
            this.cleanSync_checkbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F);
            this.cleanSync_checkbox.Location = new System.Drawing.Point(695, 266);
            this.cleanSync_checkbox.Name = "cleanSync_checkbox";
            this.cleanSync_checkbox.Size = new System.Drawing.Size(95, 20);
            this.cleanSync_checkbox.TabIndex = 5;
            this.cleanSync_checkbox.Text = "Clean Sync";
            this.cleanSync_checkbox.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Android iTuneSync";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // PCSyncDirectory
            // 
            this.PCSyncDirectory.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCSyncDirectory.Location = new System.Drawing.Point(187, 16);
            this.PCSyncDirectory.Name = "PCSyncDirectory";
            this.PCSyncDirectory.Size = new System.Drawing.Size(459, 20);
            this.PCSyncDirectory.TabIndex = 6;
            this.PCSyncDirectory.Text = "C:/Users/Alan/Music/";
            this.PCSyncDirectory.TextChanged += new System.EventHandler(this.PCSyncDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "PC Sync Directory";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Android Sync Directory";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // navigateDirectory
            // 
            this.navigateDirectory.Location = new System.Drawing.Point(653, 16);
            this.navigateDirectory.Name = "navigateDirectory";
            this.navigateDirectory.Size = new System.Drawing.Size(32, 21);
            this.navigateDirectory.TabIndex = 10;
            this.navigateDirectory.Text = ">";
            this.navigateDirectory.UseVisualStyleBackColor = true;
            this.navigateDirectory.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lithos Pro Regular", 7F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(707, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Made by Alan Tai";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "iTunes XML Library File";
            // 
            // XMLLibraryFile
            // 
            this.XMLLibraryFile.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XMLLibraryFile.Location = new System.Drawing.Point(187, 93);
            this.XMLLibraryFile.Name = "XMLLibraryFile";
            this.XMLLibraryFile.Size = new System.Drawing.Size(459, 20);
            this.XMLLibraryFile.TabIndex = 13;
            this.XMLLibraryFile.Text = "C:/Users/Alan/Music/iTunes/iTunes Music Library.xml";
            this.toolTip1.SetToolTip(this.XMLLibraryFile, "This is only needed for the sync playlists  option!");
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 446);
            this.Controls.Add(this.XMLLibraryFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.navigateDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AndroidSyncDirectory);
            this.Controls.Add(this.PCSyncDirectory);
            this.Controls.Add(this.cleanSync_checkbox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.syncPlaylists_checkbox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bSync_button);
            this.Controls.Add(this.fSync_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Android iTuneSync";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fSync_button;
        private System.Windows.Forms.Button bSync_button;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox syncPlaylists_checkbox;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.CheckBox cleanSync_checkbox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox PCSyncDirectory;
        private System.Windows.Forms.TextBox AndroidSyncDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button navigateDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox XMLLibraryFile;
    }
}

