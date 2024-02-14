using Bulky.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface ICatogoryRepository:IRepository<Catogiries>
    {
        void update(Catogiries obj);
        
    }
}
