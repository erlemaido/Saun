using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Cities
{
    public sealed class CityView : NamedEntityView
    {
        [Required]
        [DisplayName("Riik")]
        public string CountryId { get; set; }

    }
}
