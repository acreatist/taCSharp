using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderAndFiles.Common;
using System.IO;

namespace FolderAndFiles.Demo
{
    class FolderAndFilesDemo
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Windows";
            Folder rootFolder = new Folder(rootDirectory, false);

            Console.WriteLine("Getting items in {0}, this can take a while", rootDirectory);
            Console.WriteLine();

            PopulateFolders(rootDirectory, rootFolder);

            // Create the Windows Folder tree
            FoldersTree windowsFolderTree = new FoldersTree(rootFolder);

            try
            {
                // Get the subtree, by folder path string
                Folder subFolderFilesSize = windowsFolderTree.GetFolderByName("C:\\Windows\\addins\\Test");
                FoldersTree subFoldersTree = windowsFolderTree.GetSubTree(subFolderFilesSize);

                long sumFilesSize = subFoldersTree.GetTreeFilesLength();

                Console.WriteLine("Files size sum in Tree({0}) = {1}", subFolderFilesSize.Name, sumFilesSize);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error finding files size: {0}", ex.Message);
            }
        }

        private static void PopulateFolders(string dirName, Folder parentFolder)
        {
            string[] folderItems = Directory.GetFileSystemEntries(dirName);

            foreach (var folderItem in folderItems)
            {
                // If the current node is a filename, don't call recursion and continue
                try
                {
                    Directory.GetDirectories(folderItem);
                }
                catch (IOException ex)
                {
                    FileInfo finfo = new FileInfo(folderItem);
                    FileItem fileSubItem = new FileItem(folderItem, finfo.Length);
                    parentFolder.AddFile(fileSubItem);
                    continue;
                }
                // Some windows folders could be restricted, so just output a warning message and continue
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Warning: No access to folder {0}", dirName);
                    continue;
                }

                Folder folderSubItem = new Folder(folderItem, true);
                parentFolder.AddFolder(folderSubItem);

                PopulateFolders(folderItem, folderSubItem);
            }
        }
    }
}
