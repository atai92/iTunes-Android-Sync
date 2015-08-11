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
    public partial class MainWindow : Form
    {
        //Directory of iTunes music folder to sync to/from.
        string PC = "C:/Users/Alan/Music/";

        //Directory of Android music folder to sync to/from.
        string Android = "/sdcard/Music/";

        //File formats allowed to be synced across.
        string[] syncableFormats = 
            {".3gp", ".act", ".aiff", ".aac", ".amr", ".ape", ".au", ".awb",
            ".dct", ".dss", ".dvf", ".flac", ".gsm", ".iklax", ".ivs",
            ".m4a", ".mp3", ".mpc", ".msv", ".ogg", ".oga", ".opus", ".ra",
            ".rm", ".raw", ".sln", ".tta", ".vox", ".wav", ".wma", ".wv", ".webm"};

        List<string> filesNeeded = new List<string>();
        List<string> filesUnneeded = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void reset()
        {
            //Window display only allows a set amount of characters to be written. When sync'ing again, clear screen to allow for cleaner viewing.
            console.Clear();
            //Reset progress bar.
            progressBar.Increment(-100);
            filesNeeded.Clear();
            filesUnneeded.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
            //Log action into console.
            console.AppendText("Commencing forward sync.\nYour computer files will now be sync'ed onto your Android device.\n\n");
            progressBar.Increment(2);

            //While running, disable all sync buttons.
            fSync_button.Enabled = false; bSync_button.Enabled = false;

            //Check if playlists are to be sync'ed as well.
            if (syncPlaylists_checkbox.Checked == true) {
                console.AppendText("Creating playlists from iTunes library.");
                //Create playlist from iTunes XML file ("iTunes Music Library.xml").
            }

            try
            {
                //Create list of files in local and remote directories
                if (cmd("dir \"" + PC + "\" /s/b > srclist.txt") == 0) throw new System.Exception();
                progressBar.Increment(4);
                if (cmd("adb shell find " + Android + " -type f -print > destlist.txt") == 0) throw new System.Exception();
                progressBar.Increment(4);

                //Compare src and dest to get files needed to be added/removed
                diff("srclist.txt", "destlist.txt");
                progressBar.Increment(10);

                console.AppendText("\nActions needed to be taken: \n");
                console.AppendText(filesNeeded.Count + " number of files needed to be added.\n");
                console.AppendText(filesUnneeded.Count + " number of files needed to be removed.\n");

                addFiles(true);
                removeFiles(true);
            }
            catch (Exception objException)
            {
                console.AppendText("\n" + objException.ToString() + "\n");
            }

            //Re-enable buttons after task is done.
            fSync_button.Enabled = true; //bSync_button.Enabled = true;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();

            //Log action into console.
            console.AppendText("Commencing backward sync.\nYour Android files will now be sync'ed onto your computer.\n\n");
            progressBar.Increment(1);

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

        public int bat(string file)
        {
            try
            {
                console.AppendText("Running command batch file " + file + "\n");
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(file);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = false;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                if (result.Length > 1) console.AppendText(result + "\n");
            }
            catch (Exception objException)
            {
                // Log the exception
                console.AppendText("Error running file \"" + file + "\" with exception " + objException + "\n");
                return 0;
            }

            return 1;
        }

        public int cmd(object command)
        {
            try
            {
                console.AppendText("Running command '" + command + "'\n");
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
                if (result.Length > 1) console.AppendText(result + "\n");
            }
            catch (Exception objException)
            {
                // Log the exception
                console.AppendText("Error running command \"" + command + "\" with exception " + objException + "\n");
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

        public void addFiles(Boolean toAndroid)
        {
            if (toAndroid)
            {
                System.IO.StreamWriter addFiles_bat = new System.IO.StreamWriter("addFiles.bat");
                foreach (string element in filesNeeded)
                {
                    //console.AppendText("adb push " + element + " " + Android + element.Substring(PC.Length) + "\n");
                    cmd(("adb push \"" + PC + element + "\" \"" + Android + element + "\"").Replace("\\","/"));
                    addFiles_bat.WriteLine(("adb push \"" + PC + element + "\" \"" + Android + element + "\"").Replace("\\", "/") + "\n");
                }
                progressBar.Increment(60);
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
                    //console.AppendText("adb shell rm -f " + element + "\n");
                    cmd(("adb shell rm -f \"" + element + "\"")); //.Replace("\\","/")
                    rmFiles_bat.WriteLine(("adb shell rm -f \"" + element + "\"") + "\n");
                }
                progressBar.Increment(20);
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
    }
}
