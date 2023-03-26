using System.ComponentModel.DataAnnotations;

namespace airbnb.Models
{
    public class BookingViewModel
    {
        public int PlaceId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Map { get; set; }
        public string Type { get; set; }
        public List<string> Images { get; set; }
        public int DailyPrice { get; set; }
        public int BedroomNumber { get; set; }
        public int BedNumber { get; set; }
        public int BathroomNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestsNumber { get; set; }

    }
}
