using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PhotoUrl { get; set; }


        //Navigation Properties
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}