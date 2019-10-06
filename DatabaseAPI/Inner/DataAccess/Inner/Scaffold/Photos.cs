using System;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.DataAccess.Inner.Scaffold
{
    public partial class Photos
    {
        public Photos()
        {
            PhotosToObjectsOfInterest = new HashSet<PhotosToObjectsOfInterest>();
        }

        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTime? AdditionDateTime { get; set; }
        public string PhotoDescription { get; set; }

        public virtual ICollection<PhotosToObjectsOfInterest> PhotosToObjectsOfInterest { get; set; }
    }
}
