using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTSoftwareUpdateManager
{
    class FileIcon
    {
        public int GetIcon(FtpListItem ftpListItem, ImageList list)
        {
            if (ftpListItem.Type != FtpFileSystemObjectType.File)
                return 0;

            var extension = ftpListItem.Name.Substring(ftpListItem.Name.LastIndexOf(".") + 1);
            if (extension != null)
            {
                var default_ = list.Images.Keys.Cast<string>().ToList().Where(key => key.Contains("file")).FirstOrDefault();
                var finded = list.Images.Keys.Cast<string>().ToList().Where(key => key.Contains(extension)).FirstOrDefault();
                if (!string.IsNullOrEmpty(finded))
                {
                    return list.Images.IndexOfKey(finded);
                }
                else
                {
                    if (!string.IsNullOrEmpty(default_))
                    {
                        return list.Images.IndexOfKey(default_);
                    }
                }
            }
            return 0;
        }
    }
}
