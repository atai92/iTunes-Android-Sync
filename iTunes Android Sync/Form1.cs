using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace iTunes_Android_Sync
{
    public partial class MainWindow : Form
    {
        Settings window_Settings = new Settings();

        Boolean doWork = true;

        //Lists of files to be added or removed
        List<string> filesNeeded = new List<string>();
        List<string> filesUnneeded = new List<string>();

        //Background worker to do the heavy lifting, so the UI does not get slowed down.
        private System.ComponentModel.BackgroundWorker forward_backgroundWorker = new BackgroundWorker();
        private System.ComponentModel.BackgroundWorker backward_backgroundWorker = new BackgroundWorker();

        //Used to toggle window status.
        Boolean hidden = false;

        public MainWindow()
        {
            InitializeComponent();

            forward_backgroundWorker.WorkerSupportsCancellation = true;
            forward_backgroundWorker.WorkerReportsProgress = false;
            forward_backgroundWorker.DoWork += new DoWorkEventHandler(forward_backgroundWorker_DoWork);
            forward_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(forwardbackward_workerCompleted);

            backward_backgroundWorker.WorkerSupportsCancellation = true;
            backward_backgroundWorker.WorkerReportsProgress = false;
            backward_backgroundWorker.DoWork += new DoWorkEventHandler(backward_backgroundWorker_DoWork);
            backward_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(forwardbackward_workerCompleted);

            AddText(console, "Loading existing settings. . .\n");
        }

        public void reset()
        {
            //Window display only allows a set amount of characters to be written. When sync'ing again, clear screen to allow for cleaner viewing.
            console.Clear();
            //Reset progress bar.
            IncreaseProgress(progressBar, -100);
            filesNeeded.Clear();
            filesUnneeded.Clear();
            //Assuming user does not want to clean their phone's working directory every time, we shall reset the checkbox whenever reset is called.
            cleanSync_checkbox.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();

            //Feature testing
            if (!doWork)
            {
                
            } else if (paths.isDefault().Length > 0)
            {
                AddText(console, "Please change your default " + paths.isDefault() + " in the settings menu.");
            }
            else if (droidConnected()) //Make sure a valid Android device is connected.
            {
                //Log action into console.
                AddText(console, "Commencing forward sync.\nYour computer files will now be sync'ed onto your Android device.\n");
                IncreaseProgress(progressBar, 2);

                //While running, disable all sync buttons.
                fSync_button.Enabled = false; bSync_button.Enabled = false;

                //Make sure background worker isn't busy then run relevant tasks.
                if (!forward_backgroundWorker.IsBusy)
                {
                    forward_backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void forward_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                //Check if user wants their phone's working directory to be erased completely
                if (cleanSync_checkbox.Checked == true && (Properties.Settings.Default.AndroidDirectory != "" || Properties.Settings.Default.AndroidDirectory.Length == 0))
                {
                    AddText(console, "Cleaning your phone's working directory at " + Properties.Settings.Default.AndroidDirectory);
                    cmd(("adb rm -f " + Properties.Settings.Default.AndroidDirectory), false);
                }
                //Check if playlists are to be sync'ed as well.
                if (Properties.Settings.Default.iTunesXMLLibraryDirectory.Length > 0)
                {
                    AddText(console, "Trying to locate iTunes library file to extract playlist data from. . .");
                    //Create playlist from iTunes XML file ("iTunes Music Library.xml").
                    iTunesLibrary lib = new iTunesLibrary(Properties.Settings.Default.iTunesXMLLibraryDirectory);
                    if (lib.Exists())
                    {
                        AddText(console, "Parsing iTunes XML Library file.");
                        lib.read(Properties.Settings.Default.PCDirectory);
                        List<string[]> Songs = lib.getList();
                        AddText(console, "Listing track ID's with respective file locations. . .");
                        foreach (string[] elements in Songs)
                        {
                            AddText(console, "Track ID: " + elements[0] + " Location: " + elements[1]);
                        }
                        lib.delete();
                        //Create actual files in local folder
                        List<playlist> Playlists = lib.makePlaylists();
                        foreach (playlist _playlist in Playlists)
                        {
                            if (!_playlist.empty())
                            {
                                string file = _playlist.filename();
                                cmd(("adb -d push \"" + file + "\" \"" + Properties.Settings.Default.AndroidDirectory + file + "\"").Replace("\\", "/"), false);
                            }
                        }
                        
                    }
                    else
                    {
                        AddText(console, "Library file not found!");
                        AddText(console, "Proceeding with the rest of the sync!");
                    }
                }
                //Create list of files in local and remote directories
                if (cmd("dir \"" + Properties.Settings.Default.PCDirectory + "\" /s/b > srclist.txt", false) == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);
                if (cmd("adb -d shell find " + Properties.Settings.Default.AndroidDirectory + " -type f -print > destlist.txt", false) == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);

                //Compare src and dest to get files needed to be added/removed
                media.diff("srclist.txt", "destlist.txt", filesNeeded, filesUnneeded);
                IncreaseProgress(progressBar, 10);

                AddText(console, "\nActions needed to be taken: ");
                AddText(console, filesNeeded.Count + " number of files needed to be added.");
                AddText(console, filesUnneeded.Count + " number of files needed to be removed.\n");

                addFiles(true);
                removeFiles(true);
            }
            catch (Exception objException)
            {
                AddText(console, "\n" + objException.ToString());
            }
        }

        private void forwardbackward_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                AddText(console, "Cancelled!");
            }

            else if (!(e.Error == null))
            {
                AddText(console, "Error: " + e.Error.Message);
            }

            else
            {
                AddText(console, "Sync done!");
                //Re-enable buttons after task is done.
                fSync_button.Enabled = true; bSync_button.Enabled = true;
            }
        }

        private void backward_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                ////Check if user wants their desktop's working directory to be erased completely -- May not want this... (Will delete iTunes Directory as well)
                //if (cleanSync_checkbox.Checked == true && (Properties.Settings.Default.PCDirectory != "" || Properties.Settings.Default.PCDirectory.Length == 0))
                //{
                //    AddText(console, "Cleaning your phone's working directory at " + Properties.Settings.Default.PCDirectory);
                //    cmd(("adb rm -f " + Properties.Settings.Default.PCDirectory), false);
                //}

                //Create list of files in local and remote directories
                if (cmd("dir \"" + Properties.Settings.Default.PCDirectory + "\" /s/b > srclist.txt", false) == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);
                if (cmd("adb -d shell find " + Properties.Settings.Default.AndroidDirectory + " -type f -print > destlist.txt", false) == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);

                //Compare src and dest to get files needed to be added/removed
                media.diff("destlist.txt", "srclist.txt", filesNeeded, filesUnneeded);
                IncreaseProgress(progressBar, 10);

                AddText(console, "\nActions needed to be taken: ");
                AddText(console, filesNeeded.Count + " number of files needed to be added.");
                AddText(console, filesUnneeded.Count + " number of files needed to be removed.\n");

                addFiles(false);
                removeFiles(false);
            }
            catch (Exception objException)
            {
                AddText(console, "\n" + objException.ToString());
            }
        }

        public delegate void ControlStringConsumer(RichTextBox control, string text);

        public void AddText(RichTextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(AddText), new object[] { control, text + "\n" });  // invoking itself
            }
            else
            {
                control.AppendText(text + "\n");      // the "functional part", executing only on the main thread
                control.SelectionStart = control.Text.Length;
                control.ScrollToCaret();
            }
        }

        public delegate void ControlProgressBar(ProgressBar control, int increment);

        public void IncreaseProgress(ProgressBar control, int increment)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlProgressBar(IncreaseProgress), new object[] { control, increment });
            }
            else
            {
                control.Increment(increment);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();

            //Log action into console.
            AddText(console, "Commencing backward sync.\nYour Android files will now be sync'ed onto your computer.\n\n");
            IncreaseProgress(progressBar, 1);

            if (paths.isDefault().Length > 0)
            {
                AddText(console, "Please change your default " + paths.isDefault() + " in the settings menu.");
            }
            else if (droidConnected()) //Make sure a valid Android device is connected.
            {
                //Log action into console.
                AddText(console, "Commencing forward sync.\nYour computer files will now be sync'ed onto your Android device.\n");
                IncreaseProgress(progressBar, 2);

                //While running, disable all sync buttons.
                fSync_button.Enabled = false; bSync_button.Enabled = false;

                //Make sure background worker isn't busy then run relevant tasks.
                if (!backward_backgroundWorker.IsBusy)
                {
                    backward_backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        public int cmd(object command, Boolean silent)
        {
            try
            {
                if (!silent) AddText(console, "Running cmd command \"" + command + "\"");

                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                
                string stdOutput, lastLine;
                lastLine = "";
                while ((stdOutput = proc.StandardOutput.ReadLine()) != null)
                {
                    lastLine = stdOutput;
                }
                AddText(console, lastLine);

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                if (command.ToString().IndexOf("rm") > -1 && result.Length > 1)
                { 
                    if (result.IndexOf("/system") > -1)
                    {
                        AddText(console, "Failed to remove a file. Sorry for the inconvenience.\nTo remove this file, you will have to manually navigate and delete the file.\n");
                    }
                }   
                else
                {
                    if (result.Length > 1) AddText(console, result + "\n");
                }
                proc.Dispose();
                
            }
            catch (Exception objException)
            {
                // Log the exception
                AddText(console, "Error running command \"" + command + "\" with exception " + objException + "\n");
                return 0;
            }

            return 1;
        }

        public Boolean droidConnected()
        {
            cmd("adb start-server", true);
            AddText(console, "Verifying device connection. . .\n");
            //Output devices list to a text file because the output cannot be redirected into this form.
            cmd("adb devices > devices.txt", true);
            System.IO.StreamReader deviceslist = new System.IO.StreamReader("devices.txt");

            //Check first line to see if daemon is starting.
            string device = deviceslist.ReadLine();
            if (device.Contains("daemon"))
            { //Skip two lines if daemon server is just starting.
                deviceslist.ReadLine();
                deviceslist.ReadLine();
            }

            //Second line shows first device. This is the device that will accept the ADB commands.
            //If the line is null then there are no devices at all.
            if ((device = deviceslist.ReadLine()) == null || device.Length < 3)
            {
                AddText(console, "\nError!: No connected devices detected.\nPlease make sure you have ADB drivers installed.\nAlso make sure USB debugging is enabled on your Android device.\n");
                return false;
            }

            //We want to see if there are any non-emulated devices present.
            while (device.IndexOf("emulator") > -1)
            {
                device = deviceslist.ReadLine();
                if (device == null || device.Length < 3)
                {
                    AddText(console, "\nError!: No connected devices detected.\nPlease make sure you have ADB drivers installed.\nAlso make sure USB debugging is enabled on your Android device.\n");
                    return false;
                }
            }

            AddText(console, "Device present!");
            return true;
        }

        public void addFiles(Boolean toAndroid)
        {
            if (toAndroid)
            {
                System.IO.StreamWriter addFiles_bat = new System.IO.StreamWriter("addFiles.bat");

                //Want to create the addfiles.bat file just in case the file push hangs and does not complete this later.
                foreach(string element in filesNeeded)
                {
                    string addFileString = ("adb -d push \"" + Properties.Settings.Default.PCDirectory + element + "\" \"" + Properties.Settings.Default.AndroidDirectory + element + "\"").Replace("\\", "/");

                    addFiles_bat.WriteLine(addFileString);

                }
                addFiles_bat.Close();

                foreach (string element in filesNeeded)
                {
                    string addFileString = ("adb -d push \"" + Properties.Settings.Default.PCDirectory + element + "\" \"" + Properties.Settings.Default.AndroidDirectory + element + "\"").Replace("\\", "/");

                    cmd(addFileString, false);
                    
                }
                IncreaseProgress(progressBar, 60);
            }
            else
            {
                System.IO.StreamWriter addFiles_bat = new System.IO.StreamWriter("addFiles.bat");
                foreach (string element in filesNeeded)
                {
                    string addFileString = ("adb -d pull \"" + Properties.Settings.Default.AndroidDirectory + element + "\" \"" + Properties.Settings.Default.PCDirectory + element + "\"").Replace("\\", "/");

                    cmd(addFileString, false);
                    addFiles_bat.WriteLine(addFileString);
                }
                IncreaseProgress(progressBar, 60);
                addFiles_bat.Close();
            }
        }

        public void removeFiles(Boolean toAndroid)
        {
            if (toAndroid)
            {
                System.IO.StreamWriter rmFiles_bat = new System.IO.StreamWriter("rmFiles.bat");
                foreach (string element in filesUnneeded)
                {
                    string rmFileString = "adb -d shell rm -f \"" + media.validate(element) + "\"";

                    cmd(rmFileString, false); //.Replace("\\","/")
                    rmFiles_bat.WriteLine(rmFileString);
                }
                IncreaseProgress(progressBar, 20);
                rmFiles_bat.Close();
            }
            else
            {
                System.IO.StreamWriter rmFiles_bat = new System.IO.StreamWriter("rmFiles.bat");
                foreach (string element in filesUnneeded)
                {
                    string rmFileString = "rm -f \"" + media.validate(element) + "\"";

                    cmd(rmFileString, false); //.Replace("\\","/")
                    rmFiles_bat.WriteLine(rmFileString);
                }
                IncreaseProgress(progressBar, 20);
                rmFiles_bat.Close();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (hidden)
            {
                Show();
                hidden = false;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Hide();
                hidden = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                hidden = true;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void PCSyncDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void console_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (window_Settings.Visible) window_Settings.Hide();
            else window_Settings.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void XMLLibraryDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void cleanSync_checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void syncPlaylists_checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
