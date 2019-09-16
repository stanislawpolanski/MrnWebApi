using DatabaseAPI.DataAccess.Inner.Scaffold;

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
