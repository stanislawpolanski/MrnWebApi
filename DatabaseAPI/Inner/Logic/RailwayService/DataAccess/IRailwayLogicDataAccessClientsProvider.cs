using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess
{
    public interface IRailwayLogicDataAccessClientsProvider
    {
        void InjectClients(IRailwayCommand command);
    }
}
