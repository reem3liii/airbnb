using System.ComponentModel.DataAnnotations;

namespace airbnb.DTO
{
    public class ReserveDTO
    {
        public int PlaceId { get; set; }
        public int DailyPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime EndDate { get; set; }
        [Required]
        public int GuestsNumber { get; set; }
        public int ServicesPrice { get; set; }
        public int Duration { get; set; }
        public int DailypriceInDuration { get; set; }
        public int TotalPrice { get; set; }
        public string PaymentType { get; set; }


    }
}
