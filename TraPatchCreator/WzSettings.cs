using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TraPatchCreator
{
    public static class AppSettings
    {
        public static int wzTypeIndex = 0;
        public static int PatchVersion = 0;
        public static string LoadPath = "";
        public static string SavePath = "";
        public static int MapleVersion = 3;
        public static string curVersion = "1.0.0.0";
        public static Bitmap Logo = TraPatchCreator.Properties.Resources.DefaultLogo;
    }

    public static class UserSettings
    {
        
    }

    public static class Patcher_AppSettings
    {
        public static string PatchURL = "";
        public static string ServerName = "";
        public static Bitmap PatcherLogo = TraPatchCreator.Properties.Resources.DefaultLogo;
    }

    public static class Patcher_UserSettings
    {
        public static int CurrentVersion = 0;
    }
}
