namespace MusicCollection.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using MusicCollection.Model;

    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("MusicCollectionDb")
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
