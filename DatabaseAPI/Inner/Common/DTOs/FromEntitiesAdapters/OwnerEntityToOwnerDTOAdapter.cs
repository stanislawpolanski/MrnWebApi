using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class OwnerEntityToOwnerDTOAdapter : OwnerDTO
    {
        public OwnerEntityToOwnerDTOAdapter(Owners adaptee)
        {
            this.Id = adaptee.Id;
            this.Name = adaptee.Name;
        }
    }
}
