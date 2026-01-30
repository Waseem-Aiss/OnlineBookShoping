using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShoping.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        public int id { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }

        public List<CartDetail> CartDetails { get; set; }
    }
}
