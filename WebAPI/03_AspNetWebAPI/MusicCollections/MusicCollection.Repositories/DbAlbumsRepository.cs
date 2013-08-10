using MusicCollection.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace MusicCollection.Repositories
{
    public class DbAlbumsRepository : IRepository<Album>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Album> entitySet;

        public DbAlbumsRepository(DbContext context) // the constructor, initing the context and entitySet
        {
            this.dbContext = context;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album item, int catId = 0)
        {
            entitySet.Add(item);
            dbContext.SaveChanges();

            return item;
        }

        public Album Update(int id, Album item)
        {
            var entry = this.dbContext.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(item);
            }

            entry.State = EntityState.Modified;
            
            this.dbContext.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var albumToDelete = this.entitySet.Find(id);

            this.entitySet.Remove(albumToDelete);
            this.dbContext.SaveChanges();
        }

        public void Delete(Album item)
        {
            this.entitySet.Remove(item);
            this.dbContext.SaveChanges();
        }

        public Album Get(int id)
        {
            var album = this.entitySet.Find(id);

            return album;
        }

        public IQueryable<Album> All()
        {
            return this.entitySet;
        } 
    }
}
