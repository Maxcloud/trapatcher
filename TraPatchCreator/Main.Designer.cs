namespace TraPatchCreator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenTPSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PatchVer = new System.Windows.Forms.NumericUpDown();
            this.PatchGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wzTypeCombo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PatchDesc = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.WZTree = new TreeViewMS.TreeViewMS();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatchVer)).BeginInit();
            this.PatchGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(537, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(59, 17);
            this.statusLabel.Text = "Loading...";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.AboutMenuItem,
            this.GenTPSMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMenuItem,
            this.SaveMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.Name = "LoadMenuItem";
            this.LoadMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LoadMenuItem.Text = "Load";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(100, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // GenTPSMenuItem
            // 
            this.GenTPSMenuItem.Name = "GenTPSMenuItem";
            this.GenTPSMenuItem.Size = new System.Drawing.Size(171, 20);
            this.GenTPSMenuItem.Text = "Generate TraPatcher Settings";
            this.GenTPSMenuItem.ToolTipText = "Opens a window to generate a settings file for TraPatcher";
            this.GenTPSMenuItem.Click += new System.EventHandler(this.GenTPSMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatchVer);
            this.groupBox1.Location = new System.Drawing.Point(27, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patch Version";
            // 
            // PatchVer
            // 
            this.PatchVer.Location = new System.Drawing.Point(6, 19);
            this.PatchVer.Name = "PatchVer";
            this.PatchVer.Size = new System.Drawing.Size(172, 20);
            this.PatchVer.TabIndex = 0;
            // 
            // PatchGroup
            // 
            this.PatchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PatchGroup.Controls.Add(this.groupBox2);
            this.PatchGroup.Controls.Add(this.groupBox3);
            this.PatchGroup.Controls.Add(this.groupBox1);
            this.PatchGroup.Location = new System.Drawing.Point(301, 27);
            this.PatchGroup.Name = "PatchGroup";
            this.PatchGroup.Size = new System.Drawing.Size(231, 308);
            this.PatchGroup.TabIndex = 6;
            this.PatchGroup.TabStop = false;
            this.PatchGroup.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wzTypeCombo);
            this.groupBox2.Location = new System.Drawing.Point(27, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 52);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WZ File Type";
            // 
            // wzTypeCombo
            // 
            this.wzTypeCombo.FormattingEnabled = true;
            this.wzTypeCombo.Items.AddRange(new object[] {
            "String.wz",
            "UI.wz",
            "Etc.wz",
            "Item.wz",
            "Map.wz",
            "Effect.wz",
            "Quest.wz",
            "Skill.wz",
            "Morph.wz",
            "Sound.wz",
            "Mob.wz",
            "Npc.wz",
            "Base.wz",
            "List.wz",
            "TamingMob.wz",
            "Character.wz",
            "Reactor.wz"});
            this.wzTypeCombo.Location = new System.Drawing.Point(6, 19);
            this.wzTypeCombo.MaxDropDownItems = 17;
            this.wzTypeCombo.Name = "wzTypeCombo";
            this.wzTypeCombo.Size = new System.Drawing.Size(172, 21);
            this.wzTypeCombo.TabIndex = 0;
            this.wzTypeCombo.SelectedIndexChanged += new System.EventHandler(this.wzTypeCombo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PatchDesc);
            this.groupBox3.Location = new System.Drawing.Point(6, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 159);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patch Description";
            // 
            // PatchDesc
            // 
            this.PatchDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PatchDesc.Location = new System.Drawing.Point(6, 19);
            this.PatchDesc.Multiline = true;
            this.PatchDesc.Name = "PatchDesc";
            this.PatchDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PatchDesc.Size = new System.Drawing.Size(208, 131);
            this.PatchDesc.TabIndex = 0;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 27);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(214, 20);
            this.SearchBox.TabIndex = 8;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(232, 27);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(63, 20);
            this.SearchBtn.TabIndex = 8;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // WZTree
            // 
            this.WZTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.WZTree.CheckBoxes = true;
            this.WZTree.FullRowSelect = true;
            this.WZTree.Location = new System.Drawing.Point(0, 53);
            this.WZTree.Name = "WZTree";
            this.WZTree.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("WZTree.SelectedNodes")));
            this.WZTree.Size = new System.Drawing.Size(295, 285);
            this.WZTree.TabIndex = 4;
            this.WZTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.WZTree_AfterCheck);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 360);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.WZTree);
            this.Controls.Add(this.PatchGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(553, 398);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraPatchCreator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PatchVer)).EndInit();
            this.PatchGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown PatchVer;
        private System.Windows.Forms.GroupBox PatchGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PatchDesc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox wzTypeCombo;
        private System.Windows.Forms.ToolStripMenuItem GenTPSMenuItem;
        private TreeViewMS.TreeViewMS WZTree;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchBtn;

    }
}

