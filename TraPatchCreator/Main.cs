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
using System.Collections;
using System.Windows.Forms;
using MapleLib.WzLib;
using MapleLib.WzLib.WzProperties;
using MapleLib.WzLib.WzStructure;
using System.Reflection;
using System.Diagnostics;

namespace TraPatchCreator
{
    public partial class Main : Form
    {
        string wzFileType = "none";
        Hashtable imgsToSave = new Hashtable();
        List<string> dirsToRemove = new List<string>();
        Hashtable imgsToRemove = new Hashtable();

        public Main()
        {
            InitializeComponent();
        }

        private string ExceptionText(string task, string exceptionMsg)
        {
            return "I was just minded my own business, " + task + ", when all the sudden...BAM! '" + exceptionMsg + "'\r\nAin't that a trip?";
        }

        private void CheckThem(ArrayList boxes, bool nodechecked)
        {
            //WZTree.BeginUpdate();
            foreach (TreeNode sNode in WZTree.SelectedNodes)
            {
                sNode.Checked = nodechecked;
            }
            //WZTree.EndUpdate();
            WZTree.Update();
            WZTree.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PatchVer.Value = AppSettings.PatchVersion;
            wzTypeCombo.SelectedIndex = AppSettings.wzTypeIndex;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;
            AppSettings.curVersion = version;
        }

        private IWzObject MakeCustomProp(string name, object val)
        {
            if (val is bool) return new WzCompressedIntProperty(name, ((int)(MapleBool)val));
            else if (val is string) return new WzStringProperty(name, val.ToString());
            else if (Convert.ToInt32(val) != 0) return new WzCompressedIntProperty(name, Convert.ToInt32(val));
            else return new WzStringProperty(name, val.ToString());
        }

