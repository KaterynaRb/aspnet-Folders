using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FolderManager.Models;

namespace WebApp_FolderManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string currPath)
        {
            if (currPath == null)
            {
                currPath = "Creating Digital Images/";
            }

            using (AppDbContext dbContext = new AppDbContext())
            {
                Folder folder = dbContext.Folders.Where(c => c.FullPath == currPath).FirstOrDefault();

                if (folder == null)
                {
                    return HttpNotFound();
                }

                currPath = folder.FullPath;
                ViewBag.CurrentDirectory = folder.Name;

                var subDirectories = dbContext.Folders.Where(c => c.ParentId == folder.Id).ToList();
                return View(subDirectories);
            }
        }

        [HttpPost]
        public ActionResult Index(String[] strPaths)
        {
            DirectoryInfo[] dir = new DirectoryInfo[strPaths.Length];

            using (AppDbContext dbContext = new AppDbContext())
            {
                int currentId = dbContext.Folders.Max(c => c.Id) + 1;
                var longest = strPaths.OrderByDescending(s => s.Length)
                    .ThenBy(s => s)
                    .FirstOrDefault();

                string rootFolderPath = longest.Split('/')[1] + "/";
                Folder rootFolder = new Folder { Id = currentId, Name = longest.Split('/')[1], FullPath = rootFolderPath };
                dbContext.Folders.Add(rootFolder);

                int id = currentId;

                for (int i = 0; i < strPaths.Length; i++)
                {
                    dir[i] = Directory.CreateDirectory(strPaths[i]);
                    DirectoryInfo[] subDir = dir[i].GetDirectories();

                    string subFolderPath = dir[i].FullName.Replace('\\', '/').Substring(3);

                    Folder folder = new Folder();
                    folder.Id = ++id;
                    folder.Name = dir[i].Name;
                    folder.ParentId = currentId; // parse
                    folder.FullPath = subFolderPath;
                    dbContext.Folders.Add(folder);
                }

                dbContext.SaveChanges();

                var subDirectories = dbContext.Folders.Where(c => c.ParentId == currentId).ToList();

                //TempData["list"] = subDirectories;

                return View(subDirectories);
            }
        }

        //public ActionResult ImportedDirectory(string rootFolder)
        //{
        //    ViewBag.CurrentDirectory = rootFolder;
        //    var subDirs = TempData["list"] as List<Folder>;
        //    return View("CurrentDirectory", subDirs);
        //}
    }
}