using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_FolderManager.Models
{
    public class Folder
    {
        public int Id { get; set; } //Primary Key
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string FullPath { get; set; }
    }
}