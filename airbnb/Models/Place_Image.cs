using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Place_Image
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        [Required]
        public string ImageName { get; set; }
        public virtual Place Place { get; set; }
    }
}
