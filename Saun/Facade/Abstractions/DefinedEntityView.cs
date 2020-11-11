using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Abstractions
{
    public class DefinedEntityView : NamedEntityView
    {
        [DisplayName("Kirjeldus")]
        [MaxLength(1024)]
        public string Description { get; set; }
    }
}