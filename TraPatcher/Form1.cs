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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using MapleLib;
using MapleLib.WzLib;
using MapleLib.WzLib.Util;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace TraPatcher
{
    public partial class Form1 : Form
    {

        public List<string> WzTypes = new List<string>() {
            "String.wz","UI.wz","Etc.wz","Item.wz","Map.wz","Effect.wz","Quest.wz","Skill.wz","Morph.wz","Sound.wz","Mob.wz","Npc.wz",
            "Base.wz","List.wz","TamingMob.wz","Character.wz","Reactor.wz"
        };

        

        //The progressbar and status text will change quickly alot, so I made this to use after changing them to
        //make sure the updates get shown immediately. -DeathRight
        private void RefreshStuff()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ProgressValue));
                return;
            }
            StatusLabel.Refresh();
            progressBar1.Refresh();
            Application.DoEvents();
        }

        public bool CheckPath(string directory)
        {
            bool exists = false;
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request;
                request = WebRequest.Create(directory) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TURE if the Status code == 200
                exists = (response.StatusCode == HttpStatusCode.OK);
                response.Close();
                request.Abort();
            }
            catch
            {
                //Any exception will returns false.
                exists = false;
            }
            return exists;
            /*bool retBool = false;
            try
            {
                WebClient client = new WebClient();
                client.DownloadStringAsync(new Uri(path));
                //client.DownloadString(new Uri(path));
                client.Dispose();
                retBool = true;
            }
            catch
            {
                retBool = false;
            }
            return retBool;*/
        }

        public bool CheckFile(string path)
        {
            bool retBool = false;
            try
            {
                WebRequest wReq = WebRequest.Create(new Uri(path));
                wReq.Method = "HEAD";
                WebResponse wRes = wReq.GetResponse();
                //MessageBox.Show("ContentType: '" + wRes.ContentType + "'; ContentLength: '" + wRes.ContentLength + "';");
                if (wRes.ContentLength != -1)
                    retBool = true;
                else
                    retBool = false;

                wRes.Close();
                wReq.Abort();
            }
            catch
            {
                retBool = false;
            }
            return retBool;
        }

        /*public void ReplaceObj(IWzObject obj, WzFile baseFile)
        {
            if (baseFile.GetObjectFromPath(obj.FullPath) == null)
                ReplaceObj(obj.Parent, baseFile);
            else
            {
                baseFile.GetObjectFromPath(obj.FullPath).Remove();
                baseFile.GetObjectFromPath(obj.Parent.FullPath)
            }
        }*/

        public void ReplaceDirs(WzDirectory parent, WzFile orignal)
        {
            string curVTxt = "(Current V" + Patcher_UserSettings.CurrentVersion + ")";
            string slTxt = curVTxt + " Patching files...";
            //AppendStatus("TEST");
            //RefreshStuff();
            foreach (WzDirectory dir in parent.WzDirectories)
            {
                if (orignal.GetObjectFromPath(dir.FullPath.Replace(@"\", "/")) == null)
                {
                    /*AppendStatus("TEST1");
                    RefreshStuff();
                    MessageBox.Show("TEST1");*/
                    ((WzDirectory)orignal.GetObjectFromPath(dir.FullPath.Replace(@"\", "/"))).AddDirectory(dir);
                }
                if ((dir.WzDirectories.Count != 0) || (dir.WzImages.Count != 0))
                {
                    /*AppendStatus("TEST2");
                    RefreshStuff();
                    MessageBox.Show("TEST2");*/
                    ReplaceDirs(dir, orignal);
                }

                AppendStatus(slTxt + " [" + orignal.Name + "]" + " [" + ((WzDirectory)dir).Name + "]");
                RefreshStuff();
            }
            //if (parent.WzImages.Count <= 0) { MessageBox.Show("TEST4"); }
            if ((parent.WzImages != null) && (parent.WzImages.Count > 0))
            {
                ProgressValue(0);
                ProgressStyle(ProgressBarStyle.Continuous);
                ProgressMax(parent.WzImages.Count);
                RefreshStuff();
            }
            foreach (WzImage img in parent.WzImages)
            {
                /*AppendStatus("TEST5"); //THIS HAPPENS ON STRING.WZ BUT NOT CHARACTER.WZ
                RefreshStuff();
                MessageBox.Show("TEST5");*/
                if (orignal.GetObjectFromPath(img.FullPath.Replace(@"\", "/")) != null)
                {
                    object Dir = orignal.GetObjectFromPath(img.FullPath.Replace(@"\", "/")).Parent; //is WzDirectory
                    AppendStatus(slTxt + " [" + orignal.Name + "]" + " [" + ((WzDirectory)Dir).Name + "]" + " [" + ((WzImage)img).Name + "]");
                    RefreshStuff();
                    ((WzImage)orignal.GetObjectFromPath(img.FullPath.Replace(@"\", "/"))).Remove();
                    if (Dir is WzDirectory)
                    {
                        ((WzDirectory)Dir).AddImage(img);
                        ((WzImage)((WzDirectory)Dir)[img.Name]).Changed = true;
                    }
                    else if (Dir is WzFile)
                    {
                        ((WzFile)Dir).WzDirectory.AddImage(img);
                        ((WzImage)((WzFile)Dir).WzDirectory[img.Name]).Changed = true;
                    }
                    ProgressValue();
                    RefreshStuff();
                }
                else
                {
                    string path = img.Parent.FullPath.Replace(@"\", "/");
                    object dir = orignal.GetObjectFromPath(path);
                    AppendStatus(slTxt + " [" + orignal.Name + "]" + " [" + ((WzDirectory)dir).Name + "]" + " [" + ((WzImage)img).Name + "]");
                    RefreshStuff();
                    if (dir is WzDirectory)
                    {
                        ((WzDirectory)dir).AddImage(img);
                        ((WzImage)((WzDirectory)dir)[img.Name]).Changed = true;
                    }
                    else if (dir is WzFile)
                    {
                        ((WzFile)dir).WzDirectory.AddImage(img);
                        ((WzImage)((WzFile)dir).WzDirectory[img.Name]).Changed = true;
                    }
                    ProgressValue();
                    RefreshStuff();
                }
            }
        }

        public void Patch()
        {
            string curVTxt = "(Current V" + Patcher_UserSettings.CurrentVersion + ")";
            AppendStatus(curVTxt + " Checking for updates...");
            ProgressStyle(ProgressBarStyle.Marquee);
            WebClient download = new WebClient();
            //MessageBox.Show("hai");
            if (!CheckPath(Patcher_AppSettings.PatchURL)) //Check if the website directory actually exists. -DeathRight
            {
                download.Dispose();
                MessageBox.Show("The specified URL cannot be found, please contact the server owner or post in the help section of the server forum.", "Unreachable URL");
                Application.Exit();
            }

            //MessageBox.Show("hai2");

            if (!CheckPath(Patcher_AppSettings.PatchURL + "/" + (Patcher_UserSettings.CurrentVersion + 1).ToString()))
            {
                download.Dispose();
                Application.Exit(); //If there isn't a folder with a version 1 higher than the current, we can't update, so exit. -DeathRight
            }

            Dictionary<string, WzFile> WzFiles = new Dictionary<string, WzFile>();
            AppendStatus(curVTxt + " Downloading patch files...");
            ProgressValue(0);
            ProgressStyle(ProgressBarStyle.Marquee);
            RefreshStuff();
            Directory.CreateDirectory(Application.StartupPath + @"\Patches");
            foreach (string wzFile in WzTypes)
            {
                if (CheckFile(Patcher_AppSettings.PatchURL + "/" + (Patcher_UserSettings.CurrentVersion + 1).ToString() + "/" + wzFile))
                {
                    download.DownloadFile(Patcher_AppSettings.PatchURL + "/" + (Patcher_UserSettings.CurrentVersion + 1).ToString() + "/" + wzFile, Application.StartupPath + @"\Patches\" + wzFile);
                    short version = -1;
                    WzMapleVersion nWzFV = WzTool.DetectMapleVersion(Application.StartupPath + @"\Patches\" + wzFile, out version);
                    WzFile nWzF = new WzFile(Application.StartupPath + @"\Patches\" + wzFile, nWzFV);
                    nWzF.ParseWzFile();
                    nWzF.WzDirectory.ParseImages(); //Just to be safe -DeathRight
                    WzFiles.Add(wzFile, nWzF);
                }
            }
            download.Dispose();

            if (WzFiles.Count <= 0)
            {
                return;
            }

            string slTxt = curVTxt + " Patching files...";
            AppendStatus(slTxt);
            ProgressStyle(ProgressBarStyle.Continuous);
            //ProgressMax(WzFiles.Count);
            RefreshStuff();
            Directory.CreateDirectory(Application.StartupPath + @"\Patches\TEMP");
            foreach (WzFile wzFile in WzFiles.Values)
            {
                if (wzFile.WzDirectory["PatchInfo"] != null)
                    wzFile.WzDirectory["PatchInfo"].Remove();

                if (!File.Exists(Application.StartupPath + @"\" + wzFile.Name))
                {
                    MessageBox.Show("Unable to find WZ '" + wzFile.Name + "' in path '" + Application.StartupPath + "'","Unable to find WZ file");
                    Application.Exit();
                }

                ProgressValue(0);
                ProgressStyle(ProgressBarStyle.Marquee);
                RefreshStuff();
                AppendStatus(slTxt + " [" + wzFile.Name + "]");
                RefreshStuff();

                short version = -1;
                WzFile origWz = new WzFile(Application.StartupPath + @"\" + wzFile.Name, WzTool.DetectMapleVersion(Application.StartupPath + @"\" + wzFile.Name, out version));
                origWz.ParseWzFile();
                origWz.WzDirectory.ParseImages();
                try
                {
                    ReplaceDirs(wzFile.WzDirectory, origWz);
                    origWz.SaveToDisk(Application.StartupPath + @"\Patches\TEMP\" + wzFile.Name);
                }
                catch
                {
                    MessageBox.Show("Error while trying to save WZ file '" + wzFile.Name + "'", "Error saving WZ file");
                    wzFile.Dispose();
                    origWz.Dispose();
                    File.Delete(Application.StartupPath + @"\Patches\" + wzFile);
                    Application.Exit();
                }
                string wzName = wzFile.Name;
                wzFile.Dispose();
                origWz.Dispose();
                File.Delete(Application.StartupPath + @"\Patches\" + wzName);
                File.Delete(Application.StartupPath + @"\" + wzName);
                File.Move(Application.StartupPath + @"\Patches\TEMP\" + wzName, Application.StartupPath + @"\" + wzName);

                //ProgressValue();

                //RefreshStuff();
            }

            Patcher_UserSettings.CurrentVersion++;
            Patch();
        }

        public void AppendStatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendStatus), new object[] { value });
                return;
            }
            StatusLabel.Text = value;
        }

        public void ProgressValue(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(ProgressValue), new object[] { value });
                return;
            }
            if (value <= progressBar1.Maximum) progressBar1.Value = value;
        }

        public void ProgressValue()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ProgressValue));
                return;
            }
            if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
        }

        public void ProgressStyle(ProgressBarStyle value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ProgressBarStyle>(ProgressStyle), new object[] { value });
                return;
            }
            progressBar1.Style = value;
        }

        public void ProgressMin(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(ProgressMin), new object[] { value });
                return;
            }
            progressBar1.Minimum = value;
        }

        public void ProgressMax(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(ProgressMax), new object[] { value });
                return;
            }
            progressBar1.Maximum = value;
        }

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Patcher_AppSettings.PatcherLogo;
            Show();
            ServerName.Text = Patcher_AppSettings.ServerName + " Patcher";
            ServerName.Refresh();
            StatusLabel.Text = "(Current V" + Patcher_UserSettings.CurrentVersion + ") Checking for updates...";
            progressBar1.Style = ProgressBarStyle.Marquee;
            RefreshStuff();
            //Patch();
            backgroundWorker1.RunWorkerAsync();
            //Application.ExitThread();
            //Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Patch();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
