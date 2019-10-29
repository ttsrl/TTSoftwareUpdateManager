using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Text;

namespace TTSoftwareUpdateManager
{
    public partial class Form1 : Form
    {
        //FtpClient session = null;
        List<string> ListSFTWOpened = new List<string>();
        FileIcon FileIcon = new FileIcon();
        UpdateManagerFunctions Manager;
        Dictionary<string, ProgramObjectInfo> objectsInfo;

        public Form1()
        {
            InitializeComponent();
            objectsInfo = new Dictionary<string, ProgramObjectInfo>();
        }

        #region  MENU

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new settings();
            frm.ShowDialog();
        }

        private async void ConnettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setWorking(false);
            try
            {
                Manager = new UpdateManagerFunctions();
                Manager.Connect();
                disconnettiToolStripMenuItem.Enabled = true;
                connettiToolStripMenuItem.Enabled = false;
                nuovoToolStripMenuItem1.Enabled = true;
                await paintTreeView();
            }
            catch 
            {
                disconnettiToolStripMenuItem.Enabled = false;
                connettiToolStripMenuItem.Enabled = true;
                treeView1.Nodes.Clear();
                nuovoToolStripMenuItem1.Enabled = false;
                MessageBox.Show("Errore, impossibile connettersi!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setWorking(true);
        }

        private void DisconnettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setWorking(false);
            try
            {
                Manager.Disconnect();
                disconnettiToolStripMenuItem.Enabled = false;
                connettiToolStripMenuItem.Enabled = true;
                treeView1.Nodes.Clear();
                nuovoToolStripMenuItem1.Enabled = false;
            }
            catch { }
            setWorking(true);
        }

