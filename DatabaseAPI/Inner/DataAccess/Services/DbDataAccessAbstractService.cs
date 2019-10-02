using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.DataAccess.Services
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
