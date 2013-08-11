using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDb.Model
{
   public  class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }

        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}
