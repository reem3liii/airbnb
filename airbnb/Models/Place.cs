using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Place
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Required]
        public int DailyPrice { get; set; }

        [Required]
        public int BedroomNumber { get; set; }

        [Required]
        public int BedNumber { get; set; }

        [Required]
        public int BathroomNumber { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
}
