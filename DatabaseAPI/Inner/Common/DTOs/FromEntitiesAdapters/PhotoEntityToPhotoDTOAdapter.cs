using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class PhotoEntityToPhotoDTOAdapter : PhotoDTO
    {
        public PhotoEntityToPhotoDTOAdapter(Photos adaptee)
        {
            this.Id = adaptee.Id;
            this.FilePath = adaptee.FilePath;
        }
    }
}
