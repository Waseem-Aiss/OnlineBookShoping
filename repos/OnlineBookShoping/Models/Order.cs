using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShoping.Models
{
    [Table("Order")]
    public class Order
    {
        public int id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.UtcNow;
        
        [Required]
        public int OrderStatusId { get; set; }
        
        public bool IsDeleted { get; set; } = false;
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength (50)]
        public string? Email { get; set; }
        [Required]
        public string? MobileNumber { get; set; }

        [Required,MaxLength(150)]
        public string? Address { get; set; }
        [Required,MaxLength(20)]
        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
