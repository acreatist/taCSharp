using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderAndFiles.Common
{
    public class FoldersTree
    {
        private readonly Folder root;

        /* ----------------------
         *      PROPERTIES
         * -------------------- */
        public Folder Root
        {
            get
            {
                return this.root;
            }
        }

        /* ----------------------
         *      CONSTRUCTORS
         * -------------------- */
        public FoldersTree(Folder root)
        {
            this.root = root;
        }

        /* ----------------------
         *      METHODS
         * -------------------- */
        // By given node, return the subtree
        public FoldersTree GetSubTree(Folder subTreeRoot)
        {
            FoldersTree subTree = new FoldersTree(subTreeRoot);

            return subTree;
        }

        public long GetTreeFilesLength()
        {
            long sumFileSize = 0;

            sumFileSize = GetFilesLengthDFS(this.Root, sumFileSize);

            return sumFileSize;
        }

        private long GetFilesLengthDFS(Folder folder, long currSumSize)
        {
            
            Folder currFolder = folder;

            // Get all files in currentFolder            
            foreach (var subItem in currFolder.Files)
            {
                currSumSize += subItem.Size;
            }

            // Iterate through subfolders
            foreach (var subItem in currFolder.Subfolders)
            {
                currSumSize = GetFilesLengthDFS(subItem, currSumSize);
            }

            return currSumSize;
        }

        public Folder GetFolderByName(string folderName)
        {
            Folder foundFolder = GetFolderByNameBFS(this.Root, folderName);

            return foundFolder;
        }

        private Folder GetFolderByNameBFS(Folder folder, string searchFolderName)
        {
            Folder currFolder = folder;
            Folder foundFolder = null;

            if (currFolder.Name == searchFolderName)
            {
                foundFolder = currFolder;
                return foundFolder;
            }
            else
            {
                foreach (var subFolder in currFolder.Subfolders)
                {
                    
                    foundFolder = GetFolderByNameBFS(subFolder, searchFolderName);
                    // Recursion get out condition
                    if (foundFolder != null)
                    {
                        return foundFolder;
                    }
                    
                }

                if (foundFolder == null)
                {
                    throw new FileNotFoundException(String.Format("Folder with name {0} not found", searchFolderName));
                }
            }
            return null;
        }
    }
}
