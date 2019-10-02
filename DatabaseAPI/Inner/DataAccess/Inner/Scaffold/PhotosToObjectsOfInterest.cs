namespace DatabaseAPI.Inner.DataAccess.Inner.Scaffold
{
    public partial class PhotosToObjectsOfInterest
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public int ObjectOfInterestId { get; set; }

        public virtual ObjectsOfInterest ObjectOfInterest { get; set; }
        public virtual Photos Photo { get; set; }
    }
}
