using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlacesDb.Model;

namespace PlacesDb.Data
{
    public class PlacesContext : DbContext
    {
        public PlacesContext()
            : base("PlacesDb")
        {
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
