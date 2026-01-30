using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShoping.Models
    
{
    [Table("Book")]
    public class Book
    {

        public int id {  get; set; }

        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? AuthorName { get; set; }
        [Required]
        [MaxLength(50)]
        public Double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        
        
        //RelationShips
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        public Stock Stock { get; set; }

        [NotMapped]
        public string GenreName { get; set; }
        [NotMapped]
        public int Quantity { get; set; }

    }
}
