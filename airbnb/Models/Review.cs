using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        [Range(0, 5)]
        public int Ratings { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

    }
}
