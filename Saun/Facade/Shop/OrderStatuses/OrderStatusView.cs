using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.OrderStatuses
{
    public class OrderStatusView : UniqueEntityView
    {
        [Required]
        [DisplayName("Tellimus")]
        public string OrderId { get; set; }
        
        [Required]
        [DisplayName("Staatus")]
        public string StatusId { get; set; }
        
        [Required]
        [DisplayName("Aeg")]
        public DateTime Time { get; set; }

        [DisplayName("Kommentaar")] 
        public string Comment { get; set; }
    }
}
