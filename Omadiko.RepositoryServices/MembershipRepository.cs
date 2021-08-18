using Omadiko.Database;
using Omadiko.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.RepositoryServices
{
    public class MembershipRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Membership> GetAll()
        {
            return db.Memberships.ToList();
        }

        public Membership GetById(int? id)
        {
            return db.Memberships.Find(id);
        }

    }
}
