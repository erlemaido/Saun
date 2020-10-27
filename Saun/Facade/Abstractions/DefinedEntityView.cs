using System.ComponentModel;

namespace Saun.Facade.Abstractions
{
    public class DefinedEntityView : NamedEntityView
    {
        [DisplayName("Kirjeldus")]
        public string Description { get; set; } = null!;

    }
}