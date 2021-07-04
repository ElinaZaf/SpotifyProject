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
    public class ProductRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetAllOrderedByName()
        {
            return db.Products.OrderBy(x=>x.Name).ToList();
        }

        public IEnumerable<Product> FilterByName(string name)
        {
            return db.Products.Where(x => x.Name.Contains(name)).ToList();
        }



        public Product GetById(int? id)
        {
            return db.Products.Find(id);
        }

        public void Insert(Product product)
        {
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);

            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
        }












        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
