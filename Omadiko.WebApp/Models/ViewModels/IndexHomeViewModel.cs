using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.WebApp.Models
{
    public class IndexHomeViewModel
    {
        public List<Album> NewReleases { get; set; }
        public List<Artist> FeaturedArtists { get; set; }
        public List<Album> FeaturedAlbums { get; set; }
        public List<Song> FeaturedSongs { get; set; }
        public List<Artist> FavouriteArtists { get; set; }
        public List<Album> FavouriteAlbums { get; set; }
    }
}