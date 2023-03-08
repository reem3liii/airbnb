using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Owner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public int ResponseRate { get; set; }

        [Required]
        [StringLength(30)]
        public string ResponseTime { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "varchar(14)")]
        public string NID { get; set; }

        public virtual List<Place> Places { get; set; } = new List<Place>();
    }
}
