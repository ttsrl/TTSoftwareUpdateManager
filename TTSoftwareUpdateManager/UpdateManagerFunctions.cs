using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSoftwareUpdateManager.Properties;

namespace TTSoftwareUpdateManager
{
    class UpdateManagerFunctions
    {
        FtpClient session = null;
        string urlBase = "";
        int port = 21;
        public FtpClient Session { get => session; }

        public UpdateManagerFunctions()
        {
            var fixHost = Settings.Default.ftp_host.ToLower().Replace("ftp://", "").Replace("ftp.", "").Replace("/", "");
            var fixFolder = Settings.Default.ftp_folder.Replace("/", "");
            urlBase = fixHost + "/" + fixFolder;
            int.TryParse(Settings.Default.ftp_port, out port);
        }

        public void Connect()
        {
            try
            {
                session = new FtpClient(Settings.Default.ftp_host, port, Settings.Default.ftp_username, Settings.Default.ftp_password);
                session.ConnectTimeout = 1200000;
                session.Connect();
                session.SetWorkingDirectory(urlBase);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Disconnect()
        {
            try
            {
                session.Disconnect();
            }
            catch { }
        }

        public bool CreateLocalVersionFile(Version version)
        {
            if (version == null)
                return false;
            if (!Directory.Exists("tmp_"))
                Directory.CreateDirectory("tmp_");
            if (File.Exists("tmp_\\version.txt"))
                File.Delete("tmp_\\version.txt");
            var tw = new StreamWriter("tmp_\\version.txt", false);
            tw.Write(version.ToString());
            tw.Close();
            tw.Dispose();
            return File.Exists("tmp_\\version.txt");
        }

        public bool CreateLocalFilesListFile(string list)
        {
            if (list == null)
                return false;
            if (!Directory.Exists("tmp_"))
                Directory.CreateDirectory("tmp_");
            if (File.Exists("tmp_\\fileslist.txt"))
                File.Delete("tmp_\\fileslist.txt");
            var tw = new StreamWriter("tmp_\\fileslist.txt", false);
            tw.Write(list);
            tw.Close();
            tw.Dispose();
            return File.Exists("tmp_\\fileslist.txt");
        }

        public bool AppendLocalFilesListFile(string list)
        {
            if (list == null)
                return false;
            var tw = new StreamWriter("tmp_\\fileslist.txt", true);
            tw.Write(list);
            tw.Close();
            tw.Dispose();
            return File.Exists("tmp_\\fileslist.txt");
        }

        #region PROGRAM_BASE_STRUCTURE

        public async Task<bool> ExistRemoteProgramUpdatesStructure(string programName)
        {
            return await session.FileExistsAsync(programName);
        }

        public async Task<bool> RenameRemoteProgramUpdatesStructure(string programName, string newName)
        {
            return await session.MoveDirectoryAsync(programName, newName, FtpExists.Overwrite);
        }

        public async Task<bool> CreateNewProgramUpdatesStructure(string programName)
        {
            if (await session.FileExistsAsync(programName))
                return false;
            if (!await session.DirectoryExistsAsync(programName))
                await session.CreateDirectoryAsync(programName);
            if (!await session.DirectoryExistsAsync(programName + "/sftw"))
                await session.CreateDirectoryAsync(programName + "/sftw");
            if (!await session.DirectoryExistsAsync(programName) || !await session.DirectoryExistsAsync(programName + "/sftw"))
                return false;
            var r2 = CreateLocalVersionFile(new Version(1, 0, 0, 0));
            var r3 = CreateLocalFilesListFile("");
            if (!r2 || !r3)
                return false;
            var upV = await session.UploadFileAsync("tmp_\\version.txt", programName + "/version.txt");
            var upL = await session.UploadFileAsync("tmp_\\fileslist.txt", programName + "/fileslist.txt");
            if (!upV || !upL)
                return false;
            return true;
        }

        public async Task<bool> EmptyProgramUpdatesStructure(string programName)
        {
            if (!await session.FileExistsAsync(programName))
                return false;
            if (await session.DirectoryExistsAsync(programName + "/sftw"))
                await session.DeleteDirectoryAsync(programName + "/sftw");
            if (await session.FileExistsAsync(programName + "/version.txt"))
                await session.DeleteFileAsync(programName + "/version.txt");
            if (await session.FileExistsAsync(programName + "/fileslist.txt"))
                await session.DeleteFileAsync(programName + "/fileslist.txt");
            if (!await session.DirectoryExistsAsync(programName + "/sftw") && !await session.FileExistsAsync(programName + "/version.txt") && !await session.FileExistsAsync(programName + "/fileslist.txt"))
                return true;
            else
                return false;
        }

        public async Task<bool> RemoveFolder(string programName)
        {
            if (!await session.FileExistsAsync(programName))
                return false;
            if (await session.DirectoryExistsAsync(programName))
                await session.DeleteDirectoryAsync(programName);
            if (await session.DirectoryExistsAsync(programName))
                return false;
            else
                return true;
        }

        #endregion

        public async Task<bool> DownloadVersionFile(string programName)
        {
            if (string.IsNullOrEmpty(programName))
                return false;
            if (!Directory.Exists("tmp_"))
                Directory.CreateDirectory("tmp_");
            if (File.Exists("tmp_\\version.txt"))
                File.Delete("tmp_\\version.txt");
            return await session.DownloadFileAsync("tmp_\\version.txt", programName + "/version.txt", FtpLocalExists.Overwrite);
        }

        public async Task<bool> DownloadFilesListFile(string programName)
        {
            if (string.IsNullOrEmpty(programName))
                return false;
            if (!Directory.Exists("tmp_"))
                Directory.CreateDirectory("tmp_");
            if (File.Exists("tmp_\\fileslist.txt"))
                File.Delete("tmp_\\fileslist.txt");
            return await session.DownloadFileAsync("tmp_\\fileslist.txt", programName + "/fileslist.txt", FtpLocalExists.Overwrite);
        }

        public async Task<bool> UploadVersionFile(string programName)
        {
            if (string.IsNullOrEmpty(programName))
                return false;
            if (!File.Exists("tmp_\\version.txt"))
                return false;
            return await session.UploadFileAsync("tmp_\\version.txt", programName + "/version.txt", FtpExists.Overwrite);
        }

        public async Task<bool> UploadFilesListFile(string programName)
        {
            if (string.IsNullOrEmpty(programName))
                return false;
            if (!File.Exists("tmp_\\fileslist.txt"))
                return false;
            return await session.UploadFileAsync("tmp_\\fileslist.txt", programName + "/fileslist.txt", FtpExists.Overwrite);
        }

        public async Task<bool> RemoteContainVersionFile(string programName)
        {
            var dirs = await session.GetListingAsync(programName);
            var version = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "version.txt").Count();
            return (version > 0);
        }

        public async Task<bool> RemoteContainFilesListFile(string programName)
        {
            var dirs = await session.GetListingAsync(programName);
            var fl = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.File && f.Name == "fileslist.txt").Count();
            return (fl > 0);
        }

        public async Task<bool> RemoteContainSFTWFolder(string programName)
        {
            var dirs = await session.GetListingAsync(programName);
            var sftw = dirs.ToList().Where(f => f.Type == FtpFileSystemObjectType.Directory && f.Name == "sftw").Count();
            return (sftw > 0);
        }

        public async Task<Version> ReadLocalVersionFile()
        {
            if (!File.Exists("tmp_\\version.txt"))
                return null;
            StreamReader sr = new StreamReader("tmp_\\version.txt");
            var vers = await sr.ReadToEndAsync();
            sr.Close();
            sr.Dispose();
            Version out_ = null;
            Version.TryParse(vers, out out_);
            return out_;
        }

        public async Task<string> ReadLocalFilesListFile()
        {
            if (!File.Exists("tmp_\\fileslist.txt"))
                return null;
            StreamReader sr = new StreamReader("tmp_\\fileslist.txt");
            var fl = await sr.ReadToEndAsync();
            sr.Close();
            sr.Dispose();
            return fl;
        }
    }
}
