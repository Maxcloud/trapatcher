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
using System.Net;
using System.Windows.Forms;
using MapleLib;
using MapleLib.WzLib;

namespace TraPatchCreator
{
    public partial class GenTPS : Form
    {
        public GenTPS()
        {
            InitializeComponent();
            logoPicture.Image = AppSettings.Logo;
        }

        private void GenTPS_Load(object sender, EventArgs e)
        {
            
        }

        private void genBtn_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadString(webUrl.Text);
            }
            catch (Exception WTFBBQ) //Yes, I know WTFBBQ is never used, tysm VS! Now shut up. -DeathRight
            {
                client.Dispose();
                MessageBox.Show("The URL specified, \"" + webUrl.Text + "\" does not exist.", "Why did you give me a invalid URL?!");
                return;
            }
            client.Dispose();

            /*if (String.IsNullOrWhiteSpace(serverName.Text))
            {
                MessageBox.Show("Sorry, but I don't think that \"" + serverName.Text + "\" is a very good name.\r\nTry again, only this time, do it properly, noob.", "Interesting choice of a server name");
                return;
            }
            else*/ if (serverName.Text == "MapleStory")
            {
                MessageBox.Show("Is Nexon using my Patch Creator?", "...Nexon?");
            }
            else if (serverName.Text == "MapleSEA")
            {
                MessageBox.Show("¿Está utilizando Nexon mi Creador Parche?", "...Nexon?");
            }

            if (String.IsNullOrWhiteSpace(startVer.Text))
            {
                MessageBox.Show("Enter a valid number, noob.", "Enter a valid number");
                return;
            }
            try
            {
                int test = Convert.ToInt32(startVer.Text);
            }
            catch (Exception WTFBBQ)
            {
                MessageBox.Show("Enter a valid number, noob.", "Enter a valid number");
                return;
            }

            WzSettingsManager SettingsMngr = new WzSettingsManager(System.IO.Path.Combine(Application.StartupPath, "PatcherSettings.wz"), typeof(Patcher_UserSettings), typeof(Patcher_AppSettings));
            SettingsMngr.Load();
            Patcher_UserSettings.CurrentVersion = Convert.ToInt32(startVer.Text);
            Patcher_AppSettings.PatchURL = webUrl.Text;
            Patcher_AppSettings.ServerName = serverName.Text;
            Patcher_AppSettings.PatcherLogo = new Bitmap(logoPicture.Image);
            AppSettings.Logo = new Bitmap(logoPicture.Image);
            SettingsMngr.Save();
            MessageBox.Show("It was saved to: "+Application.StartupPath+"\\PatcherSettings.wz","Patcher settings file generated successfully!");
        }

        private void logoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Title = "Select the image", Filter = "Supported Image Formats (*.png;*.bmp;*.jpg;*.gif;*.jpeg;*.tif;*.tiff)|*.png;*.bmp;*.jpg;*.gif;*.jpeg;*.tif;*.tiff" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            Bitmap bmp;
            try
            {
                bmp = (Bitmap)Image.FromFile(dialog.FileName);
            }
            catch
            {
                MessageBox.Show("Couldn't load the image at:\r\n" + dialog.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            logoPicture.Image = bmp;
        }
    }
}
