using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Units
{
    public sealed class UnitView : NamedEntityView
    {
        [Required]
        [DisplayName("Lühend")]
        public string Code { get; set; }
    }
}
