using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Kind { get; set; }


        //Navigation Properties
        public virtual ICollection<Album> Albums { get; set; }
    }
}