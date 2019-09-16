using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.Command
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}
