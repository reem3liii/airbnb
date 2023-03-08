using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Customer_Phone
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Column(TypeName = "varchar(11)")]
        public string PhoneNumber { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
