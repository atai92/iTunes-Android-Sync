using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunes_Android_Sync
{
    static class paths
    {
        public static string isDefault()
        {
            if (Properties.Settings.Default.PCDirectory == "C:/ Users / _USERNAMEHERE_ / Music /") return "PC directory";
            return "";
        }
    }
}
