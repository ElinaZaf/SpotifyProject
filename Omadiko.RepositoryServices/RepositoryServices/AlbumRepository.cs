using Omadiko.Database;
using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class AlbumRepository
    {
        private ApplicationDbContext db;
        public AlbumRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public List<Album> GetAll()
        {
            return db.Albums.ToList();
        }

        public List<Album> GetAllOrderedByTitle()
        {
            return db.Albums.OrderBy(album => album.Title).ToList();
        }

        public Album GetById(int? id)
        {
            return db.Albums.Find(id);
        }

        public List<Album> GetAlbumsFilteredByTitle(string search, List<Album> albums)
        {
            return albums.Where(x => x.Title.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
        }

        public List<Album> GetAlbumsFilteredByReleaseYear(string search, List<Album> albums)
        {
            return albums.Where(x => x.ReleaseDate.Year.ToString() == search || search == null).ToList();
        }

        public List<Album> GetAlbumsFilteredByArtistName(string search, List<Album> albums)
        {
            return albums.Where(x => x.Artist.Name.ToUpper().Contains(search.ToUpper()) || x.Artist.LastName.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
        }

        public List<Album> GetAlbumsFilteredByGenre(string search, List<Album> albums)
        {
            return albums.Where(x => x.Genres.Count !=0 && x.Genres.All(y => y.Kind.ToUpper().Contains(search.ToUpper())) || search == null).ToList();
        }

    }
}
