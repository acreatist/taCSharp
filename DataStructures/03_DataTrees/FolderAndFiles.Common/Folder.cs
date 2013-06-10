using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderAndFiles.Common
{
    public class Folder
    {
        private readonly bool hasParent;
        private readonly string name;
        private readonly List<FileItem> files;
        private readonly List<Folder> subfolders;

        /* ----------------------
         *      PROPERTIES
         * -------------------- */     
        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public List<FileItem> Files
        {
            get
            {
                return this.files;
            }
        }

        public List<Folder> Subfolders
        {
            get
            {
                return this.subfolders;
            }
        }

        public int GetFoldersCount
        {
            get
            {
                return this.subfolders.Count;
            }
        }

        public int GetFilesCount
        {
            get
            {
                return this.files.Count;
            }
        }

        /* ----------------------
         *      CONSTRUCTORS
         * -------------------- */
        public Folder(string fName, bool hasParent)
        {
            this.name = fName;
            this.hasParent = false;
            this.subfolders = new List<Folder>();
            this.files = new List<FileItem>();
        }

        /* ----------------------
         *      METHODS
         * -------------------- */
        public void AddFile(FileItem newFile)
        {
            this.files.Add(newFile);
        }

        public void AddFolder(Folder subFolder)
        {
            this.subfolders.Add(subFolder);
        }

        public Folder GetChild(int index)
        {
            Folder returnChild = this.subfolders[index];

            return returnChild;
        }

        
    }
}
