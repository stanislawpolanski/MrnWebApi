using DatabaseAPI.Inner.Logic.RailwayService.Commands;

namespace DatabaseAPI.Inner.Logic.RailwayService.DataAccess
{
    public interface IRailwayLogicDataAccessClientsProvider
    {
        void InjectClients(IRailwayCommand command);
    }
}
