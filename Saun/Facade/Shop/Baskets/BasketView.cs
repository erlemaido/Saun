using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Baskets
{
    public sealed class BasketView : UniqueEntityView
    {
        [Required]
        [DisplayName("Nimi")]
        public string Name { get; set; }

        [DisplayName("Klient")]
        public string PersonId { get; set; }

        [Required]
        [DisplayName("Hind")]
        public double TotalPrice { get; set; }
    }
}
