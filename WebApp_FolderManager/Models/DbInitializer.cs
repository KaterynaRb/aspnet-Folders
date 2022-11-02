using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp_FolderManager.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Folders.Add(new Folder { Id = 1, Name = "Creating Digital Images", ParentId = 0, FullPath = "Creating Digital Images/" });

            context.Folders.Add(new Folder { Id = 2, Name = "Resourses", ParentId = 1, FullPath = "Creating Digital Images/Resourses/" });
            context.Folders.Add(new Folder { Id = 3, Name = "Evidence", ParentId = 1, FullPath = "Creating Digital Images/Evidence/" });
            context.Folders.Add(new Folder { Id = 4, Name = "Graphic Products", ParentId = 1, FullPath = "Creating Digital Images/Graphic Products/" });

            context.Folders.Add(new Folder { Id = 5, Name = "Primary Sources", ParentId = 2, FullPath = "Creating Digital Images/Resourses/Primary Sources/" });
            context.Folders.Add(new Folder { Id = 6, Name = "Secondary Sources", ParentId = 2, FullPath = "Creating Digital Images/Resourses/Secondary Sources/" });

            context.Folders.Add(new Folder { Id = 7, Name = "Process", ParentId = 4, FullPath = "Creating Digital Images/Graphic Products/Process/" });
            context.Folders.Add(new Folder { Id = 8, Name = "Final Product", ParentId = 4, FullPath = "Creating Digital Images/Graphic Products/Final Product/" });

            base.Seed(context);
        }
    }
}