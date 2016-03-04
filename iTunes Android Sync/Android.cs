using System;

namespace iTunes_Android_Sync
{
    public class Android
    {
        public int Connected()
        {
            //cmd("adb start-server", true);
            //AddText(console, "Verifying device is connected. . .\n");
            //Output devices list to a text file because the output cannot be redirected into this form.
            //cmd("adb devices > devices.txt", true);
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
                return 1;// "\nError!: No connected devices detected.\nPlease make sure you have ADB drivers installed.\nAlso make sure USB debugging is enabled on your Android device.\n";

            }

            //We want to see if there are any non-emulated devices present.
            while (device.IndexOf("emulator") > -1)
            {
                device = deviceslist.ReadLine();
                if (device == null || device.Length < 3)
                {
                    return 2;// "\nError!: No connected devices detected.\nPlease make sure you have ADB drivers installed.\nAlso make sure USB debugging is enabled on your Android device.\n";
                }
            }

            return 0; // "Device present!";
        }
    }
}