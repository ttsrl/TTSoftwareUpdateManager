using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTSoftwareUpdateManager.Properties;
using FluentFTP;

namespace TTSoftwareUpdateManager
{
    public partial class Form1 : Form
    {
        FtpClient session = null;
        List<string> ListSFTWOpened = new List<string>();
        FileIcon FileIcon = new FileIcon();

        public Form1()
        {
            InitializeComponent();
        }

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new settings();
            frm.ShowDialog();
        }

        private async void ConnettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleWorking();
            var fixHost = Settings.Default.ftp_host.ToLower().Replace("ftp://", "").Replace("ftp.", "").Replace("/", "");
            var fixFolder = Settings.Default.ftp_folder.Replace("/", "");
            try
            {
                var port = 21;
                int.TryParse(Settings.Default.ftp_port, out port);
                session = new FtpClient(Settings.Default.ftp_host, port, Settings.Default.ftp_username, Settings.Default.ftp_password);
                session.ConnectTimeout = 1200000;
                session.Connect();
                session.SetWorkingDirectory(fixHost + "/" + fixFolder);
                changeFtpConnectionStatus();
                await paintTreeView();
            }
            catch { MessageBox.Show("Errore, impossibile connettersi!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            toggleWorking();
        }

        private void DisconnettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleWorking();
            try
            {
                session.Disconnect();
            }
            catch { }
            changeFtpConnectionStatus();
            toggleWorking();
        }

        private void changeFtpConnectionStatus()
        {
            if (session.IsConnected)
            {
                disconnettiToolStripMenuItem.Enabled = true;
                connettiToolStripMenuItem.Enabled = false;
                nuovoToolStripMenuItem1.Enabled = true;
            }
            else
            {
                disconnettiToolStripMenuItem.Enabled = false;
                connettiToolStripMenuItem.Enabled = true;
                treeView1.Nodes.Clear();
                nuovoToolStripMenuItem1.Enabled = false;
            }
        }

