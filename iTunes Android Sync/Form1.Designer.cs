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
            this.fSync_button = new System.Windows.Forms.Button();
            this.bSync_button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.syncPlaylists_checkbox = new System.Windows.Forms.CheckBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.cleanSync_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fSync_button
            // 
            this.fSync_button.AccessibleDescription = "";
            this.fSync_button.AccessibleName = "";
            this.fSync_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fSync_button.Location = new System.Drawing.Point(410, 179);
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
            this.bSync_button.Location = new System.Drawing.Point(410, 224);
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
            this.progressBar.Location = new System.Drawing.Point(12, 269);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(511, 23);
            this.progressBar.TabIndex = 2;
            this.toolTip1.SetToolTip(this.progressBar, "Shows the progress of the application. This will stop if an error occurs.");
            this.progressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // syncPlaylists_checkbox
            // 
            this.syncPlaylists_checkbox.AutoSize = true;
            this.syncPlaylists_checkbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncPlaylists_checkbox.Location = new System.Drawing.Point(410, 156);
            this.syncPlaylists_checkbox.Name = "syncPlaylists_checkbox";
            this.syncPlaylists_checkbox.Size = new System.Drawing.Size(113, 20);
            this.syncPlaylists_checkbox.TabIndex = 3;
            this.syncPlaylists_checkbox.Text = "Sync playlists";
            this.syncPlaylists_checkbox.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.console.DetectUrls = false;
            this.console.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(12, 12);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(385, 251);
            this.console.TabIndex = 4;
            this.console.TabStop = false;
            this.console.Text = "";
            this.toolTip1.SetToolTip(this.console, "This will show both information and errors regarding the application.");
            this.console.WordWrap = false;
            // 
            // cleanSync_checkbox
            // 
            this.cleanSync_checkbox.AutoSize = true;
            this.cleanSync_checkbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F);
            this.cleanSync_checkbox.Location = new System.Drawing.Point(410, 130);
            this.cleanSync_checkbox.Name = "cleanSync_checkbox";
            this.cleanSync_checkbox.Size = new System.Drawing.Size(95, 20);
            this.cleanSync_checkbox.TabIndex = 5;
            this.cleanSync_checkbox.Text = "Clean Sync";
            this.cleanSync_checkbox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 304);
            this.Controls.Add(this.cleanSync_checkbox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.syncPlaylists_checkbox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bSync_button);
            this.Controls.Add(this.fSync_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}

