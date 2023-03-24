namespace airbnb.Models
{
    public class PlaceDetailsViewModel
    {
        public int PlaceId { get; set; }
        public ReserveViewModel Reserve { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Map { get; set; }
        public double AvgRating { get; set; }
        public int ReviewsNumber { get; set; }
        public List<string> ImagesUrls { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public int BedroomNumber { get; set; }
        public int BedNumber { get; set; }
        public int BathroomNumber { get; set; }
        public List<string> Services { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public Owner Owner { get; set; }
        public List<string> OwnerPhones { get; set; }


    }
}
