namespace ArtGalleryProblem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_screen = new System.Windows.Forms.Panel();
            this.lbl_cords = new System.Windows.Forms.Label();
            this.ýmageList = new System.Windows.Forms.ImageList(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbl_min_guards = new System.Windows.Forms.Label();
            this.cmb_minumum = new System.Windows.Forms.ComboBox();
            this.cmb_other = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lnk_about = new System.Windows.Forms.LinkLabel();
            this.cmd_scan2 = new System.Windows.Forms.Button();
            this.cmd_scan1 = new System.Windows.Forms.Button();
            this.cmd_animate = new System.Windows.Forms.Button();
            this.cmd_3color = new System.Windows.Forms.Button();
            this.cmd_clear = new System.Windows.Forms.Button();
            this.cmd_cut = new System.Windows.Forms.Button();
            this.panel_screen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_screen
            // 
            this.panel_screen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_screen.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel_screen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_screen.Controls.Add(this.lnk_about);
            this.panel_screen.Controls.Add(this.lbl_cords);
            this.panel_screen.Location = new System.Drawing.Point(0, 1);
            this.panel_screen.Name = "panel_screen";
            this.panel_screen.Size = new System.Drawing.Size(939, 447);
            this.panel_screen.TabIndex = 0;
            this.panel_screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_screen_MouseMove);
            this.panel_screen.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_screen_Paint);
            this.panel_screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_screen_MouseUp);
            // 
            // lbl_cords
            // 
            this.lbl_cords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_cords.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_cords.Location = new System.Drawing.Point(423, 415);
            this.lbl_cords.Name = "lbl_cords";
            this.lbl_cords.Size = new System.Drawing.Size(92, 12);
            this.lbl_cords.TabIndex = 4;
            this.lbl_cords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ýmageList
            // 
            this.ýmageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ýmageList.ImageStream")));
            this.ýmageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ýmageList.Images.SetKeyName(0, "Tutorial.ico");
            this.ýmageList.Images.SetKeyName(1, "Easel2.ico");
            this.ýmageList.Images.SetKeyName(2, "Windows_Luna.ico");
            this.ýmageList.Images.SetKeyName(3, "folder_blue_videos.ico");
            this.ýmageList.Images.SetKeyName(4, "Find.ico");
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 453);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(455, 112);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lbl_min_guards
            // 
            this.lbl_min_guards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_min_guards.AutoSize = true;
            this.lbl_min_guards.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_min_guards.Location = new System.Drawing.Point(4, 14);
            this.lbl_min_guards.Name = "lbl_min_guards";
            this.lbl_min_guards.Size = new System.Drawing.Size(93, 12);
            this.lbl_min_guards.TabIndex = 6;
            this.lbl_min_guards.Text = "Minimum Guards:";
            // 
            // cmb_minumum
            // 
            this.cmb_minumum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_minumum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_minumum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_minumum.FormattingEnabled = true;
            this.cmb_minumum.Location = new System.Drawing.Point(6, 31);
            this.cmb_minumum.Name = "cmb_minumum";
            this.cmb_minumum.Size = new System.Drawing.Size(163, 20);
            this.cmb_minumum.TabIndex = 7;
            // 
            // cmb_other
            // 
            this.cmb_other.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_other.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_other.FormattingEnabled = true;
            this.cmb_other.Location = new System.Drawing.Point(6, 74);
            this.cmb_other.Name = "cmb_other";
            this.cmb_other.Size = new System.Drawing.Size(163, 20);
            this.cmb_other.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Other:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmb_minumum);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmd_scan2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lbl_min_guards);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cmb_other);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmd_scan1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(687, 453);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 110);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guards";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.ImageIndex = 3;
            this.button4.Location = new System.Drawing.Point(-260, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 57);
            this.button4.TabIndex = 5;
            this.button4.Text = "Animate";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.cmd_animate_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 1;
            this.button3.Location = new System.Drawing.Point(-260, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 57);
            this.button3.TabIndex = 3;
            this.button3.Text = "3-color";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.cmd_3color_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.ImageIndex = 2;
            this.button2.Location = new System.Drawing.Point(-140, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 56);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cmd_clear_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.ImageIndex = 0;
            this.button1.Location = new System.Drawing.Point(-351, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Triangulate";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmd_cut_Click);
            // 
            // lnk_about
            // 
            this.lnk_about.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lnk_about.Location = new System.Drawing.Point(891, 420);
            this.lnk_about.Name = "lnk_about";
            this.lnk_about.Size = new System.Drawing.Size(46, 23);
            this.lnk_about.TabIndex = 5;
            this.lnk_about.TabStop = true;
            this.lnk_about.Text = "About";
            this.lnk_about.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnk_about.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_about_LinkClicked);
            // 
            // cmd_scan2
            // 
            this.cmd_scan2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_scan2.Enabled = false;
            this.cmd_scan2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_scan2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_scan2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_scan2.ImageIndex = 4;
            this.cmd_scan2.ImageList = this.ýmageList;
            this.cmd_scan2.Location = new System.Drawing.Point(175, 67);
            this.cmd_scan2.Name = "cmd_scan2";
            this.cmd_scan2.Size = new System.Drawing.Size(71, 32);
            this.cmd_scan2.TabIndex = 11;
            this.cmd_scan2.Text = "Scan";
            this.cmd_scan2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_scan2.UseVisualStyleBackColor = true;
            this.cmd_scan2.Click += new System.EventHandler(this.cmd_scan2_Click);
            // 
            // cmd_scan1
            // 
            this.cmd_scan1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_scan1.Enabled = false;
            this.cmd_scan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_scan1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_scan1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_scan1.ImageIndex = 4;
            this.cmd_scan1.ImageList = this.ýmageList;
            this.cmd_scan1.Location = new System.Drawing.Point(175, 30);
            this.cmd_scan1.Name = "cmd_scan1";
            this.cmd_scan1.Size = new System.Drawing.Size(71, 31);
            this.cmd_scan1.TabIndex = 10;
            this.cmd_scan1.Text = "Scan";
            this.cmd_scan1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_scan1.UseVisualStyleBackColor = true;
            this.cmd_scan1.Click += new System.EventHandler(this.cmd_scan1_Click);
            // 
            // cmd_animate
            // 
            this.cmd_animate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_animate.Enabled = false;
            this.cmd_animate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_animate.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_animate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_animate.ImageIndex = 3;
            this.cmd_animate.ImageList = this.ýmageList;
            this.cmd_animate.Location = new System.Drawing.Point(574, 515);
            this.cmd_animate.Name = "cmd_animate";
            this.cmd_animate.Size = new System.Drawing.Size(107, 37);
            this.cmd_animate.TabIndex = 5;
            this.cmd_animate.Text = "Animate";
            this.cmd_animate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_animate.UseVisualStyleBackColor = true;
            this.cmd_animate.Click += new System.EventHandler(this.cmd_animate_Click);
            // 
            // cmd_3color
            // 
            this.cmd_3color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_3color.Enabled = false;
            this.cmd_3color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_3color.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_3color.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_3color.ImageIndex = 1;
            this.cmd_3color.ImageList = this.ýmageList;
            this.cmd_3color.Location = new System.Drawing.Point(574, 468);
            this.cmd_3color.Name = "cmd_3color";
            this.cmd_3color.Size = new System.Drawing.Size(107, 37);
            this.cmd_3color.TabIndex = 3;
            this.cmd_3color.Text = "3-color";
            this.cmd_3color.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_3color.UseVisualStyleBackColor = true;
            this.cmd_3color.Click += new System.EventHandler(this.cmd_3color_Click);
            // 
            // cmd_clear
            // 
            this.cmd_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_clear.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_clear.ImageIndex = 2;
            this.cmd_clear.ImageList = this.ýmageList;
            this.cmd_clear.Location = new System.Drawing.Point(461, 515);
            this.cmd_clear.Name = "cmd_clear";
            this.cmd_clear.Size = new System.Drawing.Size(107, 37);
            this.cmd_clear.TabIndex = 2;
            this.cmd_clear.Text = "Clear";
            this.cmd_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_clear.UseVisualStyleBackColor = true;
            this.cmd_clear.Click += new System.EventHandler(this.cmd_clear_Click);
            // 
            // cmd_cut
            // 
            this.cmd_cut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_cut.Enabled = false;
            this.cmd_cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_cut.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_cut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_cut.ImageIndex = 0;
            this.cmd_cut.ImageList = this.ýmageList;
            this.cmd_cut.Location = new System.Drawing.Point(461, 467);
            this.cmd_cut.Name = "cmd_cut";
            this.cmd_cut.Size = new System.Drawing.Size(107, 38);
            this.cmd_cut.TabIndex = 1;
            this.cmd_cut.Text = "Triangulate";
            this.cmd_cut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd_cut.UseVisualStyleBackColor = true;
            this.cmd_cut.Click += new System.EventHandler(this.cmd_cut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 570);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmd_animate);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmd_3color);
            this.Controls.Add(this.cmd_clear);
            this.Controls.Add(this.cmd_cut);
            this.Controls.Add(this.panel_screen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "\'Art Gallery Problem\' - Hüseyin Uslu";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel_screen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_screen;
        private System.Windows.Forms.Button cmd_cut;
        private System.Windows.Forms.Button cmd_clear;
        private System.Windows.Forms.Button cmd_3color;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbl_cords;
        private System.Windows.Forms.Button cmd_animate;
        private System.Windows.Forms.Label lbl_min_guards;
        private System.Windows.Forms.ComboBox cmb_minumum;
        private System.Windows.Forms.ComboBox cmb_other;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmd_scan1;
        private System.Windows.Forms.Button cmd_scan2;
        private System.Windows.Forms.ImageList ýmageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel lnk_about;
    }
}

