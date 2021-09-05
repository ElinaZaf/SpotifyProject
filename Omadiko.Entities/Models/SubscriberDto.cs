using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.Entities.Models
{
    public class SubscriberDto
    {
        public string UserId { get; set; }

        public virtual ICollection<Artist> FavouriteArtists { get; set; }
        public virtual ICollection<Album> FavouriteAlbums { get; set; }
        public virtual ICollection<Song> FavouriteSongs { get; set; }
    }
}
