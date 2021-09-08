using Omadiko.Database;
using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class SongRepository
    {
        private ApplicationDbContext db;
        public SongRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Song> GetAll()
        {
            return db.Songs.ToList();
        }

        public List<Song> GetAllOrderedByTitle()
        {
            return db.Songs.OrderBy(song => song.Title).ToList();
        }

        public Song GetById(int? id)
        {
            return db.Songs.Find(id);
        }

        public List<Song> GetSongsFilteredByTitle(string search, List<Song> songs)
        {
            return songs.Where(x => x.Title.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
        }
        public List<Song> GetSongsFilteredByArtistName(string search, List<Song> songs)
        {
            return songs.Where(x => x.Albums.Count != 0 && x.Albums.All(y => y.Artist.Name.ToUpper().Contains(search.ToUpper()) || y.Artist.LastName.ToUpper().Contains(search.ToUpper())) || search == null).ToList();
        }
    }
}
