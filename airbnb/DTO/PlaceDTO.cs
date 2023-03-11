using airbnb.Models;
using System.ComponentModel.DataAnnotations;

namespace airbnb.DTO
{
    public class PlaceDTO
    {
        public int PlaceId { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int DailyPrice { get; set; }
        public double AvgRating { get; set; }
        public List<String> ImagesUrls { get; set; }

    }
}
