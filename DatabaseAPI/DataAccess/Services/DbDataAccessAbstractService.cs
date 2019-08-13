using MrnWebApi.DataAccess.Inner.Scaffold;

namespace MrnWebApi.DataAccess.Services
{
    public abstract class DbDataAccessAbstractService
    {
        protected MRN_developContext context;

        public DbDataAccessAbstractService(MRN_developContext injectedContext)
        {
            context = injectedContext;
        }
    }
}
