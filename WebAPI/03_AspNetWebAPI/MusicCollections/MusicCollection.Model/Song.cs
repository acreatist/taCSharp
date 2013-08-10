namespace MusicCollection.Model
{
    using System;
    using System.Linq;

    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public string Gender { get; set; }

        public int Year { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
