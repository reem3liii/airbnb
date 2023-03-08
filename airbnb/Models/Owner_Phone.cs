using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace airbnb.Models
{
    public class Owner_Phone
    {
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Column(TypeName = "varchar(11)")]
        public string PhoneNumber { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
