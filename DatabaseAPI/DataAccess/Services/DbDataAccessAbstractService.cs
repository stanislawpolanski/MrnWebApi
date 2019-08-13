using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.DataAccess.Services
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
