using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmwDesktop.UI.ViewModel
{
    public class SyncableDirectoryListItem
    {
        public string Path { get; set; }
        public string ShortPath { get; set; }

        public SyncableDirectoryListItem(Data.Models.SyncableDirectory from)
        {
            Path = from.Path;
            ShortPath = System.IO.Path.GetFileName(from.Path);
        }
    }
}
