using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShoping.Models
{
    [Table("CardDetail")]
    public class CartDetail
    {
        public int Id { get; set; }
        
        [Required]
        public int ShopingCardId { get; set; }

        [Required]
        public int Quantity {  get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}
