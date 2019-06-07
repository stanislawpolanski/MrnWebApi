using MrnWebApi.DataAccess.Inner.Scaffold.Entities;

namespace MrnWebApi.DataAccess.Services
{
    public abstract class DbDataAccessAbstractService
    {
        protected MRN_developContext dbContext;

        public DbDataAccessAbstractService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
        }
    }
}
