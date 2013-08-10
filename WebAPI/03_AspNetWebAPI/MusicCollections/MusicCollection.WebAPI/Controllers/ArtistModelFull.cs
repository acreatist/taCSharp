using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCollection.WebAPI.Controllers
{
    public class ArtistModelFull
    {
        public string Country { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}
