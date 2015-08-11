using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    public class param
    {
        string PC;
        string Android;
        Boolean cleanSync;
        Boolean syncPlaylists;

        public param(string PCPath, string AndroidPath, Boolean clean, Boolean sync_playlists)
        {
            PC = PCPath;
            Android = AndroidPath;
            cleanSync = clean;
            syncPlaylists = sync_playlists;
        }

        public string[] getPaths()
        {
            return new string[] { PC, Android };
        }

        public Boolean[] getCheckboxes()
        {
            return new Boolean[] { cleanSync, syncPlaylists };
        }
    }

    public class config
    {
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

        public param getParam()
        {
            System.IO.StreamReader cfg = new System.IO.StreamReader(cfg_filename);

            string param = cfg.ReadLine();
            string PCPath = param.Substring("[PC]=".Length);

            param = cfg.ReadLine();
            string AndroidPath = "";
            if (param.Length > "[Android]=".Length) AndroidPath = param.Substring("[Android]=".Length);

            param = cfg.ReadLine();
            Boolean clean = false;
            if (param.IndexOf("True") > -1) clean = true;

            param = cfg.ReadLine();
            Boolean sync_playlists = false;
            if (param.IndexOf("True") > -1) sync_playlists = true;

            cfg.Close();
            return new param(PCPath, AndroidPath, clean, sync_playlists);
        }

        public void save(string PC, string Android, Boolean clean, Boolean syncPlaylists)
        {
                System.IO.StreamWriter cfg = new System.IO.StreamWriter(cfg_filename);

                string[] lines = new string[4];
                lines[0] = "[PC]=" + PC;
                lines[1] = "[Android]=" + Android;
                lines[2] = "[Clean Sync]=" + clean.ToString();
                lines[3] = "[Sync playlists]=" + syncPlaylists.ToString();

                foreach (string element in lines) cfg.WriteLine(element);

                cfg.Close();
        }
    }

}
