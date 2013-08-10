namespace MusicCollection.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public Album()
        {
            this.Artists = new HashSet<Artist>();
        }
    }
}
