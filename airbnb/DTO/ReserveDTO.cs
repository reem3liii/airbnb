using System.ComponentModel.DataAnnotations;

namespace airbnb.DTO
{
    public class ReserveDTO
    {
        public int DailyPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestsNumber { get; set; }
        public int ServicesPrice { get; set; }
        public int Duration { get; set; }


    }
}
