namespace TraPatchCreator
{
    partial class GenTPS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenTPS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webUrl = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.serverName = new System.Windows.Forms.TextBox();
            this.startVer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.genBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.logoBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webUrl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "URL To Web Directory Containing Patches";
            // 
            // webUrl
            // 
            this.webUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webUrl.Location = new System.Drawing.Point(3, 16);
            this.webUrl.Name = "webUrl";
            this.webUrl.Size = new System.Drawing.Size(336, 20);
            this.webUrl.TabIndex = 0;
            this.toolTip1.SetToolTip(this.webUrl, resources.GetString("webUrl.ToolTip"));
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // serverName
            // 
            this.serverName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverName.Location = new System.Drawing.Point(3, 16);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(336, 20);
            this.serverName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.serverName, "The name of the server");
            // 
            // startVer
            // 
            this.startVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startVer.Location = new System.Drawing.Point(3, 16);
            this.startVer.Name = "startVer";
            this.startVer.Size = new System.Drawing.Size(336, 20);
            this.startVer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.startVer, resources.GetString("startVer.ToolTip"));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.serverName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Name";
            // 
            // genBtn
            // 
            this.genBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.genBtn.Location = new System.Drawing.Point(0, 293);
            this.genBtn.Name = "genBtn";
            this.genBtn.Size = new System.Drawing.Size(342, 35);
            this.genBtn.TabIndex = 2;
            this.genBtn.Text = "Generate Settings File";
            this.genBtn.UseVisualStyleBackColor = true;
            this.genBtn.Click += new System.EventHandler(this.genBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startVer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 48);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Starting Version";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.logoBtn);
            this.groupBox4.Controls.Add(this.logoPicture);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 144);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 149);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logo";
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPicture.Image = global::TraPatchCreator.Properties.Resources.DefaultLogo;
            this.logoPicture.InitialImage = global::TraPatchCreator.Properties.Resources.DefaultLogo;
            this.logoPicture.Location = new System.Drawing.Point(3, 48);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(336, 98);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPicture.TabIndex = 0;
            this.logoPicture.TabStop = false;
            this.toolTip1.SetToolTip(this.logoPicture, "The logo that will be shown in the background\r\nof the patcher.");
            // 
            // logoBtn
            // 
            this.logoBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoBtn.Location = new System.Drawing.Point(3, 16);
            this.logoBtn.Name = "logoBtn";
            this.logoBtn.Size = new System.Drawing.Size(336, 26);
            this.logoBtn.TabIndex = 3;
            this.logoBtn.Text = "Browse";
            this.logoBtn.UseVisualStyleBackColor = true;
            this.logoBtn.Click += new System.EventHandler(this.logoBtn_Click);
            // 
            // GenTPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 328);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.genBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(358, 366);
            this.Name = "GenTPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TraPatcher Settings Generator";
            this.Load += new System.EventHandler(this.GenTPS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox webUrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Button genBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox startVer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Button logoBtn;
    }
}