using airbnb.Models;

namespace airbnb.DTO
{
    public class PlaceDetailsDTO
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public double AvgRating { get; set; }
        public int ReviewsNumber { get; set; }
        public List<String> ImagesUrls { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public int BedroomNumber { get; set; }
        public int BedNumber { get; set; }
        public int BathroomNumber { get; set; }
        public List<String> Services { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public Owner Owner { get; set; }


    }
}
