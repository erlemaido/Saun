using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Payments
{
    public sealed class PaymentView : UniqueEntityView
    {
        [Required]
        [DisplayName("Tellimus")]
        public string OrderId { get; set; }
        
        [DisplayName("Klient")]
        public string PersonId { get; set; }
        
        [Required]
        [DisplayName("Maksevahend")]
        public string PaymentTypeId { get; set; }

        [Required]
        [DisplayName("Aeg")] 
        public string Time { get; set; }
    }
}
