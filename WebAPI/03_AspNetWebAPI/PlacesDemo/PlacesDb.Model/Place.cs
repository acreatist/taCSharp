using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDb.Model
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Category> Categoires { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Place()
        {
            this.Categoires = new HashSet<Category>();
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
