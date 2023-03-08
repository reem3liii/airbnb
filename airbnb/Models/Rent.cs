using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Rent
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        [ForeignKey("Contract")]
        public int ContractId { get; set; }

        [Required]
        public int GuestsNumber { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Place Place { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
