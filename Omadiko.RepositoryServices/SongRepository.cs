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
        ApplicationDbContext db = new ApplicationDbContext();


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


    }
}
