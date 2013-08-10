using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCollection.Repositories
{
    public class AlbumModel
    {
        public int Year { get; set; }

        public string Producer { get; set; }

        public string Title { get; set; }

        public int AlbumId { get; set; }
    }
}
