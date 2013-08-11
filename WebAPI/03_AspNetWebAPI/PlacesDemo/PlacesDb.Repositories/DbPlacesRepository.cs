using PlacesDb.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDb.Repositories
{
    public class DbPlacesRepository : IRepository<Place>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Place> entitySet;

        public DbPlacesRepository(DbContext context)
        {
            this.dbContext = context;
            this.entitySet = this.dbContext.Set<Place>();
        }

        public Place Add(Place item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public void Update(int id, Place item)
        {
            
        }

        public Place Delete(int id)
        {
            var placeToDelete = this.entitySet.Find(id);
            this.entitySet.Remove(placeToDelete);

            return placeToDelete;
        }

        public Place Delete(Place item)
        {
            this.entitySet.Remove(item);

            return item;
        }

        public Place Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Place> All()
        {
            return this.entitySet;
        }

        public IQueryable<Place> Find(System.Linq.Expressions.Expression<Func<Place, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