        private void NuovoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NuovoToolStripMenuItem_Click(sender, new EventArgs());
        }

        #endregion

        #region TREEVIEW

        private async Task<bool> paintTreeView()
        {
            try
            {
                //Manager.Session.SetWorkingDirectory(Manager.urlBase);
                var nodes = new List<TreeNode>();
                var dirs = await Manager.Session.GetListingAsync();
                foreach (var dir in dirs)
                {
                    if (dir.Type == FtpFileSystemObjectType.Directory)
                    {
                        TreeNode node = null;
                        var subFiles = await Manager.Session.GetListingAsync(dir.Name);
                        var validateFolder = validateSoftwareFolder(subFiles);
                        if (validateFolder)
                        {
                            var subnodes = new List<TreeNode>();
                            var sftwNode = new TreeNode("files", 0, 0);
                            if (ListSFTWOpened.Contains(dir.Name))
                            {
                                var subsubnodes = await loadSubDirectorySFTW(dir.Name + "/sftw");
                                sftwNode.Nodes.AddRange(subsubnodes.ToArray());
                            }
                            subnodes.Add(sftwNode);
                            subnodes.Add(new TreeNode("Versione", 3, 3));
                            subnodes.Add(new TreeNode("Lista", 4, 4));
                            node = new TreeNode(dir.Name, subnodes.ToArray());
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                        }
                        else
                        {
                            node = new TreeNode(dir.Name);
                            node.ImageIndex = 2;
                            node.SelectedImageIndex = 2;
                        }
                        nodes.Add(node);
                    }
                }
                treeView1.Nodes.Clear();
                treeView1.BeginUpdate();
                treeView1.Nodes.AddRange(nodes.ToArray());
                treeView1.EndUpdate();
                return true;
            }
            catch
            {
                MessageBox.Show("Errore durante il caricamento della directory ftp.\r\nCartella selezionata inesistente o permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void TreeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            node.SelectedImageIndex = 0;
            node.ImageIndex = 0;
        }

        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            node.SelectedImageIndex = 1;
            node.ImageIndex = 1;
        }

        private void TreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = treeView1.HitTest(e.Location);
                if (hitTest.Node == null)
                {
                    treeView1.ContextMenuStrip = levelNaN;
                }
                else
                {
                    treeView1.SelectedNode = hitTest.Node;
                    treeView1.ContextMenuStrip = null;
                    if (hitTest.Node.Level == 0)
                    {
                        hitTest.Node.ContextMenuStrip = level0;
                    }
                    else if (hitTest.Node.Level >= 2)
                    {
                        hitTest.Node.ContextMenuStrip = level2;
                    }
                    else
                    {
                        hitTest.Node.ContextMenuStrip = null;
                    }
                }
            }
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node != null)
            {
                string pth = "";
                TreeNode lastNode = node;
                for(var i = node.Level; i >= 0; i--)
                {
                    var nm = lastNode.Text;
                    if(i == 1)
                    {
                        if (nm == "files")
                            nm = "sftw";
                        if (nm == "Versione")
                            nm = "version.txt";
                        if (nm == "Lista")
                            nm = "fileslist.txt";
                    }
                    pth = nm + "/" + pth;
                    lastNode = lastNode.Parent;
                }
                pth = pth.Substring(0, pth.Length - 1);

                ProgramObjectInfo objInfo = null;
                if (objectsInfo.ContainsKey(pth))
                    objInfo = objectsInfo[pth];
                else
                {
                    setWorking(false);
                    objInfo = await Manager.GetObjectInfo(pth);
                    objectsInfo.Add(pth, objInfo);
                }

                if (objInfo.Extension == ".txt")
                {
                    lbl_tit_prev.Visible = true;
                    lbl_prev.Visible = true;
                    lbl_prev.Text = objInfo.Text;
                }
                else
                {
                    lbl_tit_prev.Visible = false;
                    lbl_prev.Visible = false;
                }
                folderInfo.Visible = true;
                lbl_dir_nm.Text = objInfo.Name;
                lbl_dir_type.Text = Enum.GetName(typeof(FtpFileSystemObjectType), objInfo.Type);
                lbl_dir_url.Text = objInfo.FullPath;
                lbl_dir_elms.Text = objInfo.Content.ToString();
                lbl_dir_files.Text = objInfo.ContentFiles.ToString();
                lbl_dir_folders.Text = objInfo.ContentFolder.ToString();
                lbl_dir_dim.Text = objInfo.LenghtSuffix + " (" + objInfo.Lenght + " byte)";
                lbl_dir_lastMod.Text = objInfo.LastModifiedTime.ToString("dd/MM/yyyy HH:mm");
                setWorking(true);
            }
            else
                folderInfo.Visible = false;
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node != null )
            {
                if (node.Text == "files")
                {
                    if (!ListSFTWOpened.Contains(node.Parent.Text))
                    {
                        LoadSFTWFolder(node.Parent);
                    }
                }
                else if (node.Text == "Versione")
                {
                    VersionChange(node.Parent);
                }
            }
        }

        private async void LoadSFTWFolder(TreeNode softwareNode)
        {
            var sftwNode = softwareNode.Nodes[0];
            setWorking(false);
            var nodes = await loadSubDirectorySFTW(softwareNode.Text + "/sftw");
            sftwNode.Nodes.Clear();
            treeView1.BeginUpdate();
            sftwNode.Nodes.AddRange(nodes.ToArray());
            treeView1.EndUpdate();
            ListSFTWOpened.Add(softwareNode.Text);
            setWorking(true);
            sftwNode.Expand();
        }

        #endregion

        #region CONTEXT_LVL_NAN

        private async void NuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setWorking(false);
            try
            {
                var input = new inputText();
                input.TitleProp = "Nome:";
                input.Value = "NuovoSoftware";
                if (input.ShowDialog() == DialogResult.OK)
                {
                    if(await Manager.ExistRemoteProgramUpdatesStructure(input.Value))
                    {
                        MessageBox.Show("Nome già usato per un'altro oggetto!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    if(!await Manager.CreateNewProgramUpdatesStructure(input.Value))
                    {
                        MessageBox.Show("Errore durante la creazione dei file remoti di versione o di lista!\r\nSi prega di ripetere l'azione e di controllare eventuali permessi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    await paintTreeView();
                }
            }
            catch { MessageBox.Show("Errore generico durante la creazione del nuovo elemento.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            setWorking(true);
        }

        private async void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setWorking(false);
            await paintTreeView();
            objectsInfo.Clear();
            setWorking(true);
        }

        #endregion

        #region CONTEXT_LVL_0

        private void ApriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                node.Expand();
            }
        }

        private async void AggiornamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                setWorking(false);
                Version newVersion;
                try
                {
                    if (await Manager.DownloadVersionFile(node.Text))
                    {
                        var v = await Manager.ReadLocalVersionFile();
                        var input = new inputVersion();
                        input.Version = v;
                        if (input.ShowDialog() == DialogResult.OK)
                        {
                            newVersion = input.Version;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Errore durante la definizione della versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                }
                catch { MessageBox.Show("Errore durante la definizione della versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                //load directory
                var dir = "";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    dir = folderBrowserDialog1.SelectedPath;
                else
                {
                    setWorking(true);
                    return;
                }

                //empty sftw directory
                var empty = false;
                var resQ = MessageBox.Show("Si Desidera svuotare la cartella di destinazione prima di procedere all'upload?\r\n[SI] : Svuota cartella - [No] : Sovrascrivi files.", "Come si desidera proseguire?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resQ == DialogResult.Yes)
                {
                    empty = true;
                    if (!await Manager.EmptyFolder(node.Text + "/sftw"))
                    {
                        MessageBox.Show("Errore durante il processo di svuotamento della cartella remota. Controllare le credenziali e i privilegi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                }
                else if (resQ == DialogResult.Cancel)
                {
                    setWorking(true);
                    return;
                }

                //write fileslist
                var dirs = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                List<string> remDirs = new List<string>();
                try
                {
                    string fl = "";
                    foreach (var f in dirs)
                    {
                        string partialP = f.Replace(dir + "\\", "");
                        var nm = "sftw/" + partialP.Replace("\\", "/");
                        fl += nm + "\r\n";
                        remDirs.Add(nm);
                    }
                    if (empty)
                        Manager.CreateLocalFilesListFile(fl);
                    else
                    {
                        await Manager.DownloadFilesListFile(node.Text);
                        Manager.AppendLocalFilesListFile(fl);
                    }
                }
                catch
                {
                    MessageBox.Show("Errore durante la compilazione del fileslist.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWorking(true);
                    return;
                }

                //uploads files
                try
                {
                    var index = 0;
                    foreach(var rf in remDirs)
                    {
                        await Manager.Session.UploadFileAsync(dirs[index], node.Text + "/" + rf, FtpExists.Overwrite, true);
                        index++;
                    }
                }
                catch
                {
                    MessageBox.Show("Errore durante il processo di upload di alcuni files. Controllare le credenziali, i privilegi e ritentare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWorking(true);
                    return;
                }

                //upload version and fileslist
                try
                {
                    var r1 = await Manager.UploadFilesListFile(node.Text);
                    var r2 = await Manager.UploadVersionFile(node.Text);
                    if(!r1 || !r2)
                    {
                        MessageBox.Show("Errore durante il processo di upload di file versione e fileslist. Controllare le credenziali, i privilegi e ritentare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Errore durante il processo di upload di file versione e fileslist. Controllare le credenziali, i privilegi e ritentare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWorking(true);
                    return;
                }

                //load treenode files
                node.Expand();
                foreach (var it in objectsInfo)
                {
                    if (it.Key.Contains(node.Text))
                        objectsInfo.Remove(it.Key);
                }
                LoadSFTWFolder(node);
                setWorking(true);
            }
        }

        private async void NomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                var input = new inputText();
                input.TitleProp = "Nome:";
                input.Value = node.Text;
                if (input.ShowDialog() == DialogResult.OK)
                {
                    //rename
                    if (input.Value != node.Text)
                    {
                        setWorking(false);
                        try
                        {
                            if (await Manager.ExistRemoteProgramUpdatesStructure(input.Value))
                            {
                                MessageBox.Show("Nome già usato per un'altro oggetto!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                setWorking(true);
                                return;
                            }
                            if (!await Manager.RenameRemoteProgramUpdatesStructure(node.Text, input.Value))
                            {
                                MessageBox.Show("Errore durante la rinomina della cartella", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                setWorking(true);
                                return;
                            }
                            node.Text = input.Value;
                        }
                        catch
                        {
                            MessageBox.Show("Errore generico durante la procedura di rinomina", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        objectsInfo.Remove(node.Text);
                        setWorking(true);
                    }
                }
            }
        }

        private async void VersionChange(TreeNode node)
        {
            if (node is TreeNode)
            {
                setWorking(false);
                try
                {
                    if (!await Manager.DownloadVersionFile(node.Text))
                    {
                        MessageBox.Show("Errore durante il download del file di versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    var read = await Manager.ReadLocalVersionFile();
                    if (read == null)
                    {
                        MessageBox.Show("Errore durante il download del file di versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    var input = new inputVersion();
                    input.Version = read;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        if (!Manager.CreateLocalVersionFile(input.Version))
                        {
                            MessageBox.Show("Errore durante la creazione del nuovo file di versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            setWorking(true);
                            return;
                        }
                        if (!await Manager.UploadVersionFile(node.Text))
                        {
                            MessageBox.Show("Errore durante l'upload del file di versione", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            setWorking(true);
                            return;
                        }
                    }
                }
                catch { MessageBox.Show("Errore generico durante la procedura di cambio versione.\r\nIl file potrebbe essere inesistente o avere i permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                setWorking(true);
                objectsInfo.Remove(node.Text + "/version.txt");
            }
        }

        private void VersioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            VersionChange(node);
        }

        private async void SvuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler svuotare la cartella?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                setWorking(false);
                try
                {
                    if (!await Manager.EmptyProgramUpdatesStructure(node.Text))
                    {
                        MessageBox.Show("Errore durante la cancellazione di uno o più file.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante lo svuotamento della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                foreach (var it in objectsInfo)
                {
                    if (it.Key.Contains(node.Text))
                        objectsInfo.Remove(it.Key);
                }
                setWorking(true);
            }
        }

        private async void RimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler rimuovere l'intera cartella?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                setWorking(false);
                try
                {
                    if (!await Manager.RemoveFolder(node.Text))
                    {
                        MessageBox.Show("Errore durante la rimozione della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante la rimozione della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                foreach (var it in objectsInfo)
                {
                    if (it.Key.Contains(node.Text))
                        objectsInfo.Remove(it.Key);
                }
                setWorking(true);
            }
        }

        private async void ConvalidaCartellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                setWorking(false);
                try
                {
                    var v = await Manager.RemoteContainVersionFile(node.Text);
                    var l = await Manager.RemoteContainFilesListFile(node.Text);
                    var f = await Manager.RemoteContainSFTWFolder(node.Text);
                    if (v || l || f)
                    {
                        if (MessageBox.Show("Questa cartella contiene già alcuni file di una precedente convalida.\r\nSe si procede verrà svuotato il contenuto corrente.\r\nSi desidera procedere?", "Convalida precedente rilevata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if(!await Manager.RemoveFolder(node.Text))
                            {
                                MessageBox.Show("Errore durante la cancellazione della directory ftp.\r\n I Permessi di accesso potrebbero essere negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                setWorking(true);
                                return;
                            }
                        }
                        else
                        {
                            setWorking(true);
                            return;
                        }
                    }
                    if (!await Manager.CreateNewProgramUpdatesStructure(node.Text))
                    {
                        MessageBox.Show("Errore durante la creazione dei file remoti!\r\nSi prega di ripetere l'azione e di controllare eventuali permessi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setWorking(true);
                        return;
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante la procedura di convalida.\r\nLa Cartella selezionata potrebbe essere inesistente o avere i permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                foreach (var it in objectsInfo)
                {
                    if (it.Key.Contains(node.Text))
                        objectsInfo.Remove(it.Key);
                }
                setWorking(true);
            }
        }

        #endregion

        //DA FARE COMPLETAMENTE
        #region CONTEXT_LVL_2

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RimuoviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                var path = node.FullPath.Replace("\\", "/").Replace("files", "sftw");


            }
        }

        #endregion

        private bool validateSoftwareFolder(FtpListItem[] directory)
        {
            if (directory.Length < 3)
                return false;
            var version = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "version.txt").Count();
            var list = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "fileslist.txt").Count();
            var sftw = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.Directory && f.Name == "sftw").Count();
            return (version > 0 && list > 0 && sftw > 0) ? true : false;
        }

        private async Task<List<TreeNode>> loadSubDirectorySFTW(string path)
        {
            var list = await Manager.Session.GetListingAsync(path);
            var nodes = new List<TreeNode>();
            foreach (var elm in list)
            {
                var newNode = new TreeNode(elm.Name);
                if (elm.Type == FtpFileSystemObjectType.Directory)
                {
                    var subdirnodes = await loadSubDirectorySFTW(path + "/" + elm.Name);
                    newNode.ImageIndex = 0;
                    newNode.Nodes.AddRange(subdirnodes.ToArray());
                }
                else
                {
                    newNode.ImageIndex = FileIcon.GetIcon(elm, icList);
                    newNode.SelectedImageIndex = FileIcon.GetIcon(elm, icList);
                }
                nodes.Add(newNode);
            }
            return nodes;
        }

        private void setWorking(bool status)
        {
            treeView1.Enabled = status;
            progressBar1.Visible = !status;
            fileToolStripMenuItem.Enabled = status;
            modificaToolStripMenuItem.Enabled = status;
        }

    }
}
