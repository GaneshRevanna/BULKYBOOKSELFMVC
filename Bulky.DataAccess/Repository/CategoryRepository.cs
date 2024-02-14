using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Catogiries>, ICatogoryRepository 
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db=db;
        }

        

        

        public void update(Catogiries obj)
        {
            _db.Catogiries.Update(obj);
        }
    }
}
