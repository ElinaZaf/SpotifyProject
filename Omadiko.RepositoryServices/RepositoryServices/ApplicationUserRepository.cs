using Omadiko.Database;
using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class ApplicationUserRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public List<ApplicationUser> GetAll()
        {
            return db.Users.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return db.Users.Find(id);
        }

    }
}
