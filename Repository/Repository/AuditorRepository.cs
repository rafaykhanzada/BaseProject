using Core.Data.Entities;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AuditorRepository : RepositoryBase<Auditors>, IAuditorRepository
    {
        public AuditorRepository(IDbTransaction transaction) : base(transaction) 
        {
            
        }
    }
}
