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
        ApplicationDbContext db = new ApplicationDbContext();


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

    }
}
