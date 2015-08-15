using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    class iTunesLibrary
    {
        //iTunes library creates a dictionary of songs so multiple playlists would result in smaller file sizes. Store this dictionary in a hash table.
        Hashtable Songs = new Hashtable();

        //Path to the iTunes XML Library.
        string iTunes_XML_Library = "C:/Users/Alan/Music/iTunes/iTunes Music Library.xml";

        public Boolean Exists()
        {
            if (System.IO.File.Exists(iTunes_XML_Library))
            {
                return true;
            }
            return false;
        }

        public void makePlaylists()
        {

        }

        public void read()
        {

        }
    }
}
