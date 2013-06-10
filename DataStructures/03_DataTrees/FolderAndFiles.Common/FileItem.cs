using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderAndFiles.Common
{
    public class FileItem
    {
        private readonly string name;
        private readonly long size;

        public string Name
        {
            get
            {
                return this.name;
            }           
        }

        public long Size
        {
            get
            {
                return this.size;
            }
        }

        public FileItem(string fname, long size)
        {
            this.name = fname;
            this.size = size;
        }
    }
}
