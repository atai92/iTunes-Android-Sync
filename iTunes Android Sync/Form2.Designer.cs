namespace iTunes_Android_Sync
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.XMLLibraryDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AndroidSyncDirectory = new System.Windows.Forms.TextBox();
            this.PCSyncDirectory = new System.Windows.Forms.TextBox();
            this.button_ApplySettings = new System.Windows.Forms.Button();
            this.button_CloseSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // XMLLibraryDirectory
            // 
            this.XMLLibraryDirectory.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XMLLibraryDirectory.Location = new System.Drawing.Point(191, 89);
            this.XMLLibraryDirectory.Name = "XMLLibraryDirectory";
            this.XMLLibraryDirectory.Size = new System.Drawing.Size(316, 20);
            this.XMLLibraryDirectory.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "iTunes XML Library File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Android Sync Directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "PC Sync Directory";
            // 
            // AndroidSyncDirectory
            // 
            this.AndroidSyncDirectory.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AndroidSyncDirectory.Location = new System.Drawing.Point(191, 51);
            this.AndroidSyncDirectory.Name = "AndroidSyncDirectory";
            this.AndroidSyncDirectory.Size = new System.Drawing.Size(316, 20);
            this.AndroidSyncDirectory.TabIndex = 15;
            // 
            // PCSyncDirectory
            // 
            this.PCSyncDirectory.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCSyncDirectory.Location = new System.Drawing.Point(191, 12);
            this.PCSyncDirectory.Name = "PCSyncDirectory";
            this.PCSyncDirectory.Size = new System.Drawing.Size(316, 20);
            this.PCSyncDirectory.TabIndex = 14;
            this.PCSyncDirectory.Text = "\r\n";
            // 
            // button_ApplySettings
            // 
            this.button_ApplySettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ApplySettings.Location = new System.Drawing.Point(191, 123);
            this.button_ApplySettings.Name = "button_ApplySettings";
            this.button_ApplySettings.Size = new System.Drawing.Size(75, 23);
            this.button_ApplySettings.TabIndex = 20;
            this.button_ApplySettings.Text = "Apply";
            this.button_ApplySettings.UseVisualStyleBackColor = true;
            this.button_ApplySettings.Click += new System.EventHandler(this.button_ApplySettings_Click);
            // 
            // button_CloseSettings
            // 
            this.button_CloseSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CloseSettings.Location = new System.Drawing.Point(273, 123);
            this.button_CloseSettings.Name = "button_CloseSettings";
            this.button_CloseSettings.Size = new System.Drawing.Size(75, 23);
            this.button_CloseSettings.TabIndex = 21;
            this.button_CloseSettings.Text = "Close";
            this.button_CloseSettings.UseVisualStyleBackColor = true;
            this.button_CloseSettings.Click += new System.EventHandler(this.button_CloseSettings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(530, 158);
            this.ControlBox = false;
            this.Controls.Add(this.button_CloseSettings);
            this.Controls.Add(this.button_ApplySettings);
            this.Controls.Add(this.XMLLibraryDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AndroidSyncDirectory);
            this.Controls.Add(this.PCSyncDirectory);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox XMLLibraryDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AndroidSyncDirectory;
        private System.Windows.Forms.TextBox PCSyncDirectory;
        private System.Windows.Forms.Button button_ApplySettings;
        private System.Windows.Forms.Button button_CloseSettings;
    }
}