using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTunes_Android_Sync
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.PCSyncDirectory.Text = Properties.Settings.Default.PCDirectory;
            this.AndroidSyncDirectory.Text = Properties.Settings.Default.AndroidDirectory;
            this.XMLLibraryDirectory.Text = Properties.Settings.Default.iTunesXMLLibraryDirectory;
        }

        private void button_ApplySettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PCDirectory = this.PCSyncDirectory.Text;
            Properties.Settings.Default.AndroidDirectory = this.AndroidSyncDirectory.Text;
            Properties.Settings.Default.iTunesXMLLibraryDirectory = this.XMLLibraryDirectory.Text;
            Properties.Settings.Default.Save();
        }

        private void button_CloseSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
