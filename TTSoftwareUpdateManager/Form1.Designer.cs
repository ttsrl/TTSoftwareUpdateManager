namespace TTSoftwareUpdateManager
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connettiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnettiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icList = new System.Windows.Forms.ImageList(this.components);
            this.level0 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.aggiornamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.modificaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.svuotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.convalidaCartellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelNaN = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.level2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.rimuoviToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderInfo = new System.Windows.Forms.Panel();
            this.lbl_dir_lastMod = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_dir_dim = new System.Windows.Forms.Label();
            this.lbl_dir_type = new System.Windows.Forms.Label();
            this.lbl_dir_folders = new System.Windows.Forms.Label();
            this.lbl_dir_files = new System.Windows.Forms.Label();
            this.lbl_dir_elms = new System.Windows.Forms.Label();
            this.lbl_dir_url = new System.Windows.Forms.Label();
            this.lbl_dir_nm = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tit_prev = new System.Windows.Forms.Label();
            this.lbl_prev = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.level0.SuspendLayout();
            this.levelNaN.SuspendLayout();
            this.level2.SuspendLayout();
            this.folderInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modificaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1053, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connettiToolStripMenuItem,
            this.disconnettiToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connettiToolStripMenuItem
            // 
            this.connettiToolStripMenuItem.Name = "connettiToolStripMenuItem";
            this.connettiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connettiToolStripMenuItem.Text = "Connetti";
            this.connettiToolStripMenuItem.Click += new System.EventHandler(this.ConnettiToolStripMenuItem_Click);
            // 
            // disconnettiToolStripMenuItem
            // 
            this.disconnettiToolStripMenuItem.Enabled = false;
            this.disconnettiToolStripMenuItem.Name = "disconnettiToolStripMenuItem";
            this.disconnettiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disconnettiToolStripMenuItem.Text = "Disconnetti";
            this.disconnettiToolStripMenuItem.Click += new System.EventHandler(this.DisconnettiToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem1,
            this.toolStripSeparator5,
            this.opzioniToolStripMenuItem});
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.modificaToolStripMenuItem.Text = "Modifica";
            // 
            // nuovoToolStripMenuItem1
            // 
            this.nuovoToolStripMenuItem1.Enabled = false;
            this.nuovoToolStripMenuItem1.Name = "nuovoToolStripMenuItem1";
            this.nuovoToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.nuovoToolStripMenuItem1.Text = "Nuovo";
            this.nuovoToolStripMenuItem1.Click += new System.EventHandler(this.NuovoToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(112, 6);
            // 
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.opzioniToolStripMenuItem.Text = "Opzioni";
            this.opzioniToolStripMenuItem.Click += new System.EventHandler(this.OpzioniToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icList;
            this.treeView1.Location = new System.Drawing.Point(9, 32);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(514, 755);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView1_MouseDown);
            // 
            // icList
            // 
            this.icList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icList.ImageStream")));
            this.icList.TransparentColor = System.Drawing.Color.Transparent;
            this.icList.Images.SetKeyName(0, "folder_close.png");
            this.icList.Images.SetKeyName(1, "folder_open.png");
            this.icList.Images.SetKeyName(2, "folder_error.png");
            this.icList.Images.SetKeyName(3, "version.png");
            this.icList.Images.SetKeyName(4, "list.png");
            this.icList.Images.SetKeyName(5, "log.png");
            this.icList.Images.SetKeyName(6, "file.png");
            this.icList.Images.SetKeyName(7, "bin.png");
            this.icList.Images.SetKeyName(8, "css.png");
            this.icList.Images.SetKeyName(9, "dll.png");
            this.icList.Images.SetKeyName(10, "doc.png");
            this.icList.Images.SetKeyName(11, "exe.png");
            this.icList.Images.SetKeyName(12, "htm.png");
            this.icList.Images.SetKeyName(13, "ico.png");
            this.icList.Images.SetKeyName(14, "ini.png");
            this.icList.Images.SetKeyName(15, "iso.png");
            this.icList.Images.SetKeyName(16, "jar.png");
            this.icList.Images.SetKeyName(17, "jpg.png");
            this.icList.Images.SetKeyName(18, "pdf.png");
            this.icList.Images.SetKeyName(19, "png.png");
            this.icList.Images.SetKeyName(20, "txt.png");
            this.icList.Images.SetKeyName(21, "xml.png");
            this.icList.Images.SetKeyName(22, "zip.png");
            // 
            // level0
            // 
            this.level0.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.level0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriToolStripMenuItem,
            this.toolStripSeparator6,
            this.aggiornamentoToolStripMenuItem,
            this.toolStripSeparator1,
            this.modificaToolStripMenuItem1,
            this.toolStripSeparator3,
            this.svuotaToolStripMenuItem,
            this.rimuoviToolStripMenuItem,
            this.toolStripSeparator2,
            this.convalidaCartellaToolStripMenuItem});
            this.level0.Name = "level0";
            this.level0.Size = new System.Drawing.Size(169, 160);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.ApriToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
            // 
            // aggiornamentoToolStripMenuItem
            // 
            this.aggiornamentoToolStripMenuItem.Name = "aggiornamentoToolStripMenuItem";
            this.aggiornamentoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aggiornamentoToolStripMenuItem.Text = "Aggiornamento";
            this.aggiornamentoToolStripMenuItem.Click += new System.EventHandler(this.AggiornamentoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // modificaToolStripMenuItem1
            // 
            this.modificaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nomeToolStripMenuItem,
            this.versioneToolStripMenuItem});
            this.modificaToolStripMenuItem1.Name = "modificaToolStripMenuItem1";
            this.modificaToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.modificaToolStripMenuItem1.Text = "Modifica";
            // 
            // nomeToolStripMenuItem
            // 
            this.nomeToolStripMenuItem.Name = "nomeToolStripMenuItem";
            this.nomeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.nomeToolStripMenuItem.Text = "Nome";
            this.nomeToolStripMenuItem.Click += new System.EventHandler(this.NomeToolStripMenuItem_Click);
            // 
            // versioneToolStripMenuItem
            // 
            this.versioneToolStripMenuItem.Name = "versioneToolStripMenuItem";
            this.versioneToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.versioneToolStripMenuItem.Text = "Versione";
            this.versioneToolStripMenuItem.Click += new System.EventHandler(this.VersioneToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // svuotaToolStripMenuItem
            // 
            this.svuotaToolStripMenuItem.Name = "svuotaToolStripMenuItem";
            this.svuotaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.svuotaToolStripMenuItem.Text = "Svuota";
            this.svuotaToolStripMenuItem.Click += new System.EventHandler(this.SvuotaToolStripMenuItem_Click);
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.RimuoviToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // convalidaCartellaToolStripMenuItem
            // 
            this.convalidaCartellaToolStripMenuItem.Name = "convalidaCartellaToolStripMenuItem";
            this.convalidaCartellaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.convalidaCartellaToolStripMenuItem.Text = "Convalida cartella";
            this.convalidaCartellaToolStripMenuItem.Click += new System.EventHandler(this.ConvalidaCartellaToolStripMenuItem_Click);
            // 
            // levelNaN
            // 
            this.levelNaN.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.levelNaN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem,
            this.toolStripSeparator4,
            this.refreshToolStripMenuItem});
            this.levelNaN.Name = "levelNaN";
            this.levelNaN.Size = new System.Drawing.Size(114, 54);
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.NuovoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(110, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(409, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(238, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // level2
            // 
            this.level2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.level2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.toolStripSeparator7,
            this.rimuoviToolStripMenuItem1});
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(129, 54);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(125, 6);
            // 
            // rimuoviToolStripMenuItem1
            // 
            this.rimuoviToolStripMenuItem1.Name = "rimuoviToolStripMenuItem1";
            this.rimuoviToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.rimuoviToolStripMenuItem1.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem1.Click += new System.EventHandler(this.RimuoviToolStripMenuItem1_Click);
            // 
            // folderInfo
            // 
            this.folderInfo.Controls.Add(this.lbl_prev);
            this.folderInfo.Controls.Add(this.lbl_tit_prev);
            this.folderInfo.Controls.Add(this.lbl_dir_lastMod);
            this.folderInfo.Controls.Add(this.label10);
            this.folderInfo.Controls.Add(this.lbl_dir_dim);
            this.folderInfo.Controls.Add(this.lbl_dir_type);
            this.folderInfo.Controls.Add(this.lbl_dir_folders);
            this.folderInfo.Controls.Add(this.lbl_dir_files);
            this.folderInfo.Controls.Add(this.lbl_dir_elms);
            this.folderInfo.Controls.Add(this.lbl_dir_url);
            this.folderInfo.Controls.Add(this.lbl_dir_nm);
            this.folderInfo.Controls.Add(this.label8);
            this.folderInfo.Controls.Add(this.label7);
            this.folderInfo.Controls.Add(this.label6);
            this.folderInfo.Controls.Add(this.label5);
            this.folderInfo.Controls.Add(this.label4);
            this.folderInfo.Controls.Add(this.label3);
            this.folderInfo.Controls.Add(this.label2);
            this.folderInfo.Controls.Add(this.label1);
            this.folderInfo.Location = new System.Drawing.Point(541, 32);
            this.folderInfo.Name = "folderInfo";
            this.folderInfo.Size = new System.Drawing.Size(500, 755);
            this.folderInfo.TabIndex = 4;
            this.folderInfo.Visible = false;
            // 
            // lbl_dir_lastMod
            // 
            this.lbl_dir_lastMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_lastMod.Location = new System.Drawing.Point(151, 293);
            this.lbl_dir_lastMod.Name = "lbl_dir_lastMod";
            this.lbl_dir_lastMod.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_lastMod.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Ultima Modifica:";
            // 
            // lbl_dir_dim
            // 
            this.lbl_dir_dim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_dim.Location = new System.Drawing.Point(151, 260);
            this.lbl_dir_dim.Name = "lbl_dir_dim";
            this.lbl_dir_dim.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_dim.TabIndex = 14;
            // 
            // lbl_dir_type
            // 
            this.lbl_dir_type.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_type.Location = new System.Drawing.Point(151, 227);
            this.lbl_dir_type.Name = "lbl_dir_type";
            this.lbl_dir_type.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_type.TabIndex = 13;
            // 
            // lbl_dir_folders
            // 
            this.lbl_dir_folders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_folders.Location = new System.Drawing.Point(151, 194);
            this.lbl_dir_folders.Name = "lbl_dir_folders";
            this.lbl_dir_folders.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_folders.TabIndex = 12;
            // 
            // lbl_dir_files
            // 
            this.lbl_dir_files.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_files.Location = new System.Drawing.Point(151, 161);
            this.lbl_dir_files.Name = "lbl_dir_files";
            this.lbl_dir_files.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_files.TabIndex = 11;
            // 
            // lbl_dir_elms
            // 
            this.lbl_dir_elms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_elms.Location = new System.Drawing.Point(151, 128);
            this.lbl_dir_elms.Name = "lbl_dir_elms";
            this.lbl_dir_elms.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_elms.TabIndex = 10;
            // 
            // lbl_dir_url
            // 
            this.lbl_dir_url.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_url.Location = new System.Drawing.Point(151, 95);
            this.lbl_dir_url.Name = "lbl_dir_url";
            this.lbl_dir_url.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_url.TabIndex = 9;
            // 
            // lbl_dir_nm
            // 
            this.lbl_dir_nm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir_nm.Location = new System.Drawing.Point(151, 62);
            this.lbl_dir_nm.Name = "lbl_dir_nm";
            this.lbl_dir_nm.Size = new System.Drawing.Size(334, 20);
            this.lbl_dir_nm.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(63, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dimensioni:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sub Folder:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Files:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Elementi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informazioni:";
            // 
            // lbl_tit_prev
            // 
            this.lbl_tit_prev.AutoSize = true;
            this.lbl_tit_prev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tit_prev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbl_tit_prev.Location = new System.Drawing.Point(20, 355);
            this.lbl_tit_prev.Name = "lbl_tit_prev";
            this.lbl_tit_prev.Size = new System.Drawing.Size(95, 21);
            this.lbl_tit_prev.TabIndex = 17;
            this.lbl_tit_prev.Text = "Anteprima:";
            this.lbl_tit_prev.Visible = false;
            // 
            // lbl_prev
            // 
            this.lbl_prev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_prev.Location = new System.Drawing.Point(52, 405);
            this.lbl_prev.Name = "lbl_prev";
            this.lbl_prev.Size = new System.Drawing.Size(405, 307);
            this.lbl_prev.TabIndex = 18;
            this.lbl_prev.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 797);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.folderInfo);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.level0.ResumeLayout(false);
            this.levelNaN.ResumeLayout(false);
            this.level2.ResumeLayout(false);
            this.folderInfo.ResumeLayout(false);
            this.folderInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connettiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnettiToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList icList;
        private System.Windows.Forms.ContextMenuStrip level0;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem svuotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem convalidaCartellaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versioneToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip levelNaN;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem aggiornamentoToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip level2;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem1;
        private System.Windows.Forms.Panel folderInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_dir_dim;
        private System.Windows.Forms.Label lbl_dir_type;
        private System.Windows.Forms.Label lbl_dir_folders;
        private System.Windows.Forms.Label lbl_dir_files;
        private System.Windows.Forms.Label lbl_dir_elms;
        private System.Windows.Forms.Label lbl_dir_url;
        private System.Windows.Forms.Label lbl_dir_nm;
        private System.Windows.Forms.Label lbl_dir_lastMod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_tit_prev;
        private System.Windows.Forms.Label lbl_prev;
    }
}

