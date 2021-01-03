using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.BasketItems
{
    public sealed class BasketItemView : UniqueEntityView
    {
        [Required]
        [DisplayName("Ostukorv")]
        public string BasketId { get; set; }
        
        [Required]
        [DisplayName("Toode")]
        public string ProductId { get; set; }
        
        [Required]
        [DisplayName("Kogus")]
        public int Quantity { get; set; }
    }
}
