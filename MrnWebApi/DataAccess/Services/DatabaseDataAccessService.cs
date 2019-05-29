using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services
{
    public abstract class DatabaseDataAccessService
    {
        protected MRN_developContext dbContext;

        public DatabaseDataAccessService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
        }
    }
}
