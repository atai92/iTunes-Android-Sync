using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    public class config
    {
        Dictionary<string, string> cfg = new Dictionary<string, string>();
        string cfg_filename;

        public config()
        {
            cfg_filename = "config.ini";
        }

        public Boolean Exists()
        {
            if (System.IO.File.Exists(cfg_filename))
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, string> read()
        {
            System.IO.StreamReader cfg_file = new System.IO.StreamReader(cfg_filename);

            string line;

            while ((line = cfg_file.ReadLine()) != null)
            {
                if (line.IndexOf("=") > -1)
                {
                    string[] temp = line.Split('=');
                    if (temp.Length > 1) cfg.Add(temp[0], temp[1]);
                }
            }

            cfg_file.Close();
            return cfg;
        }

        public void save(string PC, string Android, Boolean clean, Boolean syncPlaylists, string iTunesLib)
        {
            System.IO.StreamWriter cfg = new System.IO.StreamWriter(cfg_filename);

            string[] lines = new string[5];
            lines[0] = "PC=" + PC;
            lines[1] = "Android=" + Android;
            lines[2] = "Clean_Sync=" + clean.ToString();
            lines[3] = "Sync_Playlists=" + syncPlaylists.ToString();
            lines[4] = "iTunesXML=" + iTunesLib;

            foreach (string element in lines) cfg.WriteLine(element);

            cfg.Close();
        }
    }

}