        private void WriteFilesTxt(string patchName, string patchVer)
        {
            if (Directory.Exists(AppSettings.SavePath))
            {
                Directory.CreateDirectory(AppSettings.SavePath + @"\" + patchVer);
                FileStream fileTxt = File.Create(AppSettings.SavePath + @"\" + patchVer + @"\Files.txt");
                File.OpenWrite(AppSettings.SavePath + @"\" + patchVer + @"\Files.txt");
            }
        }

        private void MakeWZTree()
        {
            WZTree.Nodes.Clear();
            statusLabel.Text = "Loading WZ imgs...";
            Application.DoEvents();
            Program.curFile.WzDirectory.ParseImages();
            Application.DoEvents();
            progressBar.Maximum = Program.curFile.WzDirectory.CountImages();
            Application.DoEvents();
            foreach (WzImage dirimg in Program.curFile.WzDirectory.WzImages)
            {
                if ((dirimg != null) && (WZTree.Nodes[dirimg.Name] == null))
                {
                    statusLabel.Text = "Loading WZ imgs... [Cur IMG: " + dirimg.Name + "]";
                    Application.DoEvents();
                    if (!dirimg.Parsed) dirimg.ParseImage();
                    Application.DoEvents();
                    WZTree.Nodes.Add(dirimg.Name, dirimg.Name).Tag = dirimg;
                    Application.DoEvents();
                    if ((dirimg["Changed"] != null) && (dirimg["Changed"].PropertyType == WzPropertyType.CompressedInt) && (((WzCompressedIntProperty)dirimg["Changed"]).Value == MapleBool.True))
                        WZTree.Nodes[dirimg.Name].Checked = true;
                    
                    if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
                    Application.DoEvents();
                }
            }
            foreach (WzDirectory dir in Program.curFile.WzDirectory.WzDirectories)
            {
                if ((dir != null) && (WZTree.Nodes[dir.Name] == null))
                    WZTree.Nodes.Add(dir.Name, dir.Name).Tag = dir;
                foreach (WzImage img in dir.GetChildImages())
                {
                    statusLabel.Text = "Loading WZ imgs... [Cur Dir: " + dir.Name + "] [Cur IMG: " + img.Name + "]";
                    Application.DoEvents();
                    if (!img.Parsed) img.ParseImage();
                    Application.DoEvents();
                    WZTree.Nodes[dir.Name].Nodes.Add(img.Name, img.Name).Tag = img;
                    Application.DoEvents();
                    if ((img["Changed"] != null) && (img["Changed"].PropertyType == WzPropertyType.CompressedInt) && (((WzCompressedIntProperty)img["Changed"]).Value == MapleBool.True))
                        WZTree.Nodes[dir.Name].Nodes[img.Name].Checked = true;

                    if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
                    Application.DoEvents();
                }
            }
            #region Old loop
            /*foreach (WzImage dirimg in Program.curFile.WzDirectory.GetChildImages())
            {
                if ((dirimg != null) && (WZTree.Nodes[dirimg.Name] == null))
                {
                    statusLabel.Text = "Loading WZ imgs... [Cur IMG: " + dirimg.Name + "]";
                    Application.DoEvents();
                    if (!dirimg.Parsed) dirimg.ParseImage();
                    Application.DoEvents();
                    //WZTree.Nodes.Add(dirimg.Name, dirimg.Name).Tag = dirimg;
                    Application.DoEvents();
                    if ((dirimg["Changed"] != null) && (dirimg["Changed"].PropertyType == WzPropertyType.CompressedInt) && (((WzCompressedIntProperty)dirimg["Changed"]).Value == MapleBool.True))
                        WZTree.Nodes[dirimg.Name].Checked = true;
                    
                    if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
                    Application.DoEvents();
                }
            }*/
            #endregion
            statusLabel.Text = "Finished loading WZ imgs";
            progressBar.Value = progressBar.Maximum;
            Application.DoEvents();
            WZTree.Sort();
            Application.DoEvents();
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.curFile == null)
                {
                    new Load().ShowDialog();
                    Application.DoEvents();
                    if (Program.curFile != null)
                    {
                        PatchGroup.Text = Program.curFile.Name;
                        if (wzTypeCombo.Items.Contains(Program.curFile.Name)) wzTypeCombo.SelectedItem = wzTypeCombo.Items[wzTypeCombo.Items.IndexOf(Program.curFile.Name)];
                        Application.DoEvents();
                        MakeWZTree();
                        Application.DoEvents();
                    }
                }
                else
                {
                    if (MessageBox.Show("You already have a wz file loaded, loading another will cause all unsaved changes to be lost, are you sure you wish to do this?", "Wz file already loaded", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                    else
                    {
                        Program.curFile.Dispose();
                        Program.curFile = null;
                        Application.DoEvents();
                        new Load().ShowDialog();
                        Application.DoEvents();
                        if (Program.curFile != null)
                        {
                            PatchGroup.Text = Program.curFile.Name;
                            Application.DoEvents();
                            MakeWZTree();
                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception WTFBBQ)
            {
                MessageBox.Show(ExceptionText("loading a wz file", WTFBBQ.Message));
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.curFile == null)
            {
                MessageBox.Show("No WZ file is currently loaded.", "No WZ file loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you wish to create the patch file?\r\nNOTE: When saving, the patch will be saved in a folder named the patch version, under the path you selected, and the name will be the WZ File Type selected.", "Create patch confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FolderBrowserDialog sfd;
                if (Directory.Exists(AppSettings.SavePath))
                    sfd = new FolderBrowserDialog() { Description = "Select a folder for the patch file to save to", SelectedPath = AppSettings.SavePath };
                else
                    sfd = new FolderBrowserDialog() { Description = "Select a folder for the patch file to save to" };

                if (sfd.ShowDialog() != DialogResult.OK) return;
                AppSettings.SavePath = sfd.SelectedPath;
                Application.DoEvents();
                statusLabel.Text = "Creating new patch file...";
                Application.DoEvents();
                progressBar.Value = 0;
                Application.DoEvents();
                imgsToSave.Clear();
                foreach (TreeNode ttNode in WZTree.Nodes)
                {
                    if (ttNode.Tag is WzImage)
                    {
                        if (ttNode.Checked)
                            imgsToSave.Add(((WzImage)ttNode.Tag).Name, (WzImage)ttNode.Tag);
                    }
                    else if (ttNode.Tag is WzDirectory)
                    {
                        foreach (TreeNode tNode in ttNode.Nodes)
                        {
                            if (tNode.Checked)
                                imgsToSave.Add(((WzImage)tNode.Tag).Name, (WzImage)tNode.Tag);
                        }
                    }
                }

                foreach (WzDirectory curObj in Program.curFile.WzDirectory.WzDirectories)
                {
                    bool containsWantedImage = false;
                    foreach (WzImage curImage in imgsToSave.Values)
                        if (curImage.FullPath.Contains(curObj.Name))
                        {
                            containsWantedImage = true;
                            break;
                        }

                    if (!containsWantedImage) dirsToRemove.Add(curObj.Name);
                }
                statusLabel.Text = "Creating new patch file... [Step 1 of 2]";
                progressBar.Maximum = dirsToRemove.Count + 1;
                Application.DoEvents();
                foreach (string dirName in dirsToRemove)
                {
                    if (Program.curFile.WzDirectory[dirName] != null)
                    {
                        Program.curFile.WzDirectory[dirName].Remove();
                        if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
                        Application.DoEvents();
                    }
                }

                foreach (WzImage curImg in Program.curFile.WzDirectory.GetChildImages())
                {
                    if ((imgsToSave[curImg.Name] == null) && (imgsToRemove[curImg.Name] == null))
                    {
                        /*if (imgsToRemove[curImg.Name] == null)*/ imgsToRemove.Add(curImg.Name,curImg);
                    }
                }

                progressBar.Maximum += imgsToRemove.Count;

                statusLabel.Text = "Creating new patch file... [Step 2 of 2]";
                foreach (WzImage imgName in imgsToRemove.Values)
                {
                    if (Program.curFile.WzDirectory.GetChildImages().Contains(imgName))
                    {
                        imgName.Remove();
                        if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
                        Application.DoEvents();
                    }
                }

                if (progressBar.Maximum > 0) progressBar.Value = progressBar.Maximum - 1;

                Application.DoEvents();
                /*Program.curFile.WzDirectory.AddImage(new WzImage("PatchProps.img"));
                Program.curFile.WzDirectory.GetImageByName("PatchProps.img").AddProperty((WzCompressedIntProperty)MakeCustomProp("Version", PatchVer.Value));
                Program.curFile.WzDirectory.GetImageByName("PatchProps.img").AddProperty((WzStringProperty)MakeCustomProp("Type", wzFileType));
                if (!String.IsNullOrWhiteSpace(PatchDesc.Text))
                    Program.curFile.WzDirectory.GetImageByName("PatchProps.img").AddProperty((WzStringProperty)MakeCustomProp("Description", PatchDesc.Text));
                //Program.curFile.WzDirectory.GetImageByName("PatchProps.img").ParseImage();
                Program.curFile.WzDirectory.GetImageByName("PatchProps.img").Changed = true;*/
                Application.DoEvents();
                if (!Directory.Exists(sfd.SelectedPath + @"\" + PatchVer.Value.ToString()))
                    Directory.CreateDirectory(sfd.SelectedPath + @"\" + PatchVer.Value.ToString());
                Program.curFile.SaveToDisk(sfd.SelectedPath + @"\" + PatchVer.Value.ToString() + @"\" + wzFileType);
                progressBar.Value = progressBar.Maximum;
                Application.DoEvents();
                AppSettings.PatchVersion = (int)PatchVer.Value;
                AppSettings.wzTypeIndex = (int)wzTypeCombo.SelectedIndex;
                MessageBox.Show("Save completed!");
            }
        }

        private void WZTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckThem(WZTree.SelectedNodes, e.Node.Checked);
                TreeNode tNode = e.Node;
                if ((tNode.Tag != null) && (tNode.Tag is WzDirectory))
                {
                    if (e.Action != TreeViewAction.Unknown)
                    {
                        foreach (TreeNode ttNode in tNode.Nodes)
                        {
                            ttNode.Checked = tNode.Checked;
                            //if (tNode.Checked) ttNode.Checked = true; else ttNode.Checked = false;
                        }
                    }
                }
            }
            if (sender is TreeNode)
            {
                TreeNode tNode = (TreeNode)sender;
                if ((tNode.Tag != null) && (tNode.Tag is WzImage))
                {
                    WzImage tnImg = (WzImage)tNode.Tag;
                    if (tNode.Checked)
                    {
                        if (imgsToSave[tnImg.Name] == null)
                            imgsToSave.Add(tnImg.Name, tnImg);
                    }
                    else if (!tNode.Checked)
                    {
                        if (imgsToSave[tnImg.Name] != null)
                            imgsToSave.Remove(tnImg.Name);
                    }
                }
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void wzTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            wzFileType = wzTypeCombo.SelectedItem.ToString();
        }

        private void GenTPSMenuItem_Click(object sender, EventArgs e)
        {
            new GenTPS().ShowDialog();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string text = SearchBox.Text;
            bool found = false;
            foreach (TreeNode tNode in WZTree.Nodes)
            {
                if (tNode.Text.ToLower().Contains(text.ToLower()))
                {
                    found = true;
                    tNode.EnsureVisible();
                    WZTree.SelectedNode = tNode;
                    tNode.BackColor = SystemColors.Highlight;
                    tNode.ForeColor = SystemColors.HighlightText;
                    break;
                }
                else
                {
                    if (tNode.Tag is WzDirectory)
                    {
                        foreach (TreeNode ttNode in tNode.Nodes)
                        {
                            if (ttNode.Text.ToLower().Contains(text.ToLower()))
                            {
                                found = true;
                                ttNode.EnsureVisible();
                                WZTree.SelectedNode = ttNode;
                                ttNode.BackColor = SystemColors.Highlight;
                                ttNode.ForeColor = SystemColors.HighlightText;
                                break;
                            }
                        }
                    }
                }
                if (found) break;
            }
            if (!found) MessageBox.Show("Search yielded no results");
        }
    }
}
