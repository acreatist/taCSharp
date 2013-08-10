using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCollection.WebAPI.Controllers
{
    public class AlbumModelFull
    {
        public int Year { get; set; }

        public string Producer { get; set; }

        public string Title { get; set; }

        public int AlbumId { get; set; }

        public IEnumerable<ArtistModel> Artists { get; set; }
    }
}
