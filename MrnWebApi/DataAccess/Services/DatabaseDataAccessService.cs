using MrnWebApi.DataAccess.Inner.Scaffold.Entities;

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
