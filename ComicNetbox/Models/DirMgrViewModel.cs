using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicNetbox.Models
{
    public class DirMgrViewModel
    {
        public List<DirectoryInfo> Directorys { get; internal set; }
        public string Index { get; set; }
        public List<FileInfo> Pictures { get; internal set; }
        public string Root { get; internal set; }
    }
}
