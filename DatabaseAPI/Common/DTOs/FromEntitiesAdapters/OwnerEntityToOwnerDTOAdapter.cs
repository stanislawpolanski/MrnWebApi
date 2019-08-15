using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
