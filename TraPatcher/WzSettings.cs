using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TraPatcher
{
    public static class Patcher_AppSettings
    {
        public static string PatchURL = "";
        public static string ServerName = "";
        public static Bitmap PatcherLogo = TraPatcher.Properties.Resources.DefaultLogo;
    }

    public static class Patcher_UserSettings
    {
        public static int CurrentVersion = 0;
    }
}
