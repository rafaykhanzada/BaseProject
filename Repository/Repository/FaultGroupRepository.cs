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
    public class FaultGroupRepository : RepositoryBase<FaultGroup>,IFaultGroupRepository
    {
        public FaultGroupRepository(IDbTransaction transaction) : base(transaction) 
        { 

        }
    }
}
