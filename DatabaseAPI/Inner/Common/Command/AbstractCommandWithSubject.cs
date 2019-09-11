using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.Command
{
    public abstract class AbstractCommandWithSubject<T> : ICommand
    {
        protected T subject;
        protected T result;

        public abstract Task ExecuteAsync();

        public void SetExecutionSubject(T subject)
        {
            this.subject = subject;
        }

        public T GetResult()
        {
            return result;
        }
    }
}
