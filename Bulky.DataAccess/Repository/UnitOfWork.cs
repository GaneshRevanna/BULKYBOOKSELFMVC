using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICatogoryRepository CatogoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            CatogoryRepository=new CategoryRepository(_db);
            ProductRepository=new ProductRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
