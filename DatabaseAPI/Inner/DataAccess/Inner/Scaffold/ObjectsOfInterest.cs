﻿using System.Collections.Generic;

namespace DatabaseAPI.Inner.DataAccess.Inner.Scaffold
{
    public partial class ObjectsOfInterest
    {
        public ObjectsOfInterest()
        {
            PhotosToObjectsOfInterest = new HashSet<PhotosToObjectsOfInterest>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public virtual Owners Owner { get; set; }
        public virtual Stations Stations { get; set; }
        public virtual ICollection<PhotosToObjectsOfInterest> PhotosToObjectsOfInterest { get; set; }
    }
}
