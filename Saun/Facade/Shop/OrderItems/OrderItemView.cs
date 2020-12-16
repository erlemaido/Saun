using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.OrderItems
{
    public class OrderItemView : UniqueEntityView
    {
        [Required]
        [DisplayName("Tellimus")]
        public string OrderId { get; set; }
        
        [Required]
        [DisplayName("Toode")]
        public string ProductId { get; set; }
        
        [Required]
        [DisplayName("Kogus")]
        public int Quantity { get; set; }
    }
}
