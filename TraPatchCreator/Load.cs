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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MapleLib;
using MapleLib.WzLib;
using MapleLib.WzLib.Util;

namespace TraPatchCreator
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private void Load_Load(object sender, EventArgs e)
        {
            loadPathBox.Text = AppSettings.LoadPath;
            encryptionBox.SelectedIndex = AppSettings.MapleVersion;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string wzPath = loadPathBox.Text;
            AppSettings.LoadPath = wzPath;
            AppSettings.MapleVersion = encryptionBox.SelectedIndex;
            WzMapleVersion fileVersion;
            short version = -1;
            if (encryptionBox.SelectedIndex == 3)
                fileVersion = WzTool.DetectMapleVersion(wzPath, out version); //(Path.Combine(Path.GetDirectoryName(wzPath), "Item.wz"), out version);
            else
                fileVersion = (WzMapleVersion)encryptionBox.SelectedIndex;

            Program.curFile = new WzFile(wzPath, fileVersion);
            Program.curFile.ParseWzFile();
            Application.DoEvents();
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd;
            try
            {
                if (Directory.Exists(AppSettings.LoadPath))
                    ofd = new OpenFileDialog() { Title = "Select the WZ file", Filter = "MapleStory WZ File (*.wz)|*.wz", InitialDirectory = Path.GetDirectoryName(AppSettings.LoadPath) };
                else
                    ofd = new OpenFileDialog() { Title = "Select the WZ file", Filter = "MapleStory WZ File (*.wz)|*.wz" };
            }
            catch
            {
                ofd = new OpenFileDialog() { Title = "Select the WZ file", Filter = "MapleStory WZ File (*.wz)|*.wz" };
            }
            if (ofd.ShowDialog() != DialogResult.OK) return;
            loadPathBox.Text = ofd.FileName;
        }
    }
}
