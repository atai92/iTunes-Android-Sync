using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    static class media
    {
        //File formats allowed to be synced across.
        static string[] syncableFormats =
            {".3gp", ".act", ".aiff", ".aac", ".amr", ".ape", ".au", ".awb",
            ".dct", ".dss", ".dvf", ".flac", ".gsm", ".iklax", ".ivs",
            ".m4a", ".mp3", ".mpc", ".msv", ".ogg", ".oga", ".opus", ".ra",
            ".rm", ".raw", ".sln", ".tta", ".vox", ".wav", ".wma", ".wv", ".webm"};

        public static Boolean syncable(string src)
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

        public static string validate(string original)
        {
            //Need to check to see if string has invalid characters and validate them.
            //Example: If string has (, ), or & we need to insert a \ infront of each one.
            if (original.IndexOf("(") > -1 || original.IndexOf(")") > -1 || original.IndexOf("&") > -1) //Preliminary search to see if invalid character exists.
            {
                string validatedString = "";
                foreach (char c in original)
                {
                    if (c == '(' || c == ')' || c == '&') validatedString += (string)("\\" + c);
                    else validatedString += c;
                }
                return validatedString;
            }

            return original;
        }

        public static void diff(string src, string dest, List<string> filesNeeded, List<string> filesUnneeded)
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
                if (!media.syncable(dest_line)) continue;
                destLine_list.Add(dest_line);
            }

            //Read src file
            while ((src_line = src_file.ReadLine()) != null)
            {
                //Skip non-audio files.
                if (!media.syncable(src_line)) continue;

                //Strip original path from line -> line.Substring(PC.Length);
                //Check to see if file exists at destination
                Boolean found = false;
                string temp = src_line.Substring(Properties.Settings.Default.PCDirectory.Length).Replace("\\", "/");
                foreach (string element in destLine_list)
                {
                    if (temp == element.Substring(Properties.Settings.Default.AndroidDirectory.Length))
                    {
                        destLine_list.Remove(element);
                        found = true;
                        break;
                    }
                }
                if (!found && media.syncable(src_line)) filesNeeded.Add(temp);

                //Search dest_file for matching text

            }

            foreach (string element in destLine_list)
            {
                filesUnneeded.Add(element);
            }

            src_file.Close(); dest_file.Close();
        }
    }
}
