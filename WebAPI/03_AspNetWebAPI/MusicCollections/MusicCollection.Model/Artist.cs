namespace MusicCollection.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }
    }
}