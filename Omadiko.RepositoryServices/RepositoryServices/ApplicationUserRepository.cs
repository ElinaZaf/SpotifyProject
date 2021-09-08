using Omadiko.Database;
using Omadiko.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class ApplicationUserRepository
    {
        private ApplicationDbContext db;
        public ApplicationUserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<ApplicationUser> GetAll()
        {
            return db.Users.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return db.Users.Find(id);
        }

        public void UpdateUser(ApplicationUser user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
