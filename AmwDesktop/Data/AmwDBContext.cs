using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity;
using AmwDesktop.Data.Models;
using System.Security;

namespace AmwDesktop.Data
{
    class AmwDBContext : DbContext
    {
        public DbSet<SyncableDirectory> Directories { get; set; }

        public static void AddDirectory(string path)
        {
            using (var ctx = new AmwDBContext())
            {
                ctx.Directories.Add(new SyncableDirectory { Path = path });
                ctx.SaveChanges();
            }
        }

        public static void RemoveDirectory(string path)
        {
            using (var ctx = new AmwDBContext())
            {
                var dir = new SyncableDirectory { Path = path };
                ctx.Directories.Attach(dir);
                ctx.Directories.Remove(dir);
                ctx.SaveChanges();
            }
        }

        public static bool CanSyncDirectory(string path)
        {
            var parentsFolders = new List<string>();
            for (int i = 0; i < path.Length; ++i)
            {
                if (path[i] == Path.DirectorySeparatorChar)
                {
                    parentsFolders.Add(path.Substring(0, i+1));
                }
            }
            using (var ctx = new AmwDBContext())
            {
                return ctx.Directories.Where(e => parentsFolders.Contains(e.Path)).Count() > 0;
            }
        }

        public static IEnumerable<SyncableDirectory> GetDirectories()
        {
            using (var ctx = new AmwDBContext())
            {
                return ctx.Directories.ToList();
            }
        }

        public static void DeleteAndCreate()
        {
            using (var ctx = new AmwDBContext())
            {
                ctx.Database.Delete();
                ctx.Database.Create();
            }   
        }
    }
}
