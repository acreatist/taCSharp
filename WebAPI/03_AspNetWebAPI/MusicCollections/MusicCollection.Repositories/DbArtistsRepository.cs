using MusicCollection.Data;
using MusicCollection.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection.Repositories
{
    public class DbArtistsRepository : IRepository<Artist>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Artist> entitySet;
        private readonly DbAlbumsRepository albumsRepo;

        public DbArtistsRepository(DbContext context)
        {
            this.dbContext = context;
            this.entitySet = this.dbContext.Set<Artist>();
            this.albumsRepo = new DbAlbumsRepository(this.dbContext);
        }

        public Artist Add(Artist item, int catId = 0)
        {
            var newArtist = this.entitySet.Add(item);
            this.dbContext.SaveChanges();

            var album = albumsRepo.Get(catId);
            album.Artists.Add(newArtist);
            albumsRepo.Update(catId, album);

            return newArtist;
        }

        public Artist Update(int id, Artist item)
        {
 	        throw new NotImplementedException();
        }

        public void Delete(int id)
        {
 	        throw new NotImplementedException();
        }

        public void Delete(Artist item)
        {
 	        throw new NotImplementedException();
        }

        public Artist Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> All()
        {
            return this.entitySet;
        }
    }
}
