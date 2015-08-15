using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTunes_Android_Sync
{
    class iTunesLibrary
    {
        //iTunes library creates a dictionary of songs so multiple playlists would result in smaller file sizes. Store this dictionary in a hash table.
        Dictionary<string, string> Songs = new Dictionary<string, string>();
        List<string[]> _Songs = new List<string[]>();
        List<playlist> Playlists = new List<playlist>();

        //Path to the iTunes XML Library.
        string iTunes_XML_Library;

        public iTunesLibrary(string lib)
        {
            iTunes_XML_Library = lib;
        }

        public Boolean Exists()
        {
            if (System.IO.File.Exists(iTunes_XML_Library))
            {
                return true;
            }
            return false;
        }

        public List<playlist> makePlaylists()
        {
            foreach (playlist _Playlist in Playlists)
            {
                _Playlist.create();
            }

            return Playlists;
        }

        public void delete()
        {
            foreach (playlist p in Playlists)
            {
                p.delete();
            }
        }

        public void read(string PCPath)
        {
            XmlReaderSettings rs = new XmlReaderSettings();
            rs.DtdProcessing = DtdProcessing.Parse;
            XmlTextReader XMLLib = new XmlTextReader(iTunes_XML_Library);
            XmlReader reader = XmlReader.Create(iTunes_XML_Library, rs);

            Boolean playlist = false;

            while (reader.Read())
            {
                string[] songInfo = new string[2];
                if (!playlist && reader.NodeType == XmlNodeType.Text && reader.Value == "Track ID")
                {
                    reader.Read();
                    while (reader.NodeType != XmlNodeType.Text) reader.Read();
                    if (reader.NodeType == XmlNodeType.Text)
                        songInfo[0] = reader.Value;
                    while(reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text && reader.Value == "Location")
                        {
                            reader.Read();
                            while (reader.NodeType != XmlNodeType.Text) reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                //%20 is supposed to be a space and file://localhost/ is unnecessarily added to the beginning of every path. 
                                //Must have been a web based location.
                                //Removing original PC path because this file should be going into the root Music folder.
                                songInfo[1] = reader.Value.Replace("%20", " ").Substring("file://localhost/".Length + PCPath.Length);
                            break;
                        }
                    }
                    if (songInfo[0] != null)
                    {
                        Songs.Add(songInfo[0], songInfo[1]);
                        _Songs.Add(songInfo);
                    }
                }
                    
                //Once we reach this spot, we do not need to look for Track ID's and locations.
                //We want to map track ID's to locations and build each playlist.m3u!
                if (reader.NodeType == XmlNodeType.Text && reader.Value == "Playlists") playlist = true;
                if (playlist && reader.NodeType == XmlNodeType.Text && reader.Value == "Name")
                {
                    reader.Read();
                    while (reader.NodeType != XmlNodeType.Text) reader.Read();

                    //Make sure playlist is valid.
                    if (reader.NodeType == XmlNodeType.Text && reader.Value.IndexOf("#") < 0)
                    {
                        //Playlist is valid. Create playlist and save the playlist name.
                        Playlists.Add(new playlist(reader.Value));
                        //Now find all Track ID's and add them into our playlist.
                        while(reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Text && reader.Value == "Track ID")
                            {
                                reader.Read();
                                while (reader.NodeType != XmlNodeType.Text) reader.Read();
                                Playlists[Playlists.Count - 1].add(Songs[reader.Value]);
                            }
                            //New Playlist, so we want to return to parent loop to create a new playlist.
                            if (reader.NodeType == XmlNodeType.Text && reader.Value == "Playlist ID") break;
                        }
                        
                    }
                }

            }


            reader.Close();
        }

        public Dictionary<string,string> getSongs()
        {
            return Songs;
        }
        public List<string[]> getList()
        {
            return _Songs;
        }

    }
}