        private async Task<bool> paintTreeView()
        {
            try
            {
                var nodes = new List<TreeNode>();
                var dirs = await session.GetListingAsync();
                foreach (var dir in dirs)
                {
                    if (dir.Type == FtpFileSystemObjectType.Directory)
                    {
                        TreeNode node = null;
                        var subFiles = await session.GetListingAsync(dir.Name);
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
                session.Disconnect();
                changeFtpConnectionStatus();
                MessageBox.Show("Errore durante il caricamento della directory ftp.\r\nCartella selezionata inesistente o permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool validateSoftwareFolder(FtpListItem[] directory)
        {
            if (directory.Length < 3)
                return false;
            var version = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "version.txt").Count();
            var list = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "fileslist.txt").Count();
            var sftw = directory.ToList().Where(f => f.Type == FtpFileSystemObjectType.Directory && f.Name == "sftw").Count();
            return (version > 0 && list > 0 && sftw > 0) ? true : false;
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
                    }else if (hitTest.Node.Level >= 2)
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

        private async void ConvalidaCartellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                toggleWorking();
                try
                {
                    var dirs = session.GetListing(node.Text);
                    var version = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "version.txt").Count();
                    var list = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "filelist.txt").Count();
                    var sftw = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.Directory && f.Name == "sftw").Count();
                    if (version > 0 || list > 0 || sftw > 0)
                    {
                        if (MessageBox.Show("Questa cartella contiene già alcuni file di una precedente convalida.\r\nSe si procede verrà svuotato il contenuto corrente.\r\nSi desidera procedere?", "Convalida precedente rilevata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            await session.DeleteDirectoryAsync(node.Text);
                            if (await session.DirectoryExistsAsync(node.Text))
                            {
                                MessageBox.Show("Errore durante la cancellazione della directory ftp.\r\n I Permessi di accesso potrebbero essere negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    var res = await createRemoteObj(node.Text);
                    if (!res)
                    {
                        MessageBox.Show("Errore durante la creazione dei file remoti di versione o di lista!\r\nSi prega di ripetere l'azione e di controllare eventuali permessi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante la procedura di convalida.\r\nLa Cartella selezionata potrebbe essere inesistente o avere i permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                toggleWorking();
            }
        }

        private async void NomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                toggleWorking();
                var input = new inputText();
                input.TitleProp = "Nome:";
                input.Value = node.Text;
                if (input.ShowDialog() == DialogResult.OK)
                {
                    //rename
                    if (input.Value != node.Text)
                    {
                        try
                        {
                            if (await session.DirectoryExistsAsync(input.Value))
                            {
                                MessageBox.Show("Nome già usato per un'altro oggetto!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var r = await session.MoveDirectoryAsync(node.Text, input.Value, FtpExists.Skip);
                            if (!r)
                            {
                                MessageBox.Show("Errore durante la rinomina della cartella", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            node.Text = input.Value;
                        }
                        catch
                        {
                            MessageBox.Show("Errore generico durante la procedura di rinomina", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                toggleWorking();
            }
        }

        private async Task<bool> createRemoteObj(string fullPath)
        {
            try
            {
                if (!await session.DirectoryExistsAsync(fullPath))
                    session.CreateDirectory(fullPath);
                if (!await session.DirectoryExistsAsync(fullPath + "/sftw"))
                    session.CreateDirectory(fullPath + "/sftw");

                //file temporanei
                StreamWriter tw = null;
                if (!Directory.Exists("tmp_"))
                    Directory.CreateDirectory("tmp_");

                if (File.Exists("tmp_\\version.txt"))
                    File.Delete("tmp_\\version.txt");

                tw = new StreamWriter("tmp_\\version.txt", false);
                tw.Write("1.0");
                tw.Close();

                if (File.Exists("tmp_\\fileslist.txt"))
                    File.Delete("tmp_\\fileslist.txt");

                tw = new StreamWriter("tmp_\\fileslist.txt", false);
                tw.Write("");
                tw.Close();

                var upV = await session.UploadFileAsync("tmp_\\version.txt", fullPath + "/version.txt");
                var upL = await session.UploadFileAsync("tmp_\\fileslist.txt", fullPath + "/fileslist.txt");
                if (upV && upL)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        private async void VersioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                toggleWorking();
                try
                {
                    var down = await session.DownloadFileAsync("tmp_\\version.txt", node.Text + "/version.txt", FtpLocalExists.Overwrite);
                    if (down)
                    {
                        StreamReader sr = new StreamReader("tmp_\\version.txt");
                        var vers = await sr.ReadToEndAsync();
                        sr.Close();
                        var input = new inputText();
                        input.TitleProp = "Versione:";
                        input.Value = vers;
                        if (input.ShowDialog() == DialogResult.OK)
                        {
                            if (input.Value != vers)
                            {
                                StreamWriter tw = new StreamWriter("tmp_\\version.txt", false);
                                tw.Write(input.Value);
                                tw.Close();
                                var upload = await session.UploadFileAsync("tmp_\\version.txt", node.Text + "/version.txt", FtpExists.Overwrite);
                                if (!upload)
                                {
                                    MessageBox.Show("Errore durante l'upload del file di versione", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Errore durante il download del file di versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Errore generico durante la procedura di cambio versione.\r\nIl file potrebbe essere inesistente o avere i permessi di accesso negati.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toggleWorking();
            }
        }

        private async void RimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler rimuovere l'intera cartella?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                toggleWorking();
                try
                {
                    if (await session.DirectoryExistsAsync(node.Text))
                    {
                        await session.DeleteDirectoryAsync(node.Text);
                        if (await session.DirectoryExistsAsync(node.Text))
                        {
                            MessageBox.Show("Errore durante la rimozione della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante la rimozione della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                toggleWorking();
            }
        }

        private async void SvuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler svuotare la cartella?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                toggleWorking();
                try
                {
                    if (await session.DirectoryExistsAsync(node.Text + "/sftw"))
                        await session.DeleteDirectoryAsync(node.Text + "/sftw");
                    if (await session.FileExistsAsync(node.Text + "/version.txt"))
                        await session.DeleteFileAsync(node.Text + "/version.txt");
                    if (await session.FileExistsAsync(node.Text + "/fileslist.txt"))
                        await session.DeleteFileAsync(node.Text + "/fileslist.txt");
                    if (await session.DirectoryExistsAsync(node.Text + "/sftw") || await session.FileExistsAsync(node.Text + "/version.txt") || await session.FileExistsAsync(node.Text + "/fileslist.txt"))
                    {
                        MessageBox.Show("Errore durante la cancellazione di uno o più file.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    await paintTreeView();
                }
                catch { MessageBox.Show("Errore generico durante lo svuotamento della cartella remota.\r\nControllare i permessi delle cartelle o dei file contenuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                toggleWorking();
            }
        }

        private void ApriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                node.Expand();
            }
        }

        private async void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleWorking();
            await paintTreeView();
            toggleWorking();
        }

        private async void NuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleWorking();
            try
            {
                var input = new inputText();
                input.TitleProp = "Nome:";
                input.Value = "NuovoSoftware";
                if (input.ShowDialog() == DialogResult.OK)
                {
                    if (await session.FileExistsAsync(input.Value))
                    {
                        MessageBox.Show("Nome già usato per un'altro oggetto!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var res = await createRemoteObj(input.Value);
                    if (!res)
                    {
                        MessageBox.Show("Errore durante la creazione dei file remoti di versione o di lista!\r\nSi prega di ripetere l'azione e di controllare eventuali permessi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   await paintTreeView();
                }
            }
            catch { MessageBox.Show("Errore generico durante la creazione del nuovo elemento.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            toggleWorking();
        }

        private void NuovoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NuovoToolStripMenuItem_Click(sender, new EventArgs());
        }

        private async void AggiornamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var node = treeView1.SelectedNode ?? null;
            //if (node is TreeNode)
            //{
            //    var fixHost = Settings.Default.ftp_host.ToLower().Replace("ftp://", "").Replace("ftp.", "").Replace("/", "");
            //    var fixFolder = Settings.Default.ftp_folder.Replace("/", "");
            //    var newVersion = "";
            //    try
            //    {
            //        var downloadres = session.GetFiles(fixHost + "/" + fixFolder + "/" + node.Text + "/version.txt", "tmp_\\version.txt", false, new TransferOptions { OverwriteMode = OverwriteMode.Overwrite, FilePermissions = new FilePermissions(777) });
            //        if (downloadres.IsSuccess)
            //        {
            //            StreamReader sr = new StreamReader("tmp_\\version.txt");
            //            var vers = await sr.ReadToEndAsync();
            //            sr.Close();
            //            var input = new inputText();
            //            input.TitleProp = "Nuova Versione:";
            //            input.Value = vers;
            //            if(input.ShowDialog() == DialogResult.OK)
            //            {
            //                newVersion = input.Value;
            //            }
            //            else { return; }
            //        }
            //        else { return; }
            //    }
            //    catch { MessageBox.Show("Errore durante la difinizione della versione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //    try
            //    {
            //        var dir = "";
            //        if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //        {
            //            dir = folderBrowserDialog1.SelectedPath;
            //        }
            //        else { return; }

            //        if(MessageBox.Show("Si Desidera svuotare la cartella di destinazione prima di procedere all'upload?\r\n[SI] : Cartella svuotata - [No] : File uguali sovrascritti.", "Come si desidera proseguire?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            var retRem = session.RemoveFiles(fixHost + "/" + fixFolder + "/" + node.Text + "/sftw");
            //            if (!retRem.IsSuccess)
            //            {
            //                MessageBox.Show("Errore durante il processo di svuotamento della cartella remota. Controllare le credenziali e i privilegi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
            //            session.CreateDirectory(fixHost + "/" + fixFolder + "/" + node.Text + "/sftw");
            //        }
                    
            //        var resput = session.PutFiles(dir, fixHost + "/" + fixFolder + "/" + node.Text + "/sftw",false, new TransferOptions { OverwriteMode = OverwriteMode.Overwrite, FilePermissions = new FilePermissions(777) } );
            //        if (resput.IsSuccess)
            //        {
            //            MessageBox.Show("Aggiornamento inviato correttamente!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch { MessageBox.Show("Errore durante l'upload dei nuovi file del programma.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //}
        }

        private async Task<List<TreeNode>> loadSubDirectorySFTW(string path)
        {
            var list = await session.GetListingAsync(path);
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

        private void toggleWorking()
        {
            treeView1.Enabled = !treeView1.Enabled;
            progressBar1.Visible = !progressBar1.Visible;
            fileToolStripMenuItem.Enabled = !fileToolStripMenuItem.Enabled;
            modificaToolStripMenuItem.Enabled = !modificaToolStripMenuItem.Enabled;
        }

        private async void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if(node != null && node.Text == "files")
            {
                if (!ListSFTWOpened.Contains(node.Parent.Text))
                {
                    toggleWorking();
                    var nodes = await loadSubDirectorySFTW(node.Parent.Text + "/sftw");
                    node.Nodes.Clear();
                    treeView1.BeginUpdate();
                    node.Nodes.AddRange(nodes.ToArray());
                    treeView1.EndUpdate();
                    ListSFTWOpened.Add(node.Parent.Text);
                    toggleWorking();
                }
            }
        }

        private void RimuoviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode ?? null;
            if (node is TreeNode)
            {
                var path = node.FullPath.Replace("\\", "/").Replace("files", "sftw");
                
                
            }
        }
    }
}
