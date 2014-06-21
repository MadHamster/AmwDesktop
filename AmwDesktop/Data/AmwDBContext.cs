using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AmwDesktop.Data.Models;

namespace AmwDesktop.Data
{
    class AmwDBContext : DbContext
    {
        public DbSet<SyncableDirectory> Folders { get; set; }

        public static void AddFolder(SyncableDirectory dir)
        {
            using (var ctx = new AmwDBContext())
            {
                ctx.Folders.Add(dir);
                ctx.SaveChanges();
            }
        }

        public static IEnumerable<SyncableDirectory> GetFolders()
        {
            using (var ctx = new AmwDBContext())
            {
                return ctx.Folders.ToArray();
            }
        }
    }
}
