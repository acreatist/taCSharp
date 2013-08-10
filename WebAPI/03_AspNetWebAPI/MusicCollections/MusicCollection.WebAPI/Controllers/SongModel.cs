using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCollection.WebAPI.Controllers
{
    public class SongModel
    {
        public int SongId { get; set; }

        public string Gender { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}
