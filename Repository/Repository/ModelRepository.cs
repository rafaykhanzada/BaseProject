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
    public class ModelRepository : RepositoryBase<Models>, IModelRepository
    {
        public ModelRepository(IDbTransaction transaction) : base(transaction)
        { 
        }
    }
}
