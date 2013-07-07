/*
 * Copyright (C) 2012-2013 DeathRight

 * This file is part of TraPatcher.

 *  TraPatcher is free software: you can redistribute it and/or modify
     it under the terms of the GNU General Public License as published by
     the Free Software Foundation, either version 3 of the License, or
     (at your option) any later version.

 *  TraPatcher is distributed in the hope that it will be useful,
     but WITHOUT ANY WARRANTY; without even the implied warranty of
     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     GNU General Public License for more details.

 *  You should have received a copy of the GNU General Public License
     along with TraPatcher.  If not, see <http://www.gnu.org/licenses/>. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MapleLib;
using MapleLib.WzLib;
using System.IO;

namespace TraPatcher
{
    static class Program
    {
        public static WzSettingsManager SettingsManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SettingsManager = new WzSettingsManager(System.IO.Path.Combine(Application.StartupPath, "PatcherSettings.wz"), typeof(Patcher_UserSettings), typeof(Patcher_AppSettings));
            SettingsManager.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try { Application.Run(new Form1()); }
            catch { } //Just because sometimes an error about Form1 already being disposed happens, for some reason. -DeathRight
            if (Directory.Exists(Application.StartupPath + @"\Patches")) Directory.Delete(Application.StartupPath + @"\Patches", true);
            SettingsManager.Save();
            /*try
            {
                Application.Run(new Form1());
            }
            catch
            {
                SettingsManager.Save();
                Directory.Delete(Application.StartupPath + @"\Patches",true);
                Application.Exit();
            }
            SettingsManager.Save();
            Directory.Delete(Application.StartupPath + @"\Patches",true);
            Application.Exit();*/
        }
    }
}
