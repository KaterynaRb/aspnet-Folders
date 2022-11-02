using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp_FolderManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("FolderManagerDb")
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Folder> Folders { get; set; }
    }
}