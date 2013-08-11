using PlacesDb.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDb.Repositories
{
    public class DbCategoriesRepositiory : IRepository<Category>
    {
        private DbContext context;
        private DbSet<Category> entitySet;

        public DbCategoriesRepositiory(DbContext context)
        {
            this.context = context;
            this.entitySet = context.Set<Category>();
        }

        public Category Add(Category item)
        {
            this.entitySet.Add(item);
            this.context.SaveChanges();

            return item;
        }

        public void Update(int id, Category item)
        {
            var entity = this.entitySet.Find(id);

            if (item.Name != null)
            {
                entity.Name = item.Name;
            }

            foreach (var place in item.Places)
	        {
		        if (!entity.Places.Contains(place))
                {
                    entity.Places.Add(place);
                }
	        }

            this.context.SaveChanges();
        }

        public Category Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            this.entitySet.Remove(entity);
            this.context.SaveChanges();

            return entity;
        }

        public Category Delete(Category item)
        {
            this.entitySet.Remove(item);

            return item;
        }

        public Category Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Category> All()
        {
            return this.entitySet;
        }

        public IQueryable<Category> Find(System.Linq.Expressions.Expression<Func<Category, int, bool>> predicate)
        {
            return null;
        }

    }
}
