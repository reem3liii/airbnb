using System.ComponentModel.DataAnnotations;

namespace airbnb.Models
{
    public class PlaceViewModel
    {
        public int PlaceId { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int DailyPrice { get; set; }
        public double AvgRating { get; set; }
        public List<string> ImagesUrls { get; set; }

    }
}
