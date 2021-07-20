using Omadiko.Database;
using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class ArtistRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public Artist GetById(int? id)
        {
            return db.Artists.Find(id);
        }


    }
}
