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
            this.menuStrip1.SuspendLayout();
            this.level0.SuspendLayout();
            this.levelNaN.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
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
            this.connettiToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.connettiToolStripMenuItem.Text = "Connetti";
            this.connettiToolStripMenuItem.Click += new System.EventHandler(this.ConnettiToolStripMenuItem_Click);
            // 
            // disconnettiToolStripMenuItem
            // 
            this.disconnettiToolStripMenuItem.Enabled = false;
            this.disconnettiToolStripMenuItem.Name = "disconnettiToolStripMenuItem";
            this.disconnettiToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
            this.treeView1.Enabled = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icList;
            this.treeView1.Location = new System.Drawing.Point(9, 32);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(290, 436);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 478);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.level0.ResumeLayout(false);
            this.levelNaN.ResumeLayout(false);
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
    }
}

