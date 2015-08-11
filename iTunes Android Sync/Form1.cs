﻿using System;
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
        //Directory of iTunes music folder to sync to/from.
        string PC;

        //Directory of Android music folder to sync to/from.
        string Android;

        //File formats allowed to be synced across.
        string[] syncableFormats = 
            {".3gp", ".act", ".aiff", ".aac", ".amr", ".ape", ".au", ".awb",
            ".dct", ".dss", ".dvf", ".flac", ".gsm", ".iklax", ".ivs",
            ".m4a", ".mp3", ".mpc", ".msv", ".ogg", ".oga", ".opus", ".ra",
            ".rm", ".raw", ".sln", ".tta", ".vox", ".wav", ".wma", ".wv", ".webm"};

        List<string> filesNeeded = new List<string>();
        List<string> filesUnneeded = new List<string>();

        private System.ComponentModel.BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        config cfg = new config();

        public MainWindow()
        {
            InitializeComponent();

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = false;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            AddText(console, "Looking for config file. . .\n");
            
            if (cfg.Exists())
            {
                AddText(console, "Config file found.\nLoading config file. . . NOTE: Config file saves every time you sync!\n\n");

                param parameters = cfg.getParam();
                string[] paths = new string[2];
                paths = parameters.getPaths();
                PC = paths[0];
                PCSyncDirectory.Text = PC;
                Android = paths[1];
                AndroidSyncDirectory.Text = Android;

                Boolean[] checkboxes = new Boolean[2];
                checkboxes = parameters.getCheckboxes();
                cleanSync_checkbox.Checked = checkboxes[0];
                syncPlaylists_checkbox.Checked = checkboxes[1];
            }
            else
            {
                AddText(console, "Config file not found.\nLoading default parameters.\n");
                AndroidSyncDirectory.Text = "/sdcard/Music/";
                PCSyncDirectory.Text = "C:/Users/USERNAMEHERE/Music/";
            }
        }

        public void reset()
        {
            //Window display only allows a set amount of characters to be written. When sync'ing again, clear screen to allow for cleaner viewing.
            console.Clear();
            //Reset progress bar.
            IncreaseProgress(progressBar, -100);
            filesNeeded.Clear();
            filesUnneeded.Clear();
            PC = PCSyncDirectory.Text;
            Android = AndroidSyncDirectory.Text;
            cfg.save(PC, Android, cleanSync_checkbox.Checked, syncPlaylists_checkbox.Checked);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();

            //Make sure a valid Android device is connected.
            if (droidConnected())
            {
                //Log action into console.
                AddText(console, "Commencing forward sync.\nYour computer files will now be sync'ed onto your Android device.\n\n");
                IncreaseProgress(progressBar, 2);

                //While running, disable all sync buttons.
                fSync_button.Enabled = false; bSync_button.Enabled = false;

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //Check if playlists are to be sync'ed as well.
            if (syncPlaylists_checkbox.Checked == true)
            {
                AddText(console, "Creating playlists from iTunes library.");
                //Create playlist from iTunes XML file ("iTunes Music Library.xml").
            }

            try
            {
                //Create list of files in local and remote directories
                if (cmd("dir \"" + PC + "\" /s/b > srclist.txt") == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);
                if (cmd("adb shell find " + Android + " -type f -print > destlist.txt") == 0) throw new System.Exception();
                IncreaseProgress(progressBar, 4);

                //Compare src and dest to get files needed to be added/removed
                diff("srclist.txt", "destlist.txt");
                IncreaseProgress(progressBar, 10);

                AddText(console, "\nActions needed to be taken: \n");
                AddText(console, filesNeeded.Count + " number of files needed to be added.\n");
                AddText(console, filesUnneeded.Count + " number of files needed to be removed.\n\n");

                addFiles(true);
                removeFiles(true);
            }
            catch (Exception objException)
            {
                AddText(console, "\n" + objException.ToString() + "\n");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                fSync_button.Enabled = true; //bSync_button.Enabled = true;
            }
        }

        public delegate void ControlStringConsumer(RichTextBox control, string text);

        public void AddText(RichTextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(AddText), new object[] { control, text });  // invoking itself
            }
            else
            {
                control.AppendText(text);      // the "functional part", executing only on the main thread
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

            //While running, disable all sync buttons.
            fSync_button.Enabled = false; bSync_button.Enabled = false;

            //Re-enable buttons after task is done.
            fSync_button.Enabled = true; bSync_button.Enabled = true;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        public int cmd(object command)
        {
            try
            {
                if ((command.ToString()).IndexOf("devices") == -1) AddText(console, "Running cmd command \"" + command + "\"\n");

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
                proc.WaitForExit();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                if (command.ToString().IndexOf("rm") > -1 && result.Length > 1)
                { 
                    if (result.IndexOf("/system") > -1)
                    {
                        AddText(console, "Failed to remove a file. Sorry for the inconvenience.\nTo remove this file, you will have to manually navigate and delete the file.\n\n");
                    }
                }   
                else
                {
                    if (result.Length > 1) AddText(console, result + "\n");
                }
            }
            catch (Exception objException)
            {
                // Log the exception
                AddText(console, "Error running command \"" + command + "\" with exception " + objException + "\n");
                return 0;
            }

            return 1;
        }

        public void diff(string src, string dest)
        {
            string src_line;
            string dest_line;
            List<string> destLine_list = new List<string>();

            // Read both files
            System.IO.StreamReader src_file = new System.IO.StreamReader(src);
            System.IO.StreamReader dest_file = new System.IO.StreamReader(dest);

            //Load dest file into memory.
            while ((dest_line = dest_file.ReadLine()) != null)
            {
                if (!syncable(dest_line)) continue;
                destLine_list.Add(dest_line);
            }

            //Read src file
            while ((src_line = src_file.ReadLine()) != null)
            {
                //Skip non-audio files.
                if (!syncable(src_line)) continue;

                //Strip original path from line -> line.Substring(PC.Length);
                //Check to see if file exists at destination
                Boolean found = false;
                string temp = src_line.Substring(PC.Length).Replace("\\", "/");
                foreach (string element in destLine_list)
                {
                    if (temp == element.Substring(Android.Length))
                    {
                        destLine_list.Remove(element);
                        found = true;
                        break;
                    }
                }
                if (!found && syncable(src_line)) filesNeeded.Add(temp);

                //Search dest_file for matching text
                
            }

            foreach (string element in destLine_list)
            {
                filesUnneeded.Add(element);
            }

            src_file.Close(); dest_file.Close();
        }

        public Boolean droidConnected()
        {
            AddText(console, "Verifying device is connected. . .\n");
            //Output devices list to a text file because the output cannot be redirected into this form.
            cmd("adb devices > devices.txt");
            System.IO.StreamReader deviceslist = new System.IO.StreamReader("devices.txt");

            //First line is always the same and is garbage.
            string device = deviceslist.ReadLine();

            //Second line shows first device. This is the device that will accept the ADB commands.
            //If the line is null then there are no devices at all.
            if ((device = deviceslist.ReadLine()) == null || device.Length < 3)
            {
                AddText(console, "\nError!: No connected devices detected.\nPlease make sure you have ADB drivers installed.\nAlso make sure USB debugging is enabled on your Android device.\n\n");
                return false;
            }

            //We do not want any emulators to be here either!
            if (device.IndexOf("emu") > -1)
            {
                AddText(console, "\nError!: There seems to be an emulator device connected.\nPlease disconnect the emulator to sync with your Android device.\n\n");
                return false;
            }

            AddText(console, "Device present!\n");
            return true;
        }

        public void addFiles(Boolean toAndroid)
        {
            if (toAndroid)
            {
                System.IO.StreamWriter addFiles_bat = new System.IO.StreamWriter("addFiles.bat");
                foreach (string element in filesNeeded)
                {
                    //AddText(console, "adb push " + element + " " + Android + element.Substring(PC.Length) + "\n");
                    cmd(("adb push \"" + PC + element + "\" \"" + Android + element + "\"").Replace("\\","/"));
                    addFiles_bat.WriteLine(("adb push \"" + PC + element + "\" \"" + Android + element + "\"").Replace("\\", "/") + "\n");
                }
                IncreaseProgress(progressBar, 60);
                addFiles_bat.Close();
                //bat("addFiles.bat");
            }
            else
            {

            }
        }

        public void removeFiles(Boolean toAndroid)
        {
            if (toAndroid)
            {
                System.IO.StreamWriter rmFiles_bat = new System.IO.StreamWriter("rmFiles.bat");
                foreach (string element in filesUnneeded)
                {
                    //AddText(console, "adb shell rm -f " + element + "\n");
                    cmd(("adb shell rm -f \"" + element + "\"")); //.Replace("\\","/")
                    rmFiles_bat.WriteLine(("adb shell rm -f \"" + element + "\"") + "\n");
                }
                IncreaseProgress(progressBar, 20);
                rmFiles_bat.Close();
            }
            else
            {

            }
        }

        public Boolean syncable(string src)
        {
            if (src.Length > 6)
            {
                //file extension sizes typically vary from 2 to 4 characters, so we want to cross check these cases as well.
                string[] fileExtension = { src.Substring(src.Length - 3), src.Substring(src.Length - 4), src.Substring(src.Length - 5) };
                foreach (string element in syncableFormats)
                {
                    if (fileExtension[0] == element || fileExtension[1] == element || fileExtension[2] == element)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

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

        private void thisDoesNotSafeWfkwenFjewnFkjewnkfnewkjfewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
