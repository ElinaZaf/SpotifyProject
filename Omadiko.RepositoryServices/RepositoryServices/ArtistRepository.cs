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

        public List<Artist> GetAllOrderedByName()
        {
            return db.Artists.OrderBy(artist => artist.Name).ToList();
        }

        public Artist GetById(int? id)
        {
            return db.Artists.Find(id);
        }

        public List<Artist> GetArtistsFilteredByName(string search, List<Artist> artists)
        {
            return artists.Where(x => x.Name.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
        }

        public List<Artist> GetArtistsFilteredByCountry(string search, List<Artist> artists)
        {
            return artists.Where(x => x.Country.ToUpper() == search.ToUpper() || search == null).ToList();
        }
    }
}
