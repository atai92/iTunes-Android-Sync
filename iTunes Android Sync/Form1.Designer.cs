namespace iTunes_Android_Sync
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
            this.cleanSync_checkbox = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Settings_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fSync_button
            // 
            this.fSync_button.AccessibleDescription = "";
            this.fSync_button.AccessibleName = "";
            this.fSync_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fSync_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fSync_button.ForeColor = System.Drawing.Color.Black;
            this.fSync_button.Location = new System.Drawing.Point(383, 62);
            this.fSync_button.Name = "fSync_button";
            this.fSync_button.Size = new System.Drawing.Size(113, 45);
            this.fSync_button.TabIndex = 0;
            this.fSync_button.Text = "Forward Sync";
            this.toolTip1.SetToolTip(this.fSync_button, "Syncs files from your computer to your Android device.");
            this.fSync_button.UseVisualStyleBackColor = true;
            this.fSync_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // bSync_button
            // 
            this.bSync_button.Enabled = false;
            this.bSync_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSync_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSync_button.ForeColor = System.Drawing.Color.Black;
            this.bSync_button.Location = new System.Drawing.Point(383, 113);
            this.bSync_button.Name = "bSync_button";
            this.bSync_button.Size = new System.Drawing.Size(113, 45);
            this.bSync_button.TabIndex = 1;
            this.bSync_button.Text = "Backward Sync";
            this.toolTip1.SetToolTip(this.bSync_button, "Syncs files from your Android device to your computer.");
            this.bSync_button.UseVisualStyleBackColor = true;
            this.bSync_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressBar.Location = new System.Drawing.Point(15, 215);
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(481, 23);
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
            this.console.BackColor = System.Drawing.Color.White;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.console.DetectUrls = false;
            this.console.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ForeColor = System.Drawing.Color.Black;
            this.console.Location = new System.Drawing.Point(15, 12);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(362, 186);
            this.console.TabIndex = 4;
            this.console.TabStop = false;
            this.console.Text = "";
            this.toolTip1.SetToolTip(this.console, "This will show both information and errors regarding the application.");
            this.console.WordWrap = false;
            this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
            // 
            // cleanSync_checkbox
            // 
            this.cleanSync_checkbox.AutoSize = true;
            this.cleanSync_checkbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanSync_checkbox.ForeColor = System.Drawing.Color.Black;
            this.cleanSync_checkbox.Location = new System.Drawing.Point(399, 178);
            this.cleanSync_checkbox.Name = "cleanSync_checkbox";
            this.cleanSync_checkbox.Size = new System.Drawing.Size(95, 20);
            this.cleanSync_checkbox.TabIndex = 5;
            this.cleanSync_checkbox.Text = "Clean Sync";
            this.cleanSync_checkbox.UseVisualStyleBackColor = true;
            this.cleanSync_checkbox.CheckedChanged += new System.EventHandler(this.cleanSync_checkbox_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Android iTuneSync";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Settings_button
            // 
            this.Settings_button.BackColor = System.Drawing.Color.White;
            this.Settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_button.ForeColor = System.Drawing.Color.Black;
            this.Settings_button.Location = new System.Drawing.Point(383, 12);
            this.Settings_button.Name = "Settings_button";
            this.Settings_button.Size = new System.Drawing.Size(112, 44);
            this.Settings_button.TabIndex = 14;
            this.Settings_button.Text = "Settings";
            this.Settings_button.UseVisualStyleBackColor = false;
            this.Settings_button.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 250);
            this.Controls.Add(this.Settings_button);
            this.Controls.Add(this.cleanSync_checkbox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bSync_button);
            this.Controls.Add(this.fSync_button);
            this.ForeColor = System.Drawing.Color.Black;
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
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.CheckBox cleanSync_checkbox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Settings_button;
    }
}

