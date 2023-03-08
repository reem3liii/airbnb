using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Place_Service
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public int Price { get; set; }
        public virtual Place Place { get; set; }
    }
}
