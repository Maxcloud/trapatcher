/*
 * Copyright (C) 2012-2013 DeathRight

 * This file is part of TraPatchCreator.

 *  TraPatchCreator is free software: you can redistribute it and/or modify
     it under the terms of the GNU General Public License as published by
     the Free Software Foundation, either version 3 of the License, or
     (at your option) any later version.

 *  TraPatchCreator is distributed in the hope that it will be useful,
     but WITHOUT ANY WARRANTY; without even the implied warranty of
     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     GNU General Public License for more details.

 *  You should have received a copy of the GNU General Public License
     along with TraPatchCreator.  If not, see <http://www.gnu.org/licenses/>. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MapleLib;
using MapleLib.WzLib;

namespace TraPatchCreator
{
    static class Program
    {
        public static WzSettingsManager SettingsManager;
        public static WzFile curFile;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SettingsManager = new WzSettingsManager(System.IO.Path.Combine(Application.StartupPath, "TraPC_Settings.wz"), typeof(UserSettings), typeof(AppSettings));
            SettingsManager.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            SettingsManager.Save();
        }
    }
}
