using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.DeliveryCities
{
    public sealed class DeliveryCityView : NamedEntityView
    {
        [Required]
        [DisplayName("Riik")]
        public string DeliveryCountryId { get; set; }

    }
}
