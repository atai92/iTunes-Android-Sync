using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    class playlist
    {
        string PlaylistName;
        List<string> PlaylistContents = new List<string>();
        string file;

        public playlist(string _PlaylistName)
        {
            PlaylistName = _PlaylistName;
            file = _PlaylistName + ".m3u";
        }

        public void add(string SongLocation)
        {
            PlaylistContents.Add(SongLocation);
        }

        public void create()
        {
            System.IO.StreamWriter playlist_file = new System.IO.StreamWriter(file);

            foreach (string element in PlaylistContents)
            {
                playlist_file.WriteLine(element);
            }

            playlist_file.Close();
        }

        public void delete()
        {
            System.IO.File.Delete(PlaylistName + ".m3u");
        }

        public string filename()
        {
            return file;
        }

        public Boolean empty()
        {
            System.IO.StreamReader playlist_file = new System.IO.StreamReader(file);
            string line;
            while ((line = playlist_file.ReadLine()) != null)
            {
                char[] anyof = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

                if (line.IndexOfAny(anyof) > -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
