using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmwDesktop.Data.Models
{
    public class SyncableDirectory
    {
        [Key]
        public string Path { get; set; }

        public SyncableDirectory() { }
    }
}
