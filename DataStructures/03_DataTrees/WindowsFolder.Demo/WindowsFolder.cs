using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFolder.Tree;

namespace WindowsFolder.Demo
{
    class WindowsFolder
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Brother";

            TreeItem<string> rootFolder = new TreeItem<string>(rootDirectory);
            
            PopulateFolders(rootDirectory, rootFolder);

            Tree<string> foldersTree = new Tree<string>(rootFolder);

            List<string> exeFiles = new List<string>();

            FindExeFile(exeFiles, foldersTree.Root);
        }
  
        private static void PopulateFolders(string dirName, TreeItem<string> parentFolder)
        {
            string[] folderItems = Directory.GetFileSystemEntries(dirName);

            foreach (var folderItem in folderItems)
            {
                TreeItem<string> folderSubItem = new TreeItem<string>(folderItem);
                parentFolder.AddChild(folderSubItem);

                // If the current node is a filename, don't call recursion and continue
                try
                {
                    Directory.GetDirectories(folderItem);
                }
                catch (IOException ex)
                {
                    continue;
                }

                PopulateFolders(folderItem, folderSubItem);
            }
        }

        private static void FindExeFile(List<string> foundExeFiles, TreeItem<string> treeItem)
        {
            string pattern = "exe";
            
            if (!treeItem.IsFolder)
            {
                string[] fileParts = treeItem.Value.Split('.');

                if (fileParts[fileParts.Length - 1] == pattern)
                {
                    foundExeFiles.Add(treeItem.Value);
                }
            }

            for (int i = 0; i < treeItem.ChildItemsCount; i++)
            {
                FindExeFile(foundExeFiles, treeItem.GetChild(i));
            }
        }
    }
}
